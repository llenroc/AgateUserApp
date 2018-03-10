using System;
using System.Collections.Generic;
using System.Text;
using Agate.Business.ViewModels.User;
using Triplezerooo.XMVVM;
using Xamarin.Forms;

namespace Agate.ViewBridge
{
    public class ViewService : IViewService
    {
        public void SetCurrentPage(BaseViewModel viewModel)
        {
            Application.Current.MainPage = ViewModelToViewMapping.ResolvePageForViewModel(viewModel);
        }
    }

    public class ViewModelToViewMapping
    {
        public static Page ResolvePageForViewModel(BaseViewModel viewModel)
        {
            var view = CreateViewBasedOnViewModelType(viewModel);
            view.BindingContext = viewModel;
            viewModel.View = view as IView;
            return view;
        }

        private static Page CreateViewBasedOnViewModelType(BaseViewModel viewModel)
        {
            if (viewModel.GetType() == typeof(SignUpPageViewModel))
            {
                return new SignUpPage();
            }

            throw new Exception($"Implement ResolvePageForViewModel for {viewModel.GetType().Name}");
        }
    }
}
