using System;
using System.Collections.Generic;

namespace 
{
    public class tblLehrfachverteilungsmuster
    {
        #region Properties


        public int Id { get; set; }
        public string? Fachbereich { get; set; }
        public tinyint? Jahrgang { get; set; }


        public virtual IList<tblLehrfachverteilungen> tblLehrfachverteilungen { get; set; }


        #endregion Properties



        #region Constructors

        public tblLehrfachverteilungsmuster()
        {
            tblLehrfachverteilungen = new List<tblLehrfachverteilungen>();

        }

        #endregion Constructors



        #region Public Methods

        #endregion Public Methods



        #region Private Methods

        #endregion Private Methods
    }
}