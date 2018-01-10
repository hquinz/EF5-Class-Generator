using System;
using System.Collections.Generic;

namespace 
{
    public class tblRaumLehrfaecher
    {
        #region Properties


        public string Raumnummer { get; set; }
        public string LehrfachKurzbezeichnung { get; set; }


        public tblRaeume TblRaeume { get; set; }
        public tblLehrfaecher TblLehrfaecher { get; set; }

        #endregion Properties



        #region Constructors

        public tblRaumLehrfaecher()
        {

        }

        #endregion Constructors



        #region Public Methods

        #endregion Public Methods



        #region Private Methods

        #endregion Private Methods
    }
}