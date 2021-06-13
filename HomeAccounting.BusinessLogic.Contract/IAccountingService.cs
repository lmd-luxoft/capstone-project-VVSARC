using HomeAccounting.BusinessLogic.Contract.dto;

namespace HomeAccounting.BusinessLogic.Contract
{
    public interface IAccountingService
    {
        void CreateAccount(AccountModel account);
    }
}
