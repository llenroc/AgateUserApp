using System.Threading.Tasks;
using Agate.Business.Services;
using Triplezerooo.XMVVM;

namespace Agate.ViewBridge
{
    public class NavigationService : INavigationService
    {
        private readonly INavigationView navigationView;
        private readonly IAppInfo appInfo;

        public NavigationService(INavigationView navigationView, IAppInfo appInfo)
        {
            this.navigationView = navigationView;
            this.appInfo = appInfo;
        }
        public async Task SetCurrentPage(BaseViewModel viewModel)
        {
            var view = ViewModelToViewMapping.ResolvePageForViewModel(viewModel, appInfo.Mode);
            await navigationView.SetCurrentPage(view);
        }
        public async Task Push(BaseViewModel viewModel)
        {
            var view = ViewModelToViewMapping.ResolvePageForViewModel(viewModel, appInfo.Mode);
            await navigationView.Push(view);
        }

        public async Task Pop()
        {
            await navigationView.Pop();
        }

        public async void Replace(BaseViewModel viewModel)
        {
            var view = ViewModelToViewMapping.ResolvePageForViewModel(viewModel, appInfo.Mode);
            await navigationView.Replace(view);
        }
    }
}