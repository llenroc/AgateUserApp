using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using Triplezerooo.XMVVM;

namespace Triplezerooo.XMVVM
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        private bool isLoading;
        private bool isWorking;
        protected readonly OperationScope WorkingScope;
        protected OperationScope LoadingScope;

        public BaseViewModel() 
        {
            WorkingScope = new OperationScope(() => IsWorking = true, () => IsWorking = false);
            LoadingScope = new OperationScope(() => IsLoading = true, () => IsLoading = false);
        }

        public BaseViewModel(bool isLoading) : this()
        {
            this.isLoading = isLoading;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Raise(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool IsLoading
        {
            get => isLoading;
            set
            {
                isLoading = value;
                Raise(nameof(IsLoading));
                Raise(nameof(IsNotLoading));
                Raise(nameof(IsBusy));
                Raise(nameof(IsNotBusy));
            }
        }

        public bool IsNotLoading
        {
            get => !isLoading;
            set => IsLoading = !value;
        }

        public bool IsWorking
        {
            get => isWorking;
            set
            {
                isWorking = value;
                Raise(nameof(IsWorking));
                Raise(nameof(IsNotWorking));
                Raise(nameof(IsBusy));
                Raise(nameof(IsNotBusy));
            }
        }

        public bool IsNotWorking
        {
            get => !isWorking;
            set => IsWorking = !value;
        }

        public bool IsBusy => IsLoading || IsWorking;

        public bool IsNotBusy => !IsBusy;

        public IView View { get; set; }
    }

    public interface IForm
    {
        void AddProperty(IProperty property);
        List<IProperty> Properties { get; }
    }

    public class Form : INotifyPropertyChanged
    {
        public void AddProperty(IProperty property)
        {

        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public static class FormExtensions
    {
        public static Property<string> AddTextProperty(this IForm form, string name)
        {
            var property = new Property<string>(name);
            form.Properties.Add(property);
            return property;
        }

        public static IProperty AddProperty(this IForm form, IProperty property)
        {
            form.Properties.Add(property);
            return property;
        }
    }
}
