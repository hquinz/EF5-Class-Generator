namespace EFClassGenerator.Helpers
{
    public class QueryGenerator
    {

        public QueryGenerator()
        {
            
        }

        public string GetTablesAndSynonyms => "SELECT * FROM sys.objects WHERE type in ('SN','U') ORDER BY type DESC";

        public string GetTablesByName(string tableName)
        {
            return $"SELECT * FROM INFORMATION_SCHEMA.columns WHERE TABLE_NAME='{tableName}'";

        }

        public string GetSynonymsByName(string synonym)
        {
            return $"SELECT * FROM sys.synonyms WHERE name='{synonym}'";
        }

        public string GetSynonymTable(string synonym, string dbPath)
        {
            return $"SELECT * FROM {dbPath}.sys.objects WHERE name ='{synonym}'";
        }

        public string GetSynonymColums(string synonym, string dbPath)
        {
            return $"SELECT * FROM {dbPath}.INFORMATION_SCHEMA.columns WHERE TABLE_NAME='{synonym}'";
        }



        public string GetPrimaryKey(string tableName, string dbPath)
        {
           //  Query to get the PK from the table
            return $@"SELECT KU.table_name as tablename, column_name as primarykeycolumn
                            FROM {dbPath}INFORMATION_SCHEMA.TABLE_CONSTRAINTS AS TC
                                INNER JOIN {dbPath}INFORMATION_SCHEMA.KEY_COLUMN_USAGE AS KU
                                    ON TC.CONSTRAINT_TYPE = 'PRIMARY KEY' AND TC.CONSTRAINT_NAME = KU.CONSTRAINT_NAME
                                    AND ku.table_name='{tableName}'
                                ORDER BY KU.TABLE_NAME, KU.ORDINAL_POSITION;";
        }

        public string GetRelationshipDirect(int objektId, string reference, string dbPath = "")
        {
            return $@"SELECT  
                        fk.name AS 'FkName',
	                    o1.name 'FkTable',
	                    c1.name 'FkColumn',
	                    o2.name 'PkTable',
	                    c2.name 'PkColumn'
                     FROM 
                        {dbPath}sys.foreign_keys fk
                        INNER JOIN 
                            {dbPath}sys.foreign_key_columns fkc ON fkc.constraint_object_id = fk.object_id

                            --  Obtenemos la relacion con las columans
                        INNER JOIN
                            {dbPath}sys.columns c1 ON fkc.parent_column_id = c1.column_id AND fkc.parent_object_id = c1.object_id
                        INNER JOIN
                            {dbPath}sys.columns c2 ON fkc.referenced_column_id = c2.column_id AND fkc.referenced_object_id = c2.object_id

                        --  Obtenemos la relacion con las Tablas
                        INNER JOIN
	                        {dbPath}sys.objects o1 ON o1.object_id = c1.object_id
                        INNER JOIN
	                        {dbPath}sys.objects o2 ON o2.object_id = c2.object_id
                                        
                        WHERE fk.{reference} = {objektId}";
        }


        public string GetFkRelationShips(int objectId, string dbPath = "")
        {
            return $@"SELECT fk.name 'FkName' ,columnFirst.name 'FkColumn' ,o.name 'PkTable'	,columnRef.name AS 'PkName'
                      FROM {dbPath}sys.foreign_key_columns fkc
                      INNER JOIN {dbPath}sys.objects AS o ON fkc.referenced_object_id = o.object_id
                      INNER JOIN {dbPath}sys.foreign_keys AS fk ON fkc.constraint_object_id = fk.object_id
                      INNER JOIN {dbPath}sys.columns AS columnFirst ON fkc.parent_object_id = columnFirst.object_id AND fkc.parent_column_id = columnFirst.column_id
                      INNER JOIN {dbPath}sys.columns AS columnRef ON fkc.referenced_object_id = columnRef.object_id AND fkc.referenced_column_id = columnRef.column_id
                      WHERE fkc.parent_object_id = {objectId}";
        }


        public string GetRelationshipOneToMany (int objectId, string dbPath = "")
        { 
            return $@"DECLARE @object_id int
                      SELECT @object_id = {objectId}
	
                        --	declare dynamic table to save results
                      DECLARE @FKListRelates TABLE (
	                         idx smallint Primary Key IDENTITY(1,1)
	                         ,name nvarchar(250)
		
	                         ,name_parent nvarchar(250)
	                         ,id_parent int
	                         ,column_parent nvarchar(250)
		
	                         ,name_referenced nvarchar(250)
	                         ,id_referenced int
	                         ,column_referenced nvarchar(250)
                             )

                      DECLARE @ReturnListRelates TABLE (
	                         FkName nvarchar(250)
		
	                         ,FkTable nvarchar(250)
	                         ,FkTableId int
	                         ,FkColumn nvarchar(250)
		
	                         ,PkTable nvarchar(250)
	                         ,PkTableId int
	                         ,PkColumn nvarchar(250)
                             )
	
                      INSERT @FKListRelates
	                    SELECT  
		                    fk.name,
			
		                    o1.name 'name_parent',
		                    fk.parent_object_id 'id_parent',
		                    c1.name 'column_parent',
			
		                    o2.name 'name_referenced',
		                    fk.referenced_object_id 'id_referenced',
		                    c2.name 'column_referenced'
			
	                        FROM {dbPath}sys.foreign_keys fk
		                           INNER JOIN {dbPath}sys.foreign_key_columns fkc ON fkc.constraint_object_id = fk.object_id
		                           INNER JOIN {dbPath}sys.columns c1 ON fkc.parent_column_id = c1.column_id AND fkc.parent_object_id = c1.object_id
		                           INNER JOIN {dbPath}sys.columns c2 ON fkc.referenced_column_id = c2.column_id AND fkc.referenced_object_id = c2.object_id
		                           INNER JOIN {dbPath}sys.objects o1 ON o1.object_id = c1.object_id
		                           INNER JOIN {dbPath}sys.objects o2 ON o2.object_id = c2.object_id
	                               WHERE fk.referenced_object_id = @object_id
		
                      DECLARE @i int, 
	                          @numrows int,
	                          @countColumns int

                      DECLARE @name_parent nvarchar(250)
	                         ,@id_parent int
	                         ,@column_parent nvarchar(250)
	                         ,@name_referenced nvarchar(250)
	                         ,@id_referenced int
	                         ,@column_referenced nvarchar(250)

                      SET @i = 1
                      SET @numrows = (SELECT COUNT(*) FROM @FKListRelates)
	
                      IF @numrows > 0
	                    WHILE (@i <= (SELECT MAX(idx) FROM @FKListRelates))
	                    BEGIN
			
		                    --	go over related tables that and pick them up
		                    SELECT @name_parent = l.name_parent
				                  ,@id_parent = l.id_parent
				                  ,@column_parent = l.column_parent
				                  ,@name_referenced = l.name_referenced
				                  ,@id_referenced = l.id_referenced
				                  ,@column_referenced = l.column_referenced

			                FROM @FKListRelates AS l
			                WHERE idx = @i

			                --	get the number of columns of parent class
			                SELECT @countColumns = count(c.column_id) FROM {dbPath}sys.columns c WHERE c.object_id = @id_parent; 
			                
                            --print( '@name_parent:' + @name_parent + ' - @countColumns: ' + RTRIM( CAST( @countColumns AS nvarchar(30) ) ) ) ;

			                --	having 2 columns gives a possibility that it is many to many
			                IF(@countColumns <> 2)
				                BEGIN
					            --	Aca faltaria averiguar de traer la otra FK que no sea la de arriba para ver si es M-M
                                INSERT @ReturnListRelates
						            SELECT
							            fk.name AS 'FkName',
							            o1.name 'FkTable',
							            fk.parent_object_id 'FkTableId',
							            c1.name 'FkColumn',

							            o2.name 'PkTable',
							            fk.referenced_object_id 'PkTableId',
							            c2.name 'PkColumn'

							            --@column_parent 'PkColumn'

							

						                FROM {dbPath}sys.foreign_keys fk
							                INNER JOIN {dbPath}sys.foreign_key_columns fkc ON fkc.constraint_object_id = fk.object_id
							                INNER JOIN {dbPath}sys.columns c1 ON fkc.parent_column_id = c1.column_id AND fkc.parent_object_id = c1.object_id
							                INNER JOIN {dbPath}sys.columns c2 ON fkc.referenced_column_id = c2.column_id AND fkc.referenced_object_id = c2.object_id
							                INNER JOIN {dbPath}sys.objects o1 ON o1.object_id = c1.object_id
							                INNER JOIN {dbPath}sys.objects o2 ON o2.object_id = c2.object_id
						                WHERE fk.parent_object_id = @id_parent
                                        AND fk.referenced_object_id = @object_id
				                END
								
		                        SET @i = @i + 1

		
	                        END
	                        SELECT * FROM @ReturnListRelates";

        }


        public string GetRelationshipManyToMany(int objectId, string dbPath = "")
        {
            return $@"
                    DECLARE @object_id int
	                SELECT @object_id = {objectId}
	
	                --	Declaramos tabla dinamica para guardar la busqueda
	                DECLARE @FKListRelates TABLE (
		                idx smallint Primary Key IDENTITY(1,1)
		                ,name nvarchar(250)
		
		                ,name_parent nvarchar(250)
		                ,id_parent int
		                ,column_parent nvarchar(250)
		
		                ,name_referenced nvarchar(250)
		                ,id_referenced int
		                ,column_referenced nvarchar(250)
	                )
	
	                INSERT @FKListRelates
		                SELECT  
			                fk.name,
			
			                o1.name 'name_parent',
			                fk.parent_object_id 'id_parent',
			                c1.name 'column_parent',
			
			                o2.name 'name_referenced',
			                fk.referenced_object_id 'id_referenced',
			                c2.name 'column_referenced'
			
		                FROM {dbPath}sys.foreign_keys fk
			                INNER JOIN {dbPath}sys.foreign_key_columns fkc ON fkc.constraint_object_id = fk.object_id
			                INNER JOIN {dbPath}sys.columns c1 ON fkc.parent_column_id = c1.column_id AND fkc.parent_object_id = c1.object_id
			                INNER JOIN {dbPath}sys.columns c2 ON fkc.referenced_column_id = c2.column_id AND fkc.referenced_object_id = c2.object_id
			                INNER JOIN {dbPath}sys.objects o1 ON o1.object_id = c1.object_id
			                INNER JOIN {dbPath}sys.objects o2 ON o2.object_id = c2.object_id
		                WHERE fk.referenced_object_id = @object_id
		
	                DECLARE @i int, 
		                @numrows int,
		                @countColumns int

	                DECLARE @name_parent nvarchar(250)
		                ,@id_parent int
		                ,@column_parent nvarchar(250)
		                ,@name_referenced nvarchar(250)
		                ,@id_referenced int
		                ,@column_referenced nvarchar(250)

	                SET @i = 1
	                SET @numrows = (SELECT COUNT(*) FROM @FKListRelates)
	
	                IF @numrows > 0
		                WHILE (@i <= (SELECT MAX(idx) FROM @FKListRelates))
		                BEGIN
			
			                --	Aca habria q recorer las Tablas que se relacionan y recorer a su ves esas tablas.
			                SELECT @name_parent = l.name_parent
					                ,@id_parent = l.id_parent
					                ,@column_parent = l.column_parent
					                ,@name_referenced = l.name_referenced
					                ,@id_referenced = l.id_referenced
					                ,@column_referenced = l.column_referenced

				                FROM @FKListRelates AS l
				                WHERE idx = @i

				                --	Obtenemos la cantidad de columnas que tiene esa clase padre
				                SELECT @countColumns = count(c.column_id) FROM {dbPath}sys.columns c WHERE c.object_id = @id_parent; 

				                --	Si tiene 2 columnas hay posibilidad de que sea muchos a muchos
				                IF(@countColumns = 2)
					                BEGIN
						                --	Aca faltaria averiguar de traer la otra FK que no sea la de arriba para ver si es M-M
						                SELECT
                                            fk.name AS 'FkName',
                                            fk.parent_object_id 'FkTableId',
	                                        o1.name 'FkTable',
	                                        c1.name 'FkColumn',
                                            fk.referenced_object_id 'PkTableId',
	                                        o2.name 'PkTable',
                                            @column_parent 'PkColumn'
	                                        --c2.name 'PkColumn'

                                            ,CASE 
							                    WHEN fkc.parent_column_id = 2
							                       THEN 1 
							                       ELSE 0 
					                       END as CreateConfig

						                FROM {dbPath}sys.foreign_keys fk
							                INNER JOIN {dbPath}sys.foreign_key_columns fkc 
                                                                ON fkc.constraint_object_id = fk.object_id
                                                                    --AND fkc.parent_column_id = 2
							                INNER JOIN {dbPath}sys.columns c1 ON fkc.parent_column_id = c1.column_id AND fkc.parent_object_id = c1.object_id
							                INNER JOIN {dbPath}sys.columns c2 ON fkc.referenced_column_id = c2.column_id AND fkc.referenced_object_id = c2.object_id
							                INNER JOIN {dbPath}sys.objects o1 ON o1.object_id = c1.object_id
							                INNER JOIN {dbPath}sys.objects o2 ON o2.object_id = c2.object_id
						                WHERE fk.parent_object_id = @id_parent
							                AND fk.referenced_object_id <> @object_id
					                END
								
			                SET @i = @i + 1
		                END";
        }


    }
}
