using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agate.Business.Api;
using Agate.Business.ViewModels.User;
using Moq;
using Xunit;

namespace Agate.Business.Tests.User
{
    public class SetPinViewModelTests : ViewModelTestBase
    {
        private Mock<IAccountService> accountService;

        public SetPinViewModelTests()
        {
            accountService = new Mock<IAccountService>();
        }

        [Fact(DisplayName = "Validation Test")]
        public void ValidationTest()
        {
            var viewModel = new SetPinViewModel(accountService.Object, viewService.Object, deviceInfo.Object, secureStorage.Object, null);

            Assert.False(viewModel.CanSetPin(), "Set PIN button should be disabled initially");

            viewModel.Pin1.Value = "value 1";
            viewModel.Pin2.Value = "value 2";

            Assert.False(viewModel.CanSetPin(), "If PIN values are not matching Set PIN button should be disabled");

            viewModel.Pin2.Value = "value 1";
            Assert.True(viewModel.CanSetPin(), "Set PIN button should be enabled once two PIN values are entered and matching");
        }

        //[Fact(DisplayName = "Should navigate to home page after PIN is set")]
        //public async Task ShouldNavigateToHomePageWhenPINIsSpecified()
        //{

        //}

    }
}
