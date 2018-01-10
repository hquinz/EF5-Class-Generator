using System;
using System.Collections.Generic;

namespace 
{
    public class tblSchuljahre
    {
        #region Properties


        public int Id { get; set; }
        public string Bezeichnung { get; set; }
        public date Start { get; set; }
        public date Ende { get; set; }
        public date? StartVersetzt { get; set; }
        public date? EndeVersetzt { get; set; }


        public virtual IList<tblFreieTage> tblFreieTage { get; set; }

        public virtual IList<tblKlassen> tblKlassen { get; set; }


        #endregion Properties



        #region Constructors

        public tblSchuljahre()
        {
            tblFreieTage = new List<tblFreieTage>();
            tblKlassen = new List<tblKlassen>();

        }

        #endregion Constructors



        #region Public Methods

        #endregion Public Methods



        #region Private Methods

        #endregion Private Methods
    }
}