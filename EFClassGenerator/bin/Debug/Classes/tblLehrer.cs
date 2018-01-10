using System;
using System.Collections.Generic;

namespace 
{
    public class tblLehrer
    {
        #region Properties


        public string Kurzzeichen { get; set; }
        public int PersonID { get; set; }
        public string? Benutzername { get; set; }
        public string? Ordner { get; set; }
        public int? Farbe { get; set; }


        public tblPersonen TblPersonen { get; set; }
        public virtual IList<tblRaeume> tblRaeume { get; set; }

        public virtual IList<tblRaeume> tblRaeume { get; set; }

        public virtual IList<tblRaeume> tblRaeume { get; set; }

        public virtual IList<tblRaeume> tblRaeume { get; set; }

        public virtual IList<tblKlassen> tblKlassen { get; set; }

        public virtual IList<tblKlassenLehrfaecher> tblKlassenLehrfaecher { get; set; }
        public virtual IList<tblLehrfaecher> tblLehrfaecher { get; set; }


        #endregion Properties



        #region Constructors

        public tblLehrer()
        {
            tblRaeume = new List<tblRaeume>();
            tblRaeume = new List<tblRaeume>();
            tblRaeume = new List<tblRaeume>();
            tblRaeume = new List<tblRaeume>();
            tblKlassen = new List<tblKlassen>();
            tblKlassenLehrfaecher = new List<tblKlassenLehrfaecher>();
            tblLehrfaecher = new List<tblLehrfaecher>();

        }

        #endregion Constructors



        #region Public Methods

        #endregion Public Methods



        #region Private Methods

        #endregion Private Methods
    }
}