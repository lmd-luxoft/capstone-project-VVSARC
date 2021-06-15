using HomeAccounting.BusinessLogic.Contract;
using HomeAccounting.BusinessLogic.Contract.dto;
using HomeAccounting.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HomeAccounting.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAccountingService _accountingService;

        public HomeController(ILogger<HomeController> logger, IAccountingService accountingService)
        {
            _logger = logger;
            _accountingService = accountingService;
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
            _accountingService.CreateAccount(model);
            return Json(new { status = true });
       
        }


    }

}
