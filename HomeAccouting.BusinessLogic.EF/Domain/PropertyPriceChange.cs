using System;
using System.Collections.Generic;
using System.Text;

namespace HomeAccouting.BusinessLogic.EF.Domain
{
    public class PropertyPriceChange : Entity
    {
        public int Delta
        {
            get;
            set;
        }

        public DateTime RegistationDate
        {
            get;
            set;
        }
    }
}