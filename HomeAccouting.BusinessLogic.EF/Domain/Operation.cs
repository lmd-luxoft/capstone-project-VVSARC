using System;
using System.Collections.Generic;
using System.Text;

namespace HomeAccouting.BusinessLogic.EF.Domain
{
    public class Operation  :Entity
    {
        public DateTime ExecutionDate
        {
            get;
            set;
        }

        public decimal Amount
        {
            get;
            set;
        }

        public Account DebetAccount
        {
            get;
            set;
        }

        public Account CreditAccount
        {
            get;
            set;
        }

        public string Comment
        {
            get;
            set;        
        }
    }
}