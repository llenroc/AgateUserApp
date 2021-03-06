﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agate.Business.AppLogic;
using Agate.Business.API;
using Agate.Business.LocalData;
using Agate.Business.Services;
using Microsoft.AppCenter.Crashes;
using Plugin.Connectivity.Abstractions;
using Plugin.SecureStorage.Abstractions;
using Triplezerooo.XMVVM;
using Xamarin.Forms;

namespace Agate.Business.ViewModels.Main
{
    public class OrderNewCardViewModel : BaseViewModel
    {
        private readonly ISecureStorage secureStorage;
        private readonly IConnectivity connectivity;
        private readonly ICardOrderService cardOrderService;
        private readonly ICardData cardData;
        private readonly IAppData appData;
        private INavigationService navigationService;
        private readonly Func<EditAddressViewModel> createEditAddressViewModel;
        UserAddress[] userAddresses;
        UserAddress shippingAddress;

        public OrderNewCardViewModel(ISecureStorage secureStorage, IConnectivity connectivity, ICardOrderService cardOrderService, ICardData cardData, IAppData appData, Func<EditAddressViewModel> createEditAddressViewModel)
        {
            this.secureStorage = secureStorage;
            this.connectivity = connectivity;
            this.cardOrderService = cardOrderService;
            this.cardData = cardData;
            this.appData = appData;
            this.createEditAddressViewModel = createEditAddressViewModel;
        }

        public void Initialize(INavigationService navigationService, UserAddress[] userAddresses, UserAddress shippingAddress)
        {
            this.navigationService = navigationService;
            EditCommand = new XCommand(async () => await Edit(), CanEdit);
            ConfirmCommand = new XCommand(async () => await Confirm(), CanConfirm);
            this.userAddresses = userAddresses;
            this.shippingAddress = shippingAddress;

            var addressText = "";
            addressText += $"{shippingAddress.FirstName} {shippingAddress.LastName}" + "\r\n";
            addressText += $"{shippingAddress.AddressLine1}" + "\r\n";
            if (!string.IsNullOrEmpty(shippingAddress.AddressLine2))
                addressText += shippingAddress.AddressLine2 + "\r\n";
            addressText += $"{shippingAddress.City}, {shippingAddress.State} {shippingAddress.Country}" + "\r\n";
            addressText += $"{shippingAddress.PostCode}";
            Address = addressText;
        }

        public string Address { get; set; }

        public IXCommand EditCommand { get; set; }

        public bool CanEdit() => IsNotBusy;
        public async Task Edit()
        {
            var editAddressViewModel = createEditAddressViewModel();
            editAddressViewModel.InitiaizeForEdit(navigationService, userAddresses, shippingAddress, null);
            await navigationService.Push(editAddressViewModel);
        }

        public Command ConfirmCommand { get; set; }

        public bool CanConfirm() => IsNotBusy;
        public async Task Confirm()
        {
            try
            {
                if (!connectivity.IsConnected)
                {
                    await View.DisplayAlert("...", "Internet connection required", "Ok");
                    return;
                }

                Contracts.Models.Cards.OrderCardResponse result;
                using (WorkingScope.Enter())
                {
                    result = await cardOrderService.CreateOrder(new Contracts.Models.Cards.OrderCardRequest
                    {
                        UserId = secureStorage.GetUserId().Value
                    });
                }
                if (result.Success == true)
                {
                    appData.Cards = appData.Cards.Union(new[] {new Card {State = CardState.Ordered, Id = -1, Name = "Order Pending"}}).ToArray();
                    await cardData.SaveCards(appData.Cards);

                    await navigationService.Pop();
                }
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex, new Dictionary<string, string>
                {
                    {"page", "home page"},
                    {"operation", $"{nameof(OrderNewCardViewModel)}.{nameof(Confirm)}"}
                });
                await View.DisplayAlert("Error", "An error occurred while processing your request" + ex, "Ok");
            }

        }

    }
}