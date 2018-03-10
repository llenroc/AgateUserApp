using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Triplezerooo.XMVVM
{
    public interface IView
    {
        //INavigation Navigation { get; }
        Task DisplayAlert(string title, string message, string cancel);
    }

    public interface IViewService
    {
        void SetCurrentPage(BaseViewModel viewModel);
    }

    //public interface INavigation
    //{

    //}

    
}
