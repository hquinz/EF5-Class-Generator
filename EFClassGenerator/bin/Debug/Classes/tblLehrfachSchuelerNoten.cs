using System;
using System.Collections.Generic;

namespace 
{
    public class tblLehrfachSchuelerNoten
    {
        #region Properties


        public int KlassenLehrfachID { get; set; }
        public int PersonID { get; set; }
        public string? Note { get; set; }


        public tblPersonen TblPersonen { get; set; }
        public tblKlassenLehrfaecher TblKlassenLehrfaecher { get; set; }

        #endregion Properties



        #region Constructors

        public tblLehrfachSchuelerNoten()
        {

        }

        #endregion Constructors



        #region Public Methods

        #endregion Public Methods



        #region Private Methods

        #endregion Private Methods
    }
}