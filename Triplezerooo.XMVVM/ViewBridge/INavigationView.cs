using System.Threading.Tasks;
using Xamarin.Forms;

namespace Triplezerooo.XMVVM
{
    public interface INavigationView
    {
        Task SetCurrentPage(Page page);
        Task Push(Page page);
    }
}