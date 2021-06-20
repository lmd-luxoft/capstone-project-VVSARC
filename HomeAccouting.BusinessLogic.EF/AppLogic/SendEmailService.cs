using HomeAccounting.BusinessLogic.Contract;
using HomeAccounting.BusinessLogic.Contract.dto;
using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace HomeAccouting.BusinessLogic.EF.AppLogic
{
    public class SendEmailService : ISendEmailService
    {
        private readonly IConfiguration _config;
        public SendEmailService(IConfiguration config)
        {
            _config = config;
        
        }
        public async Task<bool> SendEmailMessageAsync(string subject, string text)
        {
            return await Task.Run(() =>
            {
                try
                {
                    var section = _config.GetSection("Mail");
                    var addrFrom = section.GetSection("From").Value;
                    var addrTo = section.GetSection("To").Value;
                    var host = section.GetSection("Host").Value;
                    var port = Convert.ToInt32(section.GetSection("Port").Value);
                    var password = section.GetSection("Password").Value;

                    using (MailMessage mail = new MailMessage())
                    {
                        mail.From = new MailAddress(addrFrom);
                        mail.To.Add(addrTo);
                        mail.Subject = $"{text}";
                        mail.Body = $"<h1>{text}</h1>";
                        mail.IsBodyHtml = true;

                        using (SmtpClient smtp = new SmtpClient(host, port))
                        {
                            smtp.UseDefaultCredentials = true;
                            smtp.Credentials = new NetworkCredential(addrFrom, password);
                            smtp.EnableSsl = true;
                            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                            smtp.Send(mail);
                        }
                    }
                    return true;
                }
                catch (Exception)
                {
                    return false;                
                }
                
            });
        }

    }
}
