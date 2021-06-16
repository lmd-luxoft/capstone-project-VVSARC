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
            _ctx.Accounts.Add(newAccount);
            _ctx.SaveChangesAsync();
        }


        private Account CreateDeposit(AccountModel account)
        {
            var bank = _ctx.Banks.Where(p => p.Bic == (string)account.Params[0]).FirstOrDefault();
            if (bank == null)
                bank = new Bank()
                {
                    Bic = (string)account.Params[0],
                    CorrAccount = (string)account.Params[1],
                    Title = (string)account.Params[2]
                };
             var d = new Deposit
            {
                Balance = account.Amount,
                CreationDate = DateTime.Now.Date,
                Bank = bank,
                Title = account.Title,
                Percent =  Convert.ToDecimal(account.Params[3]),
                Type = (PercentType) Convert.ToInt32(account.Params[4]),
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
    }
}
