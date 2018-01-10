using System;
using System.Collections.Generic;

namespace 
{
    public class tblLehrfachverteilungen
    {
        #region Properties


        public int Id { get; set; }
        public int MusterId { get; set; }
        public string LehrfachKurzbezeichnung { get; set; }
        public tinyint? AnzahlStunden { get; set; }


        public tblLehrfaecher TblLehrfaecher { get; set; }
        public tblLehrfachverteilungsmuster TblLehrfachverteilungsmuster { get; set; }

        #endregion Properties



        #region Constructors

        public tblLehrfachverteilungen()
        {

        }

        #endregion Constructors



        #region Public Methods

        #endregion Public Methods



        #region Private Methods

        #endregion Private Methods
    }
}