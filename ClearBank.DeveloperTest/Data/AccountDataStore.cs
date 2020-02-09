using AccountDomainModel;
using AccountDomainModel.Enums;

namespace ClearBank.DeveloperTest.Data
{
    public class AccountDataStore: IAccountDataStoreRepository
    {
        public Account GetAccount(string accountNumber)
        {
            // Access database to retrieve account, code removed for brevity 
            return (Account)null;
        }

        public void UpdateAccount(Account account)
        {
            // Update account in database, code removed for brevity
        }
    }
}
