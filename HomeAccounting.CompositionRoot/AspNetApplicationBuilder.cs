using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeAccounting.CompositionRoot
{
    public class AspNetApplicationBuilder : AbstractApplicationBuilder
    {
        public AspNetApplicationBuilder(IServiceCollection services) : base (services)
        {


        }

        protected override void RegisterBuisenessLogic()
        {
            throw new NotImplementedException();
        }

        protected override void RegisterDataSource()
        {
            throw new NotImplementedException();
        }

        protected override void RegisterInfrastructure()
        {
            throw new NotImplementedException();
        }
    }
}
