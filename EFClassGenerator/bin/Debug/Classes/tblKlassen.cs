using System;
using System.Collections.Generic;

namespace 
{
    public class tblKlassen
    {
        #region Properties


        public int Id { get; set; }
        public int SchuljahrID { get; set; }
        public string Bezeichnung { get; set; }
        public string? Fachbereich { get; set; }
        public tinyint? Jahrgang { get; set; }
        public string? LehrerKurzzeichen { get; set; }
        public int? TurnusKonfigurationID { get; set; }
        public int Gruppen { get; set; }


        public tblLehrer TblLehrer { get; set; }
        public tblSchuljahre TblSchuljahre { get; set; }
        public tblTurnuskonfigurationen TblTurnuskonfigurationen { get; set; }
        public virtual IList<tblKlassenSchueler> tblKlassenSchueler { get; set; }

        public virtual IList<tblKlassenLehrfaecher> tblKlassenLehrfaecher { get; set; }


        #endregion Properties



        #region Constructors

        public tblKlassen()
        {
            tblKlassenSchueler = new List<tblKlassenSchueler>();
            tblKlassenLehrfaecher = new List<tblKlassenLehrfaecher>();

        }

        #endregion Constructors



        #region Public Methods

        #endregion Public Methods



        #region Private Methods

        #endregion Private Methods
    }
}