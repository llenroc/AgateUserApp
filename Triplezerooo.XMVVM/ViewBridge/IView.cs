using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Triplezerooo.XMVVM
{
    public interface IView
    {
        Task DisplayAlert(string title, string message, string cancel);
    }
}
