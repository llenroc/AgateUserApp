using System;
using System.Threading.Tasks;
using Agate.Business.API;
using Agate.Business.LocalData;
using Agate.Business.Services;
using Plugin.SecureStorage.Abstractions;
using Triplezerooo.XMVVM;
using Xamarin.Forms;

namespace Agate.Business.ViewModels.Main
{
    public class OrderNewCardViewModel : BaseViewModel
    {
        private readonly ISecureStorage secureStorage;
        private readonly ICardOrderService cardOrderService;
        private INavigationService navigationService;
        private readonly Func<EditAddressViewModel> createEditAddressViewModel;
        UserAddress[] userAddresses;
        UserAddress shippingAddress;

        public OrderNewCardViewModel(ISecureStorage secureStorage, ICardOrderService cardOrderService, Func<EditAddressViewModel> createEditAddressViewModel)
        {
            this.secureStorage = secureStorage;
            this.cardOrderService = cardOrderService;
            this.createEditAddressViewModel = createEditAddressViewModel;
        }

        public void Initialize(INavigationService navigationService, UserAddress[] userAddresses, UserAddress shippingAddress)
        {
            this.navigationService = navigationService;
            EditCommand = new XCommand(async () => await Edit());
            ConfirmCommand = new XCommand(async () => await Confirm());
            this.userAddresses = userAddresses;
            this.shippingAddress = shippingAddress;

            var addressText = "";
            addressText += $"{shippingAddress.FirstName} {shippingAddress.LastName}";
            addressText += $"{shippingAddress.AddressLine1}" + "\r\n";
            if (!string.IsNullOrEmpty(shippingAddress.AddressLine2))
                addressText += shippingAddress.AddressLine2 + "\r\n";
            addressText += $"{shippingAddress.City}, {shippingAddress.State}";
            addressText += $"{shippingAddress.Country}";
            addressText += $"{shippingAddress.PostCode}";
            Address = addressText;

        }

        public string Address { get; set; }

        public IXCommand EditCommand { get; set; }

        private async Task Edit()
        {
            var editAddressViewModel = createEditAddressViewModel();
            editAddressViewModel.InitiaizeForEdit(navigationService, userAddresses, shippingAddress, null);            
            await navigationService.Push(editAddressViewModel);
        }

        public Command ConfirmCommand { get; set; }

        private async Task Confirm()
        {
            IsWorking = true;
            try
            {
                var result = await cardOrderService.CreateOrder(new Contracts.Models.Cards.OrderCardRequest
                {
                    UserId = secureStorage.GetUserId().Value
                });

                if (result.Success == true)
                {
                    await navigationService.Pop();
                }
            }
            finally
            {
                IsWorking = false;
            }
        }

    }
}