using System;
using System.Collections.Generic;

namespace 
{
    public class tblTurnusParameterWerte
    {
        #region Properties


        public int Id { get; set; }
        public string Wert { get; set; }


        public virtual IList<tblTurnusParameterwertezuordnungen> tblTurnusParameterwertezuordnungen { get; set; }


        #endregion Properties



        #region Constructors

        public tblTurnusParameterWerte()
        {
            tblTurnusParameterwertezuordnungen = new List<tblTurnusParameterwertezuordnungen>();

        }

        #endregion Constructors



        #region Public Methods

        #endregion Public Methods



        #region Private Methods

        #endregion Private Methods
    }
}