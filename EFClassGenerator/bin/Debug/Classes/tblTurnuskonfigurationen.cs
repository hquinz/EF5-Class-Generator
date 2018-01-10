using System;
using System.Collections.Generic;

namespace 
{
    public class tblTurnuskonfigurationen
    {
        #region Properties


        public int Id { get; set; }
        public string? Bezeichnung { get; set; }
        public string? BerechnungsDLL { get; set; }


        public virtual IList<tblTurnusParameterwertezuordnungen> tblTurnusParameterwertezuordnungen { get; set; }

        public virtual IList<tblKlassen> tblKlassen { get; set; }


        #endregion Properties



        #region Constructors

        public tblTurnuskonfigurationen()
        {
            tblTurnusParameterwertezuordnungen = new List<tblTurnusParameterwertezuordnungen>();
            tblKlassen = new List<tblKlassen>();

        }

        #endregion Constructors



        #region Public Methods

        #endregion Public Methods



        #region Private Methods

        #endregion Private Methods
    }
}