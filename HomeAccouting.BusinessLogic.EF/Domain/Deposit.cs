using System;
using System.Collections.Generic;
using System.Text;

namespace HomeAccouting.BusinessLogic.EF.Domain
{
    public class Deposit : Account
    {
        public decimal Percent
        {
            get;
            set;

        }

        public string NumberOfBankAccount
        {
            get;
            set;
        }

        public Bank Bank
        {
            get;
            set;
         
        }

        public PercentType Type
        {
            get;
            set;

        }
    }
}