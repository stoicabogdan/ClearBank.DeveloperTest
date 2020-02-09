using AccountDomainModel.Enums;
using AccountDomainModel.Exceptions;
using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ClearBank.DeveloperTest")]
[assembly: InternalsVisibleTo("AccountDomainModelTests")]
[assembly: InternalsVisibleTo("ClearBank.DeveloperTest.Tests")]
namespace AccountDomainModel
{
    public class Account
    {
        public string AccountNumber { get; private set; }
        public decimal Balance { get; private set; }
        public AccountStatus Status { get; private set; }
        public AllowedPaymentSchemes AllowedPaymentSchemes { get; private set; }

        public Account(
            string accountNumber,
            decimal balance,
            AccountStatus accountStatus,
            AllowedPaymentSchemes allowedPaymentSchemes)
        {
            AccountNumber = accountNumber;
            Balance = balance;
            Status = accountStatus;
            AllowedPaymentSchemes = allowedPaymentSchemes;
        }

        public void ChangeBalance(decimal amount, string requestPaymentScheme)
        {
            if (!CanChangeBalance(amount, requestPaymentScheme))
                throw new InvalidBalanceChangeException(AccountNumber);

            Balance -= amount;
        }

        private bool CanChangeBalance(decimal amount, string requestPaymentScheme)
        {
            var validEnum = Enum.TryParse(requestPaymentScheme, out AllowedPaymentSchemes result);

            if (!validEnum)
                return false;

            switch (result)
            {
                case AllowedPaymentSchemes.FasterPayments:
                    return AllowedPaymentSchemes.HasFlag(result) && Balance > amount;
                case AllowedPaymentSchemes.Bacs:
                    return AllowedPaymentSchemes.HasFlag(result);
                case AllowedPaymentSchemes.Chaps:
                    return AllowedPaymentSchemes.HasFlag(result) && Status == AccountStatus.Live;
                default:
                    return false;
            }
        }
    }    
}
