using System;
using System.Collections.Generic;
using System.Text;

namespace HomeAccouting.BusinessLogic.EF.Domain
{
    public class Property : Account
    {
        public int BaseState
        {
            get;
            set;         
        }

        public string Location
        {
            get;
            set;
        }

        public IEnumerable<PropertyPriceChange> PropertyPriceChanges
        {
            get;
            set;
        }

        public PropertyType Type
        {
            get;
            set;
        }

   
    }
}