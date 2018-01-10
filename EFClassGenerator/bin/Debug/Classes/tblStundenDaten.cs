using System;
using System.Collections.Generic;

namespace 
{
    public class tblStundenDaten
    {
        #region Properties


        public int Id { get; set; }
        public time Start { get; set; }
        public int Dauer { get; set; }

        public virtual IList<tblStundenTabellen> tblStundenTabellen { get; set; }


        #endregion Properties



        #region Constructors

        public tblStundenDaten()
        {
            tblStundenTabellen = new List<tblStundenTabellen>();

        }

        #endregion Constructors



        #region Public Methods

        #endregion Public Methods



        #region Private Methods

        #endregion Private Methods
    }
}