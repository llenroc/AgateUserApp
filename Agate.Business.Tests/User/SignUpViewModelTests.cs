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
    public class SignUpViewModelTests : ViewModelTestBase
    {
        [Fact(DisplayName = "Validation check")]
        public void ValidationTest()
        {
            var viewModel = new SignUpPageViewModel(new Mock<IAccountService>().Object, null,  dataFlow.Object, viewService.Object,()=> phoneService.Object, deviceInfo.Object, connectivity.Object)
            {
                View = view.Object,
                FirstName = {Value = ""},
                LastName = {Value = "Smith"},
                MobileNumber = {Value = "+614245373"},
                EmailAddress = {Value = "user@domain.com"}
            };

            Assert.False(viewModel.CanSignUp());

            viewService.Verify(m=>m.SetCurrentPage(It.IsAny<BaseViewModel>()), Times.Never);
        }

        [Fact(DisplayName = "Navigates to confirmation page after sign up")]
        public async Task ShouldNavigateToConfirmationPage()
        {            
            var accountService = new Mock<IAccountService>();
            accountService.Setup(s => s.SignUp(It.IsAny<SignUpRequest>())).ReturnsAsync(new SignUpResponseModel(1)).Verifiable();

            viewService
                .Setup(m => m.SetCurrentPage(It.Is((BaseViewModel p) => p.GetType() == typeof(ConfirmationCodeEntryViewModel))))
                .Verifiable();

            ConfirmationCodeEntryViewModel CreateConfirmationCodeEntryViewModel(int requestId) 
                => new ConfirmationCodeEntryViewModel(requestId, null, null, null, null, null, null);

            var viewModel = new SignUpPageViewModel(accountService.Object, CreateConfirmationCodeEntryViewModel, dataFlow.Object, viewService.Object, () => phoneService.Object, deviceInfo.Object, connectivity.Object)
            {
                View = view.Object,
                FirstName = { Value = "Jhon" },
                LastName = { Value = "Smith" },
                MobileNumber = { Value = "+614245373" },
                EmailAddress = { Value = "user@domain.com" }
            };

            Assert.True(viewModel.CanSignUp());

            await viewModel.SignUp();

            // Assert that there is a naviation call to confirmation page
            viewService.Verify();

            accountService.Verify();
        }
    }
}
