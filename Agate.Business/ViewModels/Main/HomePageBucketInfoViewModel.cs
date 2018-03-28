using System.ComponentModel;
using Triplezerooo.XMVVM;

namespace Agate.Business.ViewModels.Main
{
    public class HomePageBucketInfoViewModel : BaseViewModel
    {
        private decimal balance;

        public HomePageBucketInfoViewModel()
        {
            
        }

        public void Initialize(HomePageViewModel parent)
        {
            Parent = parent;
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
    }
}