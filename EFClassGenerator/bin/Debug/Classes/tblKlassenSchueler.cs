using System;
using System.Collections.Generic;

namespace 
{
    public class tblKlassenSchueler
    {
        #region Properties


        public int KlasseID { get; set; }
        public int PersonID { get; set; }
        public tinyint? Gruppe { get; set; }


        public tblPersonen TblPersonen { get; set; }
        public tblKlassen TblKlassen { get; set; }

        #endregion Properties



        #region Constructors

        public tblKlassenSchueler()
        {

        }

        #endregion Constructors



        #region Public Methods

        #endregion Public Methods



        #region Private Methods

        #endregion Private Methods
    }
}