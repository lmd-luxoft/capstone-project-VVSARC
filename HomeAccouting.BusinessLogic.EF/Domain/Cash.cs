using System;
using System.Collections.Generic;
using System.Text;

namespace HomeAccouting.BusinessLogic.EF.Domain
{
    public class Cash : Account
    {
        public int Banknotes
        {
            get;
            set;
        }

        public int Monets
        {
            get;
            set;
        }
    }
}