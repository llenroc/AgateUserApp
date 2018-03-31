using System.Threading.Tasks;
using Triplezerooo.XMVVM;

namespace Agate.ViewBridge
{
    public class NavigationService : INavigationService
    {
        private readonly INavigationView navigationView;

        public NavigationService(INavigationView navigationView)
        {
            this.navigationView = navigationView;
        }
        public async Task SetCurrentPage(BaseViewModel viewModel)
        {
            var view = ViewModelToViewMapping.ResolvePageForViewModel(viewModel);
            await navigationView.SetCurrentPage(view);
        }
        public async Task Push(BaseViewModel viewModel)
        {
            var view = ViewModelToViewMapping.ResolvePageForViewModel(viewModel);
            await navigationView.Push(view);
        }

        public async Task Pop()
        {
            await navigationView.Pop();
        }

        public async void Replace(BaseViewModel viewModel)
        {
            var view = ViewModelToViewMapping.ResolvePageForViewModel(viewModel);
            await navigationView.Replace(view);
        }
    }
}