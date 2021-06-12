using System;
using System.Collections.Generic;
using System.Text;

namespace HomeAccouting.BusinessLogic.EF.Domain
{
    public class Property : Account
    {
        public int BaseState
        {
            get => default;
            set
            {
            }
        }

        public string Location
        {
            get => default;
            set
            {
            }
        }

        public IEnumerable<PropertyPriceChange> PropertyPriceChanges
        {
            get => default;
            set
            {
            }
        }

        public PropertyType Type
        {
            get => default;
            set
            {
            }
        }

   
    }
}