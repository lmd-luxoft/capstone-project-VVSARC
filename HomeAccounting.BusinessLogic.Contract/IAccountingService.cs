using HomeAccounting.BusinessLogic.Contract.dto;
using System.Collections.Generic;

namespace HomeAccounting.BusinessLogic.Contract
{
    public interface IAccountingService
    {
        void CreateAccount(AccountModel account);
        void CreateOperation(OperationModel operation);

        IEnumerable<AccountInfoModel> GetAccounts();
    }
}
