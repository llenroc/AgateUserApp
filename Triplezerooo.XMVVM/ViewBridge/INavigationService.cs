using System.Threading.Tasks;

namespace Triplezerooo.XMVVM
{
    public interface INavigationService
    {
        Task SetCurrentPage(BaseViewModel viewModel);
        Task Push(BaseViewModel viewModel);
    }
}