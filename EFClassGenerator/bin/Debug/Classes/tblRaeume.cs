using System;
using System.Collections.Generic;

namespace 
{
    public class tblRaeume
    {
        #region Properties


        public string Raumnummer { get; set; }
        public string BezeichnungKurz { get; set; }
        public string? BezeichnungLang { get; set; }
        public string? Kustos1 { get; set; }
        public string? Kustos2 { get; set; }


        public tblLehrer TblLehrer { get; set; }
        public tblLehrer TblLehrer { get; set; }
        public virtual IList<tblKlassenLehrfaecher> tblKlassenLehrfaecher { get; set; }
        public virtual IList<tblLehrfaecher> tblLehrfaecher { get; set; }


        #endregion Properties



        #region Constructors

        public tblRaeume()
        {
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