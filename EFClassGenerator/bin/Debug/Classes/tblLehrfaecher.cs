using System;
using System.Collections.Generic;

namespace 
{
    public class tblLehrfaecher
    {
        #region Properties


        public string Kurzbezeichnung { get; set; }
        public string? Langbezeichnung { get; set; }
        public int WertigkeitID { get; set; }
        public string? Kompetenzen { get; set; }
        public string? Inhalt { get; set; }


        public tblLehrfachwertigkeiten TblLehrfachwertigkeiten { get; set; }
        public virtual IList<tblKlassenLehrfaecher> tblKlassenLehrfaecher { get; set; }

        public virtual IList<tblLehrfachverteilungen> tblLehrfachverteilungen { get; set; }


        #endregion Properties



        #region Constructors

        public tblLehrfaecher()
        {
            tblKlassenLehrfaecher = new List<tblKlassenLehrfaecher>();
            tblLehrfachverteilungen = new List<tblLehrfachverteilungen>();

        }

        #endregion Constructors



        #region Public Methods

        #endregion Public Methods



        #region Private Methods

        #endregion Private Methods
    }
}