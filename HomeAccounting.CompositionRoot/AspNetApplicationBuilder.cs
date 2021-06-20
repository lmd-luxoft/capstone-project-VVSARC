using HomeAccounting.BusinessLogic;
using HomeAccounting.BusinessLogic.Contract;
using HomeAccounting.DataSource;
using HomeAccounting.DataSource.Contract;
using HomeAccouting.BusinessLogic.EF.AppLogic;
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
            _services.AddDbContext<DomainContext>();
           //_services.AddTransient<IAccounting, AccountingService>();
             _services.AddTransient< IAccountingService, HomeAccouting.BusinessLogic.EF.AppLogic.AccountingService>();
            _services.AddTransient<ISendEmailService, SendEmailService>();
        }

        protected override void RegisterDataSource()
        {
            _services.AddTransient<IRepository, RepositoryBaseMsSql>();
            
        }

        protected override void RegisterInfrastructure()
        {
            //throw new NotImplementedException();
        }
    }
}
