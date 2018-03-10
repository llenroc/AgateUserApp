using System.Threading.Tasks;

namespace Triplezerooo.XMVVM
{
    public static class ViewExtensions
    {
        public static async Task DisplayErrorAlert(this IView view, string error)
        {
            await view.DisplayAlert("Error", error, "Ok");
        }
    }
}
