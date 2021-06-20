
using HomeAccounting.BusinessLogic.Contract;
using HomeAccounting.BusinessLogic.Contract.dto;
using HomeAccouting.BusinessLogic.EF.Domain;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Json;
using Account = HomeAccouting.BusinessLogic.EF.Domain.Account;

namespace HomeAccouting.BusinessLogic.EF.AppLogic
{
    public class AccountingService : IAccountingService
    {
        DomainContext _ctx;
        ISendEmailService _sendEmailService;
        public AccountingService(DomainContext ctx, ISendEmailService sendEmailService)
        {
            _ctx = ctx;
            _sendEmailService = sendEmailService;
        }

        public void CreateAccount(AccountModel account)
        {
            Account newAccount = null;
            switch (account.Type)
            {
                case AccountType.Simple:
                    newAccount = CreateSimpleAccount(account);
                    break;

                case AccountType.Cash:
                    newAccount = CreateCash(account);
                    break;
                case AccountType.Property:
                    newAccount = CreateProperty(account);
                    break;
                case AccountType.Deposit:
                    newAccount = CreateDeposit(account);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("bad type account");

            }
            _ctx.Accounts.Add(newAccount);
            _ctx.SaveChangesAsync().ContinueWith((prev) =>
            {
   
                _sendEmailService.SendEmailMessageAsync($"HomeAccounting: создание счета",
                                                        $"Создан счет {newAccount.Title}, остаток {newAccount.Balance.ToString()}").ContinueWith((p)=> {
                    var result = p.Result;

                });


            });

        }


        private Account CreateDeposit(AccountModel account)
        {
            var bank = _ctx.Banks.Where(p => p.Bic == account.Params[0].ToString()).FirstOrDefault();
            if (bank == null)
                bank = new Bank()
                {
                    Bic = account.Params[0].ToString(),
                    CorrAccount = account.Params[1].ToString(),
                    Title = account.Params[2].ToString()
                };


            var d = new Deposit
            {
                Balance = account.Amount,
                CreationDate = DateTime.Now.Date,
                Bank = bank,
                Title = account.Title,
                Percent = Convert.ToDecimal(account.Params[3].ToString(), CultureInfo.InvariantCulture),
                Type = (PercentType)Convert.ToInt32(account.Params[4].ToString()),
                NumberOfBankAccount = account.Params[5].ToString()

            };

            //_ctx.Deposites.Add(d);
            return d;
        }

        private Account CreateProperty(AccountModel account)
        {
            return new Property()
            {
                Balance = account.Amount,
                CreationDate = DateTime.Now,
                Title = account.Title,
                Type = (PropertyType)Convert.ToInt32(account.Params[0]),
                Location = account.Params[1].ToString(),
                BaseState = Convert.ToInt32(account.Params[2])

            };
        }

        private Account CreateCash(AccountModel account)
        {
            return new Cash()
            {
                Title = account.Title,
                Balance = account.Amount,
                CreationDate = DateTime.Now,
                Banknotes = Convert.ToInt32(account.Params[0]),
                Monets = Convert.ToInt32(account.Params[1])
            };
        }

        private Account CreateSimpleAccount(AccountModel account)
        {
            throw new NotImplementedException();
        }

        public void CreateOperation(OperationModel operation)
        {
            var op = CreateAccountOperation(operation);
            _ctx.Operations.Add(op);
            _ctx.SaveChangesAsync().ContinueWith((prev) =>
            {
                _sendEmailService.SendEmailMessageAsync($"HomeAccounting: операция", $"Дебет {op.DebetAccount.Title}, Кредит {op.CreditAccount.Title}, Сумма {op.Amount.ToString(CultureInfo.InvariantCulture)}");
               
            }).ContinueWith((prev)=> { 
            
            // обработка ошибки отправки почты
            });
        }

        

        public Operation CreateAccountOperation(OperationModel operation)
        {
            var debetAccount = _ctx.Accounts.FirstOrDefault(prop => prop.Id == operation.DebetAccountId);
            debetAccount.Balance -= operation.Amount;
            var creditAccount = _ctx.Accounts.FirstOrDefault(prop => prop.Id == operation.CreditAccountId);
            creditAccount.Balance += operation.Amount;
            return new Operation()
            {
                DebetAccount = debetAccount,
                CreditAccount = creditAccount,
                Amount = operation.Amount,
                ExecutionDate = operation.ExecutionDate,
                Comment = operation.Comment
            };
        }

        public IEnumerable<AccountInfoModel> GetAccounts()
        {
            var list = new List<AccountInfoModel>();
            foreach (var account in _ctx.Accounts)
                list.Add(new AccountInfoModel() { Id = account.Id, Title = account.Title });
            return list.AsEnumerable();
        }
    }
}
