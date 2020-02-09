using AccountDomainModel.Exceptions;
using ClearBank.DeveloperTest.Data;
using ClearBank.DeveloperTest.Types;
using System.Configuration;

namespace ClearBank.DeveloperTest.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IAccountDataStoreRepository _accountDataStore;

        public PaymentService()
        {
            string dataStoreType = ConfigurationManager.AppSettings["DataStoreType"];

            if (dataStoreType == "Backup")
                _accountDataStore = new BackupAccountDataStore();
            else
                _accountDataStore = new AccountDataStore();
        }

        public MakePaymentResult MakePayment(MakePaymentRequest request)
        {
            var result = new MakePaymentResult();

            var account = _accountDataStore.GetAccount(request.DebtorAccountNumber);

            if(account == null)
            {
                result.Success = false;
                return result;
            }

            try
            {
                account.ChangeBalance(request.Amount, request.PaymentScheme.ToString());
                _accountDataStore.UpdateAccount(account);
            }
            catch (InvalidBalanceChangeException)
            {
                result.Success = false;
            }

            return result;
        }
    }
}
