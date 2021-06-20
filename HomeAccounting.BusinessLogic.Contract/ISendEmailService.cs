using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HomeAccounting.BusinessLogic.Contract
{
    public interface ISendEmailService
    {
        Task<bool> SendEmailMessageAsync(string subject, string text);
       
    }
}
