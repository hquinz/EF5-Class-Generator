using System;
using System.Collections.Generic;

namespace 
{
    public class tblAdressen
    {
        #region Properties


        public int Id { get; set; }
        public string? Strasse { get; set; }
        public string? Hausnummer { get; set; }
        public string? Zusatz { get; set; }
        public string? Plz { get; set; }
        public string? Ort { get; set; }
        public string? LandID { get; set; }


        public tblLaender TblLaender { get; set; }
        public virtual IList<tblPersonen> tblPersonen { get; set; }


        #endregion Properties



        #region Constructors

        public tblAdressen()
        {
            tblPersonen = new List<tblPersonen>();

        }

        #endregion Constructors



        #region Public Methods

        #endregion Public Methods



        #region Private Methods

        #endregion Private Methods
    }
}