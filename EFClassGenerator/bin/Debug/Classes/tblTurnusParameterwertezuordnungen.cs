using System;
using System.Collections.Generic;

namespace 
{
    public class tblTurnusParameterwertezuordnungen
    {
        #region Properties


        public int TurnuskonfigurationID { get; set; }
        public int TurnusparameterID { get; set; }
        public int WertID { get; set; }


        public tblTurnuskonfigurationen TblTurnuskonfigurationen { get; set; }
        public tblTurnusParameter TblTurnusParameter { get; set; }
        public tblTurnusParameterWerte TblTurnusParameterWerte { get; set; }

        #endregion Properties



        #region Constructors

        public tblTurnusParameterwertezuordnungen()
        {

        }

        #endregion Constructors



        #region Public Methods

        #endregion Public Methods



        #region Private Methods

        #endregion Private Methods
    }
}