using HomeAccounting.BusinessLogic.Contract;
using HomeAccounting.BusinessLogic.Contract.dto;
using HomeAccounting.UI.Models;
using Microsoft.AspNetCore.Mvc;

using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Configuration;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace HomeAccounting.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAccountingService _accountingService;
        private readonly IConfiguration _config;

        public HomeController(ILogger<HomeController> logger, IAccountingService accountingService, IConfiguration config)
        {
            _logger = logger;
            _accountingService = accountingService;
            _config = config;
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult CreateAccount(string Account)
        {
            var model = JsonConvert.DeserializeObject<AccountModel>(Account);
           // _accountingService.CreateAccount(model);

            var task = new Task(() =>
            {
                try
                {
                    var addrFrom = _config.GetValue<string>("Mail:From");
                    var addrTo = _config.GetValue<string>("Mail:To");
                    var host = _config.GetValue<string>("Mail:Host");
                    var port = _config.GetValue<int>("Mail:Port");
                    var password = _config.GetValue<string>("Mail:Password");

                    using (MailMessage mail = new MailMessage())
                    {
                        mail.From = new MailAddress(addrFrom);
                        mail.To.Add(addrTo);
                        mail.Subject = "Account created";
                        mail.Body = $"<h1>Account:{model.Title} создан</h1>";
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
                }
                catch (Exception ex)
                {
                    // Обработки нет
                }
            });

          
            task.Start();                   
            return Json(new { status = true });
       
        }


    }

}
