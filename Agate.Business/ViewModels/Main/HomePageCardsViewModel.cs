using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Agate.Business.AppLogic;
using Agate.Business.LocalData;
using Triplezerooo.XMVVM;
using Xamarin.Forms;

namespace Agate.Business.ViewModels.Main
{
    public class HomePageCardsViewModel : BaseViewModel
    {
        private readonly INavigationService navigationService;
        private bool orderPendingViewIsVisible;
        private bool noCardViewIsVisible;

        public HomePageCardsViewModel(HomePageViewModel parent, INavigationService navigationService)
        {
            this.navigationService = navigationService;
            Parent = parent;
            OrderCardCommand = new Command(async () => await OrderCard());
        }

        public HomePageViewModel Parent { get; }

        public bool NoCardViewIsVisible
        {
            get => noCardViewIsVisible;
            set
            {
                noCardViewIsVisible = value;
                Raise(nameof(NoCardViewIsVisible));
            }
        }

        public bool OrderPendingViewIsVisible
        {
            get => orderPendingViewIsVisible;
            set
            {
                orderPendingViewIsVisible = value;
                Raise(nameof(OrderPendingViewIsVisible));
            }
        }
        public List<CardRowViewModel> List { get; }

        public ICommand OrderCardCommand { get; }
        public async Task OrderCard()
        {
            await navigationService.Push(await UXFlow.DecideOrderCardPage());
        }

        internal async void Update(Card[] cards)
        {
            if (cards == null || !cards.Any())
            {
                var generalInfo = await GeneralData.ReadGeneralInfo();
                if (generalInfo != null && generalInfo.ImpendingCardOrder)
                {
                    OrderPendingViewIsVisible = true;
                }
                else
                {
                    NoCardViewIsVisible = true;
                }
            }
        }
    }
}