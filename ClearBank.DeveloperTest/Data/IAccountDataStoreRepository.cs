using AccountDomainModel;

namespace ClearBank.DeveloperTest.Data
{
    public interface IAccountDataStoreRepository
    {
        Account GetAccount(string accountNumber);
        void UpdateAccount(Account account);
    }
}
