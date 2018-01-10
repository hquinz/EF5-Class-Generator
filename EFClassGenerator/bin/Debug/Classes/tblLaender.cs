using System;
using System.Collections.Generic;

namespace 
{
    public class tblLaender
    {
        #region Properties


        public string Id { get; set; }
        public string? Bezeichnung { get; set; }


        public virtual IList<tblAdressen> tblAdressen { get; set; }


        #endregion Properties



        #region Constructors

        public tblLaender()
        {
            tblAdressen = new List<tblAdressen>();

        }

        #endregion Constructors



        #region Public Methods

        #endregion Public Methods



        #region Private Methods

        #endregion Private Methods
    }
}