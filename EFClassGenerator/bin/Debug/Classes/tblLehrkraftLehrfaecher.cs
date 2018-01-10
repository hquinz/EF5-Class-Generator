using System;
using System.Collections.Generic;

namespace 
{
    public class tblLehrkraftLehrfaecher
    {
        #region Properties


        public string LehrerKurzzeichen { get; set; }
        public string LehrfachKurzbezeichnung { get; set; }


        public tblLehrer TblLehrer { get; set; }
        public tblLehrfaecher TblLehrfaecher { get; set; }

        #endregion Properties



        #region Constructors

        public tblLehrkraftLehrfaecher()
        {

        }

        #endregion Constructors



        #region Public Methods

        #endregion Public Methods



        #region Private Methods

        #endregion Private Methods
    }
}