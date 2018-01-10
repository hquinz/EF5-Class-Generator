using System;
using System.Collections.Generic;

namespace 
{
    public class tblFreieTage
    {
        #region Properties


        public int SchuljahrID { get; set; }
        public int Id { get; set; }
        public string? Bezeichnung { get; set; }
        public date Anfang { get; set; }
        public date Ende { get; set; }


        public tblSchuljahre TblSchuljahre { get; set; }

        #endregion Properties



        #region Constructors

        public tblFreieTage()
        {

        }

        #endregion Constructors



        #region Public Methods

        #endregion Public Methods



        #region Private Methods

        #endregion Private Methods
    }
}