using HomeAccounting.BusinessLogic.Contract;
using HomeAccounting.DataSource.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeAccounting.BusinessLogic
{
    public class AccountingService : IAccounting
    {
        private IRepository _repo;
        public AccountingService(IRepository repo)
        {
            _repo = repo;
        }

        public void CreateContract(Account account)
        {
            DBAccount dto = MapEntityToDto(account);
            _repo.AddAccount(dto);
        }
        public   Account GetAccountById(int Id)
        {
            throw new NotFiniteNumberException();
        }
 
        public void SaveAccout(Account account)
        {
            throw new NotImplementedException();
        }

        public static DBAccount MapEntityToDto(Account account)
        {
            DBAccount dto = new DBAccount();
            dto.Title = account.Title;
            dto.CreationDate = account.CreationDate;
            dto.AccountID = account.Id;
            return dto;
        }

        public void CreteAccount()
        {
            throw new NotImplementedException();
        }

        public void CreteAccount(Account account)
        {
            _repo.AddAccount(MapEntityToDto(account)); //  throw new NotImplementedException();
        }
    }
}
