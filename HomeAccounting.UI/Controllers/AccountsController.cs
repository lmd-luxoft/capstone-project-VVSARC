using HomeAccounting.BusinessLogic.Contract;
using HomeAccounting.BusinessLogic.Contract.dto;
using HomeAccounting.UI.Models;
using HomeAccouting.BusinessLogic.EF.AppLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeAccounting.UI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase

    {
        private IAccountingService _service;

        public AccountsController(IAccountingService accountingService)
        {
            _service = accountingService;
        }

        public void Post([FromBody] BusinessLogic.Contract.dto.AccountModel value)
        {       
            _service.CreateAccount(value);
        }

        // GET: api/<OperationsController>
        [HttpGet]
        public IEnumerable<AccountInfoModel> Get()
        {
 
            return _service.GetAccounts();
        }
       
    }
}
