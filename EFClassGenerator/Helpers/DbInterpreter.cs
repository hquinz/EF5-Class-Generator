using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using ClassGenerator.Data;
using EFClassGenerator.Data;
using EFClassGenerator.Tools;

namespace EFClassGenerator.Helpers
{
    internal class DbInterpreter
    {
        internal delegate void SetState(string state);
        private readonly DbConnect _dbConnect;
        private readonly QueryGenerator _queryGenerator;

        public string FilePath { private get; set; }
        public string NameSpaceClasses { private get; set; }
        public string NameSpaceConfig { private get; set; }

        private enum TypeSearchRelationship
        {
            Direct,
            Indirect,
            ManyToMany
        }


        public DbInterpreter(DbConnect dbConnect, QueryGenerator queryGenerator)
        {
            _dbConnect = dbConnect;
            _queryGenerator = queryGenerator;


        }

        internal void GenerateClassFiles(IEnumerable<DataRowView> tables, SetState setState)
        {
            setState("starting...");
            var listTables = new List<ObjectDB>();
            var listSynonyms = new List<ObjectDB>();

            setState("looking for Tables");
            //  Transorm tables to classes, still work to be done
            foreach (var item in tables)
            {
                var typeObj = item?.Row["type"];
                if (typeObj == null) continue;
                var tmp = typeObj.ToString().Trim();
                switch (tmp)
                {
                    case "U":
                    {
                        var tmpO = new ObjectDB(item);
                        listTables.Add(tmpO);
                        break;
                    }
                    case "SN":
                    {
                        var tmpO = new ObjectDB(item);
                        listSynonyms.Add(tmpO);
                        break;
                    }
                }
            }

            if (listTables.Count > 0)
            {
                if (!SearchColumnsByTables(listTables, setState)) return;
            }


            if (listSynonyms.Count > 0)
            {
                if(!SearchSynonyms(listSynonyms, setState)) return;
            }

            setState("done");

        }


        private string GenerateMapper(ObjectDB objectDb, DataTable list, string dbPath = "")
        {
            var fileStr = FileManager.ReadFile(FileManager.GetAppPath + "/Template/TemplateMapper.cs");

            var tmpProperties = new StringBuilder();
            foreach (DataRow row in list.Rows)
            {
                tmpProperties.Append($"     {GenerateMapperProperties(new TableColumns(row))}\r\n");
            }

            var fkList = GetFkRelationShips(objectDb.object_id, TypeSearchRelationship.Direct, dbPath);
            var tmpRelations = new StringBuilder();
            foreach (var item in fkList)
            {
                tmpRelations.Append($"{GenerateMapperRelationShips(objectDb.name, item)}\r\n");
            }

            fkList = GetFkRelationShips(objectDb.object_id, TypeSearchRelationship.ManyToMany, dbPath);
            foreach (var item in fkList)
            {
                if (item.CreateConfig == 1)
                    tmpRelations.Append($"{GenerateMapperRelationShips(objectDb.name, item, true)}\r\n");
            }

            fileStr = fileStr.Replace("{0}", NameSpaceConfig);
            fileStr = fileStr.Replace("{1}", objectDb.name);
            fileStr = fileStr.Replace("{2}", GetPrimaryKey(dbPath, objectDb.name));
            fileStr = fileStr.Replace("{3}", tmpProperties.ToString());
            fileStr = fileStr.Replace("{4}", tmpRelations.ToString());
            fileStr = fileStr.Replace("{5}", "using " + NameSpaceClasses + ";");

            return fileStr;
        }


        private string GenerateMapperRelationShips(string name, FkTable fkTable, bool manyToMany = false)
        {
            string tmpStr;

            if (manyToMany)
            {
                // Many to Many
                if (fkTable.CreateConfig == 0) return "";

                tmpStr = @"            HasMany(x => x.{0})
                            .WithMany(x => x.{1})
                            .Map(m =>
                            {5}
                                m.ToTable(""{2}"");
                                m.MapLeftKey(""{3}"");
                                m.MapRightKey(""{4}"");
                            {6});";

                return string.Format(tmpStr,
                    fkTable.PkTableName,
                    name,
                    fkTable.FkTableName,
                    fkTable.FkColumn,
                    fkTable.PkColumn,
                    "{", "}");
            }
            else
            {
                //  One to Many

                tmpStr = @"            HasRequired(x => x.{0})
                            .WithMany(x => x.{1})
                            .HasForeignKey(d => d.{2});";

                return string.Format(tmpStr,
                    RemoveLast_S(fkTable.PkTableName),
                    name,
                    UppercaseFirst(fkTable.FkColumn));
            }
        }
        /// <summary>
        /// Search all columns by Table
        /// </summary>
        /// <param name="listTables">Tables to read</param>
        private bool SearchColumnsByTables(IEnumerable<ObjectDB> listTables, SetState setState)
        {
            foreach (var table in listTables)
            {
                var dt = _dbConnect.OpenConnectionAndExecute(_queryGenerator.GetTablesByName(table.name));

                var writeClassOk = CreateFile("Classes", table.name + ".cs", GenerateClass(table, dt), setState);
                var writeMapperOk = CreateFile("Mappers", table.name + "Config.cs", GenerateMapper(table, dt), setState);

                if (!writeClassOk || !writeMapperOk) { return false; }
            }

            return true;
        }

        private bool SearchSynonyms(IEnumerable<ObjectDB> listSynonyms, SetState setState)
        {
            foreach (var synonym in listSynonyms)
            {
                // get path from Synonym, to search in the real table.
                var dt = _dbConnect.OpenConnectionAndExecute(_queryGenerator.GetSynonymsByName(synonym.name));
                if (dt.Rows.Count == 1)
                {
                    var fullPathDb = dt.Rows[0]["base_object_name"].ToString();
                    var dbPath = fullPathDb.Replace($".[dbo].[{synonym.name}]", "");

                    //  Get Table
                    dt = _dbConnect.OpenConnectionAndExecute(_queryGenerator.GetSynonymTable(synonym.name, dbPath));
                    synonym.object_id = int.Parse(dt.Rows[0]["object_id"].ToString());

                    //  Get Columns
                    dt = _dbConnect.OpenConnectionAndExecute(_queryGenerator.GetSynonymColums(synonym.name, dbPath));

                    var writeClassOk = CreateFile("Classes", synonym.name + ".cs", GenerateClass(synonym, dt, dbPath + "." ), setState);
                    var writeMapperOk = CreateFile("Mappers", synonym.name + "Config.cs", GenerateMapper(synonym, dt, dbPath + "."), setState);

                    if (!writeClassOk || !writeMapperOk) {return false;}
                }
                else
                {
                    //  Names duplicated ?
                    setState("There are Synonyms tables with the same name.");
                    return false;
                }
            }

            return true;
        }

      private bool CreateFile(string folder, string filename, string value, SetState setState)
        {
            var pathFolder = FilePath + "/" + folder;

            try
            {
                FileManager.CheckExistOrCreate(pathFolder);
            }
            catch (Exception e)
            {
                setState(e.Message);
                return false;
            }

            setState($"Creating File {filename}");
            //  Save file
            var pathFile = pathFolder + "/" + filename;
            FileManager.WriteFile(pathFile, value);
            return true;
        }

        private string GenerateClass(ObjectDB objectDB, DataTable list, string dbPath = "")
        {
            var fileStr = FileManager.ReadFile(FileManager.GetAppPath + "/Template/TemplateClass.cs");

            var tmpProperties = new StringBuilder();
            var tmpRelations = new StringBuilder();
            var tmpConstructRelations = new StringBuilder();

            //  Properties
            foreach (DataRow row in list.Rows)
            {
                tmpProperties.Append("\r\n");
                var tableColumns = new TableColumns(row);
                tmpProperties.Append(string.Format(@"        public {0}{4} {1} {2} get; set; {3}", GetNetType(tableColumns.Type), UppercaseFirst(tableColumns.ColumnName), "{", "}", tableColumns.IsNullable ? "?" : ""));

            }

            FkTable[] fkList = GetFkRelationShips(objectDB.object_id, TypeSearchRelationship.Direct, dbPath);

            //  Related Properties.
            foreach (FkTable item in fkList)
            {
                tmpRelations.Append("\r\n");
                tmpRelations.Append(string.Format(@"        public {0} {3} {1} get; set; {2}", item.PkTableName, "{", "}", RemoveLast_S(item.PkTableName)));
            }


            //  Get Indirect Relationships
            fkList = GetFkRelationShips(objectDB.object_id, TypeSearchRelationship.Indirect, dbPath);
            foreach (FkTable item in fkList)
            {
                tmpRelations.Append("\r\n");
                tmpRelations.Append(string.Format("        public virtual IList<{0}> {0} {1} get; set; {2}\r\n", item.FkTableName, "{", "}"));
                tmpConstructRelations.Append(string.Format("            {0} = new List<{0}>();\r\n", item.FkTableName, "{", "}"));
            }

            //  Many to Many - Tables related
            fkList = GetFkRelationShips(objectDB.object_id, TypeSearchRelationship.ManyToMany, dbPath);
            foreach (var item in fkList)
            {
                tmpRelations.Append(string.Format("        public virtual IList<{0}> {0} {1} get; set; {2}\r\n", item.PkTableName, "{", "}"));
                tmpConstructRelations.Append(string.Format("            {0} = new List<{0}>();\r\n", item.PkTableName, "{", "}"));
            }

            //----------------------------------------------------------------------------------------------



            //  Relationships
            fileStr = fileStr.Replace("{0}", NameSpaceClasses);               //  Namespace
            fileStr = fileStr.Replace("{1}", objectDB.name);                             //  Class Name
            fileStr = fileStr.Replace("{2}", tmpProperties.ToString());         //  Properties  //GetPrimaryKey("",name)
            fileStr = fileStr.Replace("{3}", tmpRelations.ToString());          //  Declaration Relaciones
            fileStr = fileStr.Replace("{4}", tmpConstructRelations.ToString()); //  Inicializacion de las Relaciones

            return fileStr;
        }


        /// <summary>
        /// Generate Property to .Net Files.
        /// </summary>
        /// <param name="tableColumns"></param>
        /// <returns></returns>
        private string GenerateMapperProperties(TableColumns tableColumns)
        {
            StringBuilder property = new StringBuilder();
            property.Append(string.Format(@"            Property(x => x.{1}).HasColumnName(""{0}"")", tableColumns.ColumnName, UppercaseFirst(tableColumns.ColumnName)));
            if (!tableColumns.IsNullable)
                property.Append(".IsRequired()");

            if (GetNetType(tableColumns.Type) == "string")
                property.Append(".IsUnicode(false)");

            property.Append(";");

            property.Append("\r\n");
            return property.ToString();
        }

        /// <summary>
        /// Get .Net property reference
        /// Convert "SQL properties" to ".Net properties"
        /// </summary>
        /// <param name="type">SQL property name</param>
        /// <returns>.net property name</returns>
        private string GetNetType(string type)
        {
            switch (type.Trim().ToLower())
            {
                case "bigint":
                case "int":
                    return "int";

                case "nchar":
                case "nvarchar":
                case "varchar":
                case "char":
                case "text":
                    return "string";

                case "datetime":
                    return "DateTime";

                case "bit":
                    return "bool";
            }
            return type.Trim().ToLower();
        }

        /// <summary>
        /// Convert the first letter in Upper case.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private string UppercaseFirst(string s)
        {
            if (s == string.Empty) return s;

            return s.First().ToString().ToUpper() + s.Substring(1);
        }

        /// <summary>
        /// Remove last "S" from the name and Uppercase first
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private string RemoveLast_S(string s)
        {
            if (s == string.Empty) return s;

            

            var a = s.ToCharArray();
            a[0] = char.ToUpper(a[0]);  //  Uppercase

            return char.ToLower(a[(a.Length - 1)]) == 's' ? new string(a).Substring(0, a.Length - 1) : new string(a);
        }



        /// <summary>
        /// Get PK code to add in .Net Files.
        /// </summary>
        /// <param name="dbPath"></param>
        /// <param name="nameTable"></param>
        /// <returns>Line of code to related Primary Key with the DB/ Se obtiene una linea de codigo, que relaciona la PK en .Net con la DB.</returns>
        private string GetPrimaryKey(string dbPath, string nameTable)
        {
            var strResult = new StringBuilder();

            var dtPk = _dbConnect.OpenConnectionAndExecute(_queryGenerator.GetPrimaryKey(nameTable, dbPath));
            foreach (DataRow item in dtPk.Rows)
            {
                var pk = new PkTable(item);

                /*
                    -- NOTE:
                                None = The database does not generate values.
                                Identity = The database generates a value when a row is inserted.
                                Computed = The database generates a value when a row is inserted or updated.
                 * 
                 * url:
                 * http://entityframework.codeplex.com/SourceControl/changeset/view/a5faddeca2be#src/EntityFramework/DataAnnotations/Schema/DatabaseGeneratedOption.cs
                 */
                strResult.Append(string.Format("            HasKey(x => x.{0}).Property(x => x.{0}).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);\r\n", UppercaseFirst(pk.PkColumn)));
            }
            return strResult.ToString();
        }

        private FkTable[] GetFkRelationShips(int objectId, TypeSearchRelationship relationship, string dbPath = "")
        {
            var query = "";

            switch (relationship)
            {
                case TypeSearchRelationship.Direct:
                    query = _queryGenerator.GetRelationshipDirect(objectId, "parent_object_id", dbPath);
                    break;
                case TypeSearchRelationship.Indirect:
                    query = _queryGenerator.GetRelationshipOneToMany(objectId, dbPath);
                    break;
                case TypeSearchRelationship.ManyToMany:
                    query = _queryGenerator.GetRelationshipManyToMany(objectId, dbPath);
                    break;
            }

            var dtFkRel = _dbConnect.OpenConnectionAndExecute(query) ?? new DataTable();

            var tmpPos = 0;
            var fkTables = new FkTable[dtFkRel.Rows.Count];


            foreach (DataRow item in dtFkRel.Rows)
            {
                var tmpFk = new FkTable(item);
                fkTables[tmpPos] = tmpFk;
                tmpPos++;
            }

            return fkTables;
        }
    }




}
