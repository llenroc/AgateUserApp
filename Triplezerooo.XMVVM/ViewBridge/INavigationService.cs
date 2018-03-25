using System.Threading.Tasks;

namespace Triplezerooo.XMVVM
{
    public interface INavigationService
    {
        Task Push(BaseViewModel viewModel);
    }
}