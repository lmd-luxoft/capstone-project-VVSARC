using System;
using System.Collections.Generic;
using System.Text;

namespace HomeAccouting.BusinessLogic.EF.Domain
{
    public class Bank :Entity
    {
        public string Bic
        {
            get;
            set;
    
        }

        public string CorrAccount
        {
            get;
            set;
    
        }

        public string Title
        {
            get;
            set;
       
        }
    }
}