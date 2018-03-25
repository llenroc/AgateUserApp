using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Triplezerooo.XMVVM
{
    public interface IView
    {
        Task DisplayAlert(string title, string message, string cancel);
    }
}
