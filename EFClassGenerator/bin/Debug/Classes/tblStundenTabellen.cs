using System;
using System.Collections.Generic;

namespace 
{
    public class tblStundenTabellen
    {
        #region Properties


        public int Id { get; set; }
        public string? Bezeichnung { get; set; }

        public virtual IList<tblStundenDaten> tblStundenDaten { get; set; }


        #endregion Properties



        #region Constructors

        public tblStundenTabellen()
        {
            tblStundenDaten = new List<tblStundenDaten>();

        }

        #endregion Constructors



        #region Public Methods

        #endregion Public Methods



        #region Private Methods

        #endregion Private Methods
    }
}