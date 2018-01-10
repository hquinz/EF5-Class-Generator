using System;
using System.Collections.Generic;

namespace 
{
    public class tblLehrfachwertigkeiten
    {
        #region Properties


        public int Id { get; set; }
        public string Bezeichnung { get; set; }
        public float Werteinheit { get; set; }


        public virtual IList<tblLehrfaecher> tblLehrfaecher { get; set; }


        #endregion Properties



        #region Constructors

        public tblLehrfachwertigkeiten()
        {
            tblLehrfaecher = new List<tblLehrfaecher>();

        }

        #endregion Constructors



        #region Public Methods

        #endregion Public Methods



        #region Private Methods

        #endregion Private Methods
    }
}