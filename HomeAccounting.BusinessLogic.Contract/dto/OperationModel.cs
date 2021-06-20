using System;
using System.Collections.Generic;
using System.Text;

namespace HomeAccounting.BusinessLogic.Contract.dto
{
    public class OperationModel
    {
        public int DebetAccountId { get; set; }
        public int CreditAccountId { get; set; }
        public decimal Amount { get; set; }
        public DateTime ExecutionDate { get; set; }

        public string Comment { get; set; }
    }
}
