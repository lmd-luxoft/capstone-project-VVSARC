using System;
using System.Collections.Generic;
using System.Text;

namespace HomeAccounting.DataSource.Contract
{
    public class DBAccount
    {
        public int AccountID { get; set; }
        public DateTime CreationDate { get; set; }
        public string Title { get; set; }
    }
}
