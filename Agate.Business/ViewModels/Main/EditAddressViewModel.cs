using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Agate.Business.API;
using Agate.Business.LocalData;
using Agate.Business.Services;
using Plugin.SecureStorage.Abstractions;
using Triplezerooo.XMVVM;

namespace Agate.Business.ViewModels.Main
{
    public class EditAddressViewModel : BaseViewModel
    {
        private readonly ISecureStorage secureStorage;
        private readonly IUserAddressesServices userAddressesServices;
        private readonly IUserData userData;
        private INavigationService navigationService;
        UserAddress[] currentAddresses;
        UserAddress currentAddress;
        bool existingAddress;
        private Func<IView, Task> onConfirmAction;

        public EditAddressViewModel(ISecureStorage secureStorage, IUserAddressesServices userAddressesServices, IUserData userData)
        {
            this.secureStorage = secureStorage;
            this.userAddressesServices = userAddressesServices;
            this.userData = userData;
        }

        public void InitializeForNewAddress(INavigationService navigationService, UserAddress[] currentAddresses, Func<IView, Task> onConfirmAction)
        {
            Initialize(navigationService, currentAddresses, new UserAddress() { Type = AddressType.Shipping }, onConfirmAction, true);
        }

        public void InitiaizeForEdit(INavigationService navigationService, UserAddress[] currentAddresses, UserAddress addressToEdit, Func<IView, Task> onConfirmAction)
        {
            Initialize(navigationService, currentAddresses, addressToEdit, onConfirmAction, false);
        }

        private void Initialize(INavigationService navigationService, UserAddress[] currentAddresses, UserAddress addressToEdit, Func<IView, Task> onConfirmAction,
            bool newAddress)
        {
            Title = "Shipping Address";
            FirstName = new Property<string>("First Name").RequiredString("Please enter first name");
            LastName = new Property<string>("Last Name").RequiredString("Please enter last name");
            AddressLine1 = new Property<string>("Address Line 1").RequiredString("Please enter address");
            AddressLine2 = new Property<string>("Address Line 2");
            City = new Property<string>("City").RequiredString("Please enter city");
            Country = new Property<string>("Country").RequiredString("Please enter country");
            PostCode = new Property<string>("Post Code");
            State = new Property<string>("State");

            ConfirmCommand = new XCommand(async () => await Confirm(), CanConfirm);
            ConfirmCommand.SetDependency(this, FirstName, LastName, AddressLine1, AddressLine2, City, State, Country, PostCode);

            this.navigationService = navigationService;
            this.onConfirmAction = onConfirmAction;
            this.currentAddresses = currentAddresses;
            LoadAddressIntoView(addressToEdit);
            existingAddress = !newAddress;
        }

        public string Title { get; set; }
        public Property<string> FirstName { get; set; }
        public Property<string> LastName { get; set; }
        public Property<string> AddressLine1 { get; set; }
        public Property<string> AddressLine2 { get; set; }
        public Property<string> City { get; set; }
        public Property<string> Country { get; set; }
        public Property<string> PostCode { get; set; }
        public Property<string> State { get; set; }

        private void LoadAddressIntoView(UserAddress userAddress)
        {
            currentAddress = userAddress;
            FirstName.Value = userAddress.FirstName;
            LastName.Value = userAddress.LastName;
            AddressLine1.Value = userAddress.AddressLine1;
            AddressLine2.Value = userAddress.AddressLine2;
            City.Value = userAddress.City;
            Country.Value = userAddress.Country;
            PostCode.Value = userAddress.PostCode;
            State.Value = userAddress.State;
        }
        private void ReadAddressFromView(UserAddress currentAddress)
        {
            currentAddress.FirstName = FirstName.Value;
            currentAddress.LastName = LastName.Value;
            currentAddress.AddressLine1 = AddressLine1.Value;
            currentAddress.AddressLine2 = AddressLine2.Value;
            currentAddress.City = City.Value;
            currentAddress.Country = Country.Value;
            currentAddress.PostCode = PostCode.Value;
            currentAddress.State = State.Value;
        }

        private async Task SaveAddress(int userId, bool update, UserAddress addressToUpdate)
        {
            var address = new Contracts.Models.User.UserAddress
            {
                Id = addressToUpdate.Id,
                FirstName = addressToUpdate.FirstName,
                LastName = addressToUpdate.LastName,
                AddressLine1 = addressToUpdate.AddressLine1,
                AddressLine2 = addressToUpdate.AddressLine2,
                City = addressToUpdate.City,
                Country = addressToUpdate.Country,
                PostCode = addressToUpdate.PostCode,
                State = addressToUpdate.State,
                Type = (Contracts.Models.User.AddressType)(int)addressToUpdate.Type,
            };

            if (update)
            {
                var response = await userAddressesServices.Update(userId, address);
            }
            else
            {
                var response = await userAddressesServices.Create(userId, address);
                currentAddress.Id = response.UserAddressId;
            }
        }

        public IXCommand ConfirmCommand { get; set; }
        private bool CanConfirm()
        {
            return IsNotBusy && Validation.Check(FirstName, LastName, AddressLine1, AddressLine2, City, Country, PostCode, State);
        }
        public async Task Confirm()
        {
            try
            {
                if (!CanConfirm())
                    return;
                if (IsBusy)
                    return;
                using (WorkingScope.Enter())
                {
                    ReadAddressFromView(currentAddress);
                    await SaveAddress(secureStorage.GetUserId().Value, existingAddress, currentAddress);

                    if (!existingAddress)
                    {
                        currentAddresses = currentAddresses.Union(new[] { currentAddress }).ToArray();
                    }

                    await userData.SaveUserAddresses((currentAddresses).ToArray());

                    existingAddress = false;
                }

                if (onConfirmAction != null)
                    await onConfirmAction(View);
                else
                    await navigationService.Pop();
            }
            catch (Exception ex)
            {
                await View.DisplayErrorAlert("An error occurred. Please try again." + ex.Message);
            }
        }
    }
}
