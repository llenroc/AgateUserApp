using System.Threading.Tasks;

namespace Triplezerooo.XMVVM
{
    public interface IViewModelLifeTime
    {
        Task OnAppearing();
        Task OnDisappearing();
    }
}