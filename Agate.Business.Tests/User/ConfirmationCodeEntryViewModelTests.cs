using System;
using System.Threading.Tasks;
using Agate.Business.Api;
using Agate.Business.ViewModels.User;
using Agate.Contracts.Models.Account;
using Moq;
using Triplezerooo.XMVVM;
using Xunit;

namespace Agate.Business.Tests.User
{
    public class ConfirmationCodeEntryViewModelTests : ViewModelTestBase
    {
        private Mock<IAccountService> accountService;
        private const string ValidCode = "validcode";

        public ConfirmationCodeEntryViewModelTests()
        {
            accountService = new Mock<IAccountService>();

            accountService
                .Setup(m => m.ConfirmSignup(It.Is((ConfirmSignUpRequest request) => request.RequestId == 1 && request.ConfirmationCode == ValidCode)))
                .ReturnsAsync(new ConfirmSignUpResponse(1, "test access code", DateTime.Parse("2018/03/20")));
            accountService
                .Setup(m => m.ConfirmSignup(It.Is((ConfirmSignUpRequest request) => request.RequestId == 1 && request.ConfirmationCode != ValidCode)))
                .ReturnsAsync(new ConfirmSignUpResponse("Invalid confirmation code"));
        }

        [Fact(DisplayName = "Validation Test")]
        public void ValidationTest()
        {
            var viewModel = new ConfirmationCodeEntryViewModel(1, null, accountService.Object, viewService.Object, dataFlow.Object, deviceInfo.Object, connectivity.Object);
            Assert.False(viewModel.CanConfirm(), "Confirm command should be disabled initially");
            viewModel.ConfirmationCode.Value = "87304";
            Assert.True(viewModel.CanConfirm(), "Confirm command should become enabled when confirmation code is entered");
            viewModel.ConfirmationCode.Value = "";
            Assert.False(viewModel.CanConfirm(), "Confirm command should become disabled when confirmation code is not entered");
        }    

        [Fact(DisplayName = "Should show error message when entered invalid confirmation code")]
        public async Task ShouldShowErrorMessageWhenEnteredInvalidConfirmationCode()
        {
            view
                .Setup(m=>m.DisplayAlert("Invalid Code", "Invalid confirmation code", "Ok"))
                .Returns(Task.CompletedTask)
                .Verifiable("Expected to show an error message when confirmation code is invalid");

            var viewModel = new ConfirmationCodeEntryViewModel(1, null, accountService.Object, viewService.Object, dataFlow.Object, deviceInfo.Object, connectivity.Object);
            viewModel.View = view.Object;
            viewModel.ConfirmationCode.Value = "an invalid confirmation code";
            await viewModel.Confirm();

            view.Verify();
            dataFlow.VerifyNoOtherCalls();
            viewService.VerifyNoOtherCalls();
        }

        [Fact(DisplayName = "Should navigate to Set PIN page when entered valid confirmation page")]
        public async Task ShouldNavigateToSetPINPageWhenEnteredValidConfirmationCode()
        {
            viewService
                .Setup(m => m.SetCurrentPage(It.Is((BaseViewModel p) => p.GetType() == typeof(SetPinViewModel))))
                .Verifiable();
            SetPinViewModel CreateSetPinView() => new SetPinViewModel(null,null,null,null,null);
            var viewModel = new ConfirmationCodeEntryViewModel(1, CreateSetPinView, accountService.Object, viewService.Object, dataFlow.Object, deviceInfo.Object, connectivity.Object);
            viewModel.View = view.Object;
            viewModel.ConfirmationCode.Value = ValidCode;
            await viewModel.Confirm();

            viewService.Verify();
        }
    }
}
