using AccountDomainModel;
using AccountDomainModel.Enums;

namespace ClearBank.DeveloperTest.Data
{
    public class BackupAccountDataStore: IAccountDataStoreRepository
    {
        public Account GetAccount(string accountNumber)
        {
            // Access backup data base to retrieve account, code removed for brevity 
            return new Account(accountNumber, 10, AccountStatus.Live, AllowedPaymentSchemes.FasterPayments);
        }

        public void UpdateAccount(Account account)
        {
            // Update account in backup database, code removed for brevity
        }
    }
}
