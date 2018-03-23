using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Agate
{
    public class NavigationService
    {
        public static Task BeginInvokeOnMainThreadAsync(Action action)
        {
            TaskCompletionSource<object> completitionSource = new TaskCompletionSource<object>();
            Device.BeginInvokeOnMainThread(() =>
            {
                try
                {
                    action();
                    completitionSource.SetResult(null);
                }
                catch (Exception ex)
                {
                    completitionSource.SetException(ex);
                }
            });
            return completitionSource.Task;
        }
    }
}