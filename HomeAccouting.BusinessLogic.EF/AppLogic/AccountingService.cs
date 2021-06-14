using HomeAccounting.BusinessLogic.Contract;
using HomeAccounting.BusinessLogic.Contract.dto;
using HomeAccouting.BusinessLogic.EF.Domain;
using System;
using System.Linq;
using Account = HomeAccouting.BusinessLogic.EF.Domain.Account;

namespace HomeAccouting.BusinessLogic.EF.AppLogic
{
    public class AccountingService : IAccountingService
    {
        DomainContext _ctx;
        public AccountingService(DomainContext ctx)
        {
            _ctx = ctx;
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
        }


        private Account CreateDeposit(AccountModel account)
        {
            var bOld = _ctx.Banks.Where(p => p.Bic == (string)account.Params[0]).FirstOrDefault();

            var d = new Deposit
            {
                Balance = account.Amount,
                CreationDate = DateTime.Now.Date,
                Bank = new Bank()
                {
                    Bic = (string)account.Params[0],
                    CorrAccount = (string)account.Params[1],
                    Title = (string)account.Params[2],
                },
                Title = account.Title,
                Percent = (decimal)account.Params[3]
            };


            _ctx.Deposites.Add(d);
            _ctx.SaveChanges();
            return d;
        }

        private Account CreateProperty(AccountModel account)
        {
            return new Property()
            {
                Balance = account.Amount,
                CreationDate = DateTime.Now,
                Location = "Samara",
                Title = account.Title,
                Type = (PropertyType)account.Params[0]
            };
        }

        private Account CreateCash(AccountModel account)
        {
            return new Cash()
            {
                Title = account.Title,
                Balance = account.Amount,
                CreationDate = DateTime.Now,
                Banknotes = (int)account.Amount/100,
                Monets = (int)account.Amount - (int)account.Amount/100
            };
        }

        private Account CreateSimpleAccount(AccountModel account)
        {
            throw new NotImplementedException();
        }
    }
}
