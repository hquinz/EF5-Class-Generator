using System;
using System.Collections.Generic;

namespace 
{
    public class tblPersonen
    {
        #region Properties


        public int Id { get; set; }
        public string? Vorname { get; set; }
        public string Nachname { get; set; }
        public int? AdresseID { get; set; }
        public string? Tel1 { get; set; }
        public string? Tel2 { get; set; }
        public string? Email { get; set; }
        public date? Geburtstag { get; set; }
        public date? Eintritt { get; set; }
        public date? Austritt { get; set; }


        public tblAdressen TblAdressen { get; set; }
        public virtual IList<tblLehrer> tblLehrer { get; set; }

        public virtual IList<tblKlassenSchueler> tblKlassenSchueler { get; set; }

        public virtual IList<tblLehrfachSchuelerNoten> tblLehrfachSchuelerNoten { get; set; }


        #endregion Properties



        #region Constructors

        public tblPersonen()
        {
            tblLehrer = new List<tblLehrer>();
            tblKlassenSchueler = new List<tblKlassenSchueler>();
            tblLehrfachSchuelerNoten = new List<tblLehrfachSchuelerNoten>();

        }

        #endregion Constructors



        #region Public Methods

        #endregion Public Methods



        #region Private Methods

        #endregion Private Methods
    }
}