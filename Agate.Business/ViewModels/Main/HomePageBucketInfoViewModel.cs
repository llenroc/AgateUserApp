using System;
using System.ComponentModel;
using Triplezerooo.XMVVM;

namespace Agate.Business.ViewModels.Main
{
    public class HomePageBucketInfoViewModel : BaseViewModel
    {
        private INavigationService navigationService;
        private readonly Func<BucketHomeViewModel> createBucketHomeViewModel;
        private decimal balance;

        public HomePageBucketInfoViewModel(Func<BucketHomeViewModel> createBucketHomeViewModel)
        {
            this.createBucketHomeViewModel = createBucketHomeViewModel;
        }

        public void Initialize(HomePageViewModel parent, INavigationService navigationService)
        {
            Parent = parent;
            this.navigationService = navigationService;
            TransferToCardCommand = new XCommand(TransferToCard);
        }

        public decimal Balance
        {
            get => balance;
            set
            {
                if (value == balance)
                    return;
                balance = value;
                Raise(nameof(Balance));
            }
        }

        public HomePageViewModel Parent { get; set; }

        public IXCommand TransferToCardCommand { get; set; }

        public void TransferToCard()
        {
            var bucketHomeViewModel = createBucketHomeViewModel();
            //bucketHomeViewModel.Initialize(defaultCard);
            navigationService.Push(bucketHomeViewModel);
        }
    }
}