using System;
using System.Collections.Generic;

namespace 
{
    public class tblStundenZuordnung
    {
        #region Properties


        public int TabelleID { get; set; }
        public int DatenID { get; set; }


        public tblStundenDaten TblStundenDaten { get; set; }
        public tblStundenTabellen TblStundenTabellen { get; set; }

        #endregion Properties



        #region Constructors

        public tblStundenZuordnung()
        {

        }

        #endregion Constructors



        #region Public Methods

        #endregion Public Methods



        #region Private Methods

        #endregion Private Methods
    }
}