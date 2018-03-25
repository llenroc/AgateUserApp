namespace Triplezerooo.XMVVM
{
    public interface IViewService
    {
        void SetCurrentPage(BaseViewModel viewModel);
        INavigationService CreateNavigationService(INavigationView view);
    }
}