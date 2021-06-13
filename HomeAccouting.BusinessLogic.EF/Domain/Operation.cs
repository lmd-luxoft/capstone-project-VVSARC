using System;
using System.Collections.Generic;
using System.Text;

namespace HomeAccouting.BusinessLogic.EF.Domain
{
    public class Operation  :Entity
    {
        public int ExecutionDate
        {
            get => default;
            set
            {
            }
        }

        public decimal Amount
        {
            get => default;
            set
            {
            }
        }

        public IEnumerable<Account> Accounts
        {
            get => default;
            set
            {
            }
        }
    }
}