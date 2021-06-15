using Dapper;
using HomeAccounting.DataSource.Contract;
using System.Data.SqlClient;

namespace HomeAccounting.DataSource
{
    public class RepositoryBaseMsSql : IRepository
    {

        private readonly string _connectionString = "Data Source=DESKTOP-CMIGEHE;Initial Catalog=HomeAccounting;Integrated Security=True;";
        public void AddAccount(DBAccount account)
        {
            using (SqlConnection db = new SqlConnection(_connectionString))
            {

             account.AccountID = db.QuerySingle<int>("insert into Accounts (CreationDate,Title) values(@CreationDate,@Title); select cast(scope_identity() as int)", account);

            }
   
        }

        public DBAccount GetAccountById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
