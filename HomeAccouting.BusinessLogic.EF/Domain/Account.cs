using System;
using System.Collections.Generic;
using System.Text;

namespace HomeAccouting.BusinessLogic.EF.Domain
{
    public class Account : Entity
    {
        public DateTime CreationDate
        {
            get;
            set;

        }

        public string Title
        {
            get; set;

        }

        public decimal Balance
        {
            get;
            set;

        }

        public IEnumerable<Operation> Operations
        {
            get => default;
            set
            {
            }
        }
    }
}