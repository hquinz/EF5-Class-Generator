using System;
using System.Collections.Generic;

namespace 
{
    public class tblKlassenLehrfaecher
    {
        #region Properties


        public int Id { get; set; }
        public int KlasseID { get; set; }
        public string LehrfachKurzzeichen { get; set; }
        public tinyint? Tag { get; set; }
        public tinyint? StundeStart { get; set; }
        public tinyint? AnzahlStunden { get; set; }
        public string? LehrerKurzzeichen { get; set; }
        public string? Raumnummer { get; set; }


        public tblLehrer TblLehrer { get; set; }
        public tblRaeume TblRaeume { get; set; }
        public tblLehrfaecher TblLehrfaecher { get; set; }
        public tblKlassen TblKlassen { get; set; }
        public virtual IList<tblLehrfachSchuelerNoten> tblLehrfachSchuelerNoten { get; set; }


        #endregion Properties



        #region Constructors

        public tblKlassenLehrfaecher()
        {
            tblLehrfachSchuelerNoten = new List<tblLehrfachSchuelerNoten>();

        }

        #endregion Constructors



        #region Public Methods

        #endregion Public Methods



        #region Private Methods

        #endregion Private Methods
    }
}