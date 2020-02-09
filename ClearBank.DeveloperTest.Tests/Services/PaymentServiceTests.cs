using AccountDomainModel;
using AccountDomainModel.Enums;
using ClearBank.DeveloperTest.Data;
using ClearBank.DeveloperTest.Services;
using ClearBank.DeveloperTest.Types;
using FluentAssertions;
using Moq;
using Xunit;

namespace ClearBank.DeveloperTest.Tests.Services
{
    // If dependency injection is implemented, some example test would be:

    //public class PaymentServiceTests
    //{
    //    private readonly Mock<IAccountDataStoreRepository> _accountDataStore;
    //    private readonly PaymentService _paymentService;

    //    public PaymentServiceTests()
    //    {
    //        _accountDataStore = new Mock<IAccountDataStoreRepository>();

    //        _paymentService = new PaymentService(_accountDataStore.Object);
    //    }

    //    [Fact(DisplayName =
    //        "GIVEN a valid request " +
    //        "WHEN making a payment request " +
    //        "THEN the result success is true")]
    //    public void MakePayment_ValidRequest_ResultIsSuccessful()
    //    {
    //        var account = new Account("123", 10.0m, AccountStatus.Live, AllowedPaymentSchemes.FasterPayments);
    //        _accountDataStore.Setup(ads => ads.GetAccount(It.IsAny<string>()))
    //            .Returns(account);

    //        var request = new MakePaymentRequest();
    //        request.Amount = 5;
    //        request.DebtorAccountNumber = "123";
    //        request.PaymentScheme = PaymentScheme.FasterPayments;

    //        var result = _paymentService.MakePayment(request);

    //        result.Success.Should().BeTrue();
    //        _accountDataStore.Verify(ads => ads.UpdateAccount(It.Is<Account>(a => a.AccountNumber == account.AccountNumber && a.Balance == 5)), Times.Once);
    //    }

    //    [Fact(DisplayName =
    //       "GIVEN account is null " +
    //       "WHEN making a payment request " +
    //       "THEN the result success is false")]
    //    public void MakePayment_AccountIsNull_ResultIsNotSuccessful()
    //    {
    //        _accountDataStore.Setup(ads => ads.GetAccount(It.IsAny<string>()))
    //            .Returns((Account)null);

    //        var request = new MakePaymentRequest();
    //        request.Amount = 5;
    //        request.DebtorAccountNumber = "123";
    //        request.PaymentScheme = PaymentScheme.FasterPayments;

    //        var result = _paymentService.MakePayment(request);

    //        result.Success.Should().BeFalse();
    //    }
    //}

}
