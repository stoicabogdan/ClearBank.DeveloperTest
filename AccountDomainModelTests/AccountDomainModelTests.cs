using AccountDomainModel;
using AccountDomainModel.Enums;
using AccountDomainModel.Exceptions;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace AccountDomainModelTests
{
    public class AccountDomainModelTests
    {
        // Valid Test Cases
        [Theory(DisplayName = 
            "GIVEN valid information " +
            "WHEN changing an accounts balance for Faster Payments " +
            "THEN the balance is changed")]
        [MemberData(nameof(ValidBalanceChangesForFasterPayments))]
        public void ChangeBalanceForFasterPayments_ValidInformation_BalanceIsChanged(Account account, decimal amount, decimal expectedResult)
        {
            account.ChangeBalance(amount, AllowedPaymentSchemes.FasterPayments.ToString());

            account.Balance.Should().Be(expectedResult);
        }

        [Theory(DisplayName = 
            "GIVEN valid information " +
            "WHEN changing an accounts balance for Bacs " +
            "THEN the balance is changed")]
        [MemberData(nameof(ValidBalanceChangesForBacs))]
        public void ChangeBalanceForBacs_ValidInformation_BalanceIsChanged(Account account, decimal amount, decimal expectedResult)
        {
            account.ChangeBalance(amount, AllowedPaymentSchemes.Bacs.ToString());

            account.Balance.Should().Be(expectedResult);
        }

        [Theory(DisplayName =
            "GIVEN valid information " +
            "WHEN changing an accounts balance for Chaps " +
            "THEN the balance is changed")]
        [MemberData(nameof(ValidBalanceChangesForChaps))]
        public void ChangeBalanceForChaps_ValidInformation_BalanceIsChanged(Account account, decimal amount, decimal expectedResult)
        {
            account.ChangeBalance(amount, AllowedPaymentSchemes.Chaps.ToString());

            account.Balance.Should().Be(expectedResult);
        }

        //Invalid Test Cases
        [Theory(DisplayName =
           "GIVEN invalid information " +
           "WHEN changing an accounts balance for Faster Payments " +
           "THEN the balance is not changed " +
           "AND an InvalidBalanceChangeException is thrown")]
        [MemberData(nameof(InvalidBalanceChangesForFasterPayments))]
        public void ChangeBalanceForFasterPayments_InvalidInformation_BalanceIsNotChangedAndExceptionIsThrown(
            Account account,
            decimal amount,
            decimal initialBalance,
            AllowedPaymentSchemes requestSchema)
        {
            var exception = Record.Exception(() => account.ChangeBalance(amount, requestSchema.ToString()));

            exception.Should().BeOfType<InvalidBalanceChangeException>();
            account.Balance.Should().Be(initialBalance);
        }

        [Theory(DisplayName =
           "GIVEN invalid information " +
           "WHEN changing an accounts balance for Bacs " +
           "THEN the balance is not changed " +
           "AND an InvalidBalanceChangeException is thrown")]
        [MemberData(nameof(InvalidBalanceChangesForBacs))]
        public void ChangeBalanceForBacs_InvalidInformation_BalanceIsNotChangedAndExceptionIsThrown(
            Account account,
            decimal amount,
            decimal initialBalance,
            AllowedPaymentSchemes requestSchema)
        {
            var exception = Record.Exception(() => account.ChangeBalance(amount, requestSchema.ToString()));

            exception.Should().BeOfType<InvalidBalanceChangeException>();
            account.Balance.Should().Be(initialBalance);
        }

        [Theory(DisplayName =
           "GIVEN invalid information " +
           "WHEN changing an accounts balance for Bacs " +
           "THEN the balance is not changed " +
           "AND an InvalidBalanceChangeException is thrown")]
        [MemberData(nameof(InvalidBalanceChangesForChaps))]
        public void ChangeBalanceForChaps_InvalidInformation_BalanceIsNotChangedAndExceptionIsThrown(
            Account account,
            decimal amount,
            decimal initialBalance,
            AllowedPaymentSchemes requestSchema)
        {
            var exception = Record.Exception(() => account.ChangeBalance(amount, requestSchema.ToString()));

            exception.Should().BeOfType<InvalidBalanceChangeException>();
            account.Balance.Should().Be(initialBalance);
        }

        [Theory(DisplayName =
           "GIVEN invalid information " +
           "WHEN changing an accounts balance for Bacs " +
           "THEN the balance is not changed " +
           "AND an InvalidBalanceChangeException is thrown")]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        [InlineData("Invalid Name")]
        [InlineData("chaps")]
        public void ChangeBalance_InvalidRequestType_BalanceIsNotChangedAndExceptionIsThrown(string requestSchema)
        {
            var initialBalance = 20.0m;
            var account = new Account("123", initialBalance, AccountStatus.Live, AllowedPaymentSchemes.Bacs);

            var exception = Record.Exception(() => account.ChangeBalance(10.0m, requestSchema));

            exception.Should().BeOfType<InvalidBalanceChangeException>();
            account.Balance.Should().Be(initialBalance);
        }


        // Static Valid Test Data
        public static IEnumerable<object[]> ValidBalanceChangesForFasterPayments()
        {
            yield return new object[]
            {
                new Account("123", 12.0m, AccountStatus.Disabled, AllowedPaymentSchemes.FasterPayments),
                10.0m,
                2.0m
            };
            yield return new object[]
            {
                new Account("123", 12.0m, AccountStatus.InboundPaymentsOnly, AllowedPaymentSchemes.FasterPayments),
                10.0m,
                2.0m
            };
            yield return new object[]
            {
                new Account("123", 12.0m, AccountStatus.Live, AllowedPaymentSchemes.FasterPayments),
                10.0m,
                2.0m
            };
            yield return new object[]
            {
                new Account("123", 12.0m, AccountStatus.Live, AllowedPaymentSchemes.FasterPayments),
                -10.0m,
                22.0m
            };
        }

        public static IEnumerable<object[]> ValidBalanceChangesForBacs()
        {
            yield return new object[]
            {
                new Account("123", 12.0m, AccountStatus.Disabled, AllowedPaymentSchemes.Bacs),
                10.0m,
                2.0m
            };
            yield return new object[]
            {
                new Account("123", 12.0m, AccountStatus.InboundPaymentsOnly, AllowedPaymentSchemes.Bacs),
                10.0m,
                2.0m
            };
            yield return new object[]
            {
                new Account("123", 12.0m, AccountStatus.Live, AllowedPaymentSchemes.Bacs),
                10.0m,
                2.0m
            };
            yield return new object[]
            {
                new Account("123", 12.0m, AccountStatus.Disabled, AllowedPaymentSchemes.Bacs),
                -10.0m,
                22.0m
            };
            yield return new object[]
            {
                new Account("123", 10.0m, AccountStatus.Disabled, AllowedPaymentSchemes.Bacs),
                20.0m,
                -10.0m
            };
        }

        public static IEnumerable<object[]> ValidBalanceChangesForChaps()
        {
            yield return new object[]
            {
                new Account("123", 12.0m, AccountStatus.Live, AllowedPaymentSchemes.Chaps),
                10.0m,
                2.0m
            };
            yield return new object[]
            {
                new Account("123", 12.0m, AccountStatus.Live, AllowedPaymentSchemes.Chaps),
                10.0m,
                2.0m
            };
            yield return new object[]
            {
                new Account("123", 12.0m, AccountStatus.Live, AllowedPaymentSchemes.Chaps),
                -10.0m,
                22.0m
            };
            yield return new object[]
            {
                new Account("123", 10.0m, AccountStatus.Live, AllowedPaymentSchemes.Chaps),
                20.0m,
                -10.0m
            };
        }

        // Static Invalid Test Data
        public static IEnumerable<object[]> InvalidBalanceChangesForFasterPayments()
        {
            decimal initialBalance = 12.0m;
            yield return new object[]
            {
                new Account("123", initialBalance, AccountStatus.Disabled, AllowedPaymentSchemes.FasterPayments),
                10.0m,
                initialBalance,
                AllowedPaymentSchemes.Bacs,
            };
            yield return new object[]
            {
                new Account("123", initialBalance, AccountStatus.InboundPaymentsOnly, AllowedPaymentSchemes.FasterPayments),
                10.0m,
                initialBalance,
                AllowedPaymentSchemes.Chaps
            };
            yield return new object[]
            {
                new Account("123", initialBalance, AccountStatus.Live, AllowedPaymentSchemes.FasterPayments),
                20.0m,
                initialBalance,
                AllowedPaymentSchemes.FasterPayments
            };
        }

        public static IEnumerable<object[]> InvalidBalanceChangesForBacs()
        {
            decimal initialBalance = 12.0m;
            yield return new object[]
            {
                new Account("123", initialBalance, AccountStatus.Disabled, AllowedPaymentSchemes.Bacs),
                10.0m,
                initialBalance,
                AllowedPaymentSchemes.FasterPayments,
            };
            yield return new object[]
            {
                new Account("123", initialBalance, AccountStatus.InboundPaymentsOnly, AllowedPaymentSchemes.Bacs),
                10.0m,
                initialBalance,
                AllowedPaymentSchemes.Chaps
            };
        }

        public static IEnumerable<object[]> InvalidBalanceChangesForChaps()
        {
            decimal initialBalance = 12.0m;
            yield return new object[]
            {
                new Account("123", initialBalance, AccountStatus.Live, AllowedPaymentSchemes.Chaps),
                10.0m,
                initialBalance,
                AllowedPaymentSchemes.FasterPayments,
            };
            yield return new object[]
            {
                new Account("123", initialBalance, AccountStatus.Live, AllowedPaymentSchemes.Chaps),
                10.0m,
                initialBalance,
                AllowedPaymentSchemes.Bacs
            };
            yield return new object[]
            {
                new Account("123", initialBalance, AccountStatus.InboundPaymentsOnly, AllowedPaymentSchemes.Chaps),
                10.0m,
                initialBalance,
                AllowedPaymentSchemes.Chaps
            };
            yield return new object[]
            {
                new Account("123", initialBalance, AccountStatus.Disabled, AllowedPaymentSchemes.Chaps),
                10.0m,
                initialBalance,
                AllowedPaymentSchemes.Chaps
            };
        }
    }
}
