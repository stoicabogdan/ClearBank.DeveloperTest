using System;
using System.Runtime.Serialization;

namespace AccountDomainModel.Exceptions
{
    internal class InvalidBalanceChangeException : Exception
    {
        public InvalidBalanceChangeException(string accountNumber) : base(GenerateExceptionMessage(accountNumber))
        {
        }

        public InvalidBalanceChangeException(string accountNumber, Exception innerException) : base(GenerateExceptionMessage(accountNumber), innerException)
        {
        }

        protected InvalidBalanceChangeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        private static string GenerateExceptionMessage(string accountNumber) =>
            $"Invalid balance change request for user with account number: {accountNumber}";
    }
}
