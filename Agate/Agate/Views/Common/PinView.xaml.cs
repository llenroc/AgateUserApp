using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Agate.Views.Common
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PinView : ContentView
	{
        public PinView()
        {
            InitializeComponent();
            MessageEntry.Text = Message;
        }

        public static readonly BindableProperty MessageProperty =
            BindableProperty.Create(nameof(Message), typeof(string), typeof(PinView), "Enter PIN", BindingMode.TwoWay, null, MessageChanged);

        public string Message
        {
            get => (string)GetValue(MessageProperty);
            set => SetValue(MessageProperty, value);
        }

        private static void MessageChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var me = bindable as PinView;
            if (me == null)
                return;
            me.MessageEntry.Text = (newValue as string) ?? "";
            me.MessageEntry.IsVisible = !string.IsNullOrWhiteSpace(newValue as string);
        }

        public static readonly BindableProperty PinValueProperty =
            BindableProperty.Create(nameof(PinValue), typeof(string), typeof(PinView), null, BindingMode.TwoWay, null, PinValueChanged);

        public string PinValue
        {
            get => (string)GetValue(PinValueProperty);
            set => SetValue(PinValueProperty, value);
        }

	    private static void PinValueChanged(BindableObject bindable, object oldValue, object newValue)
	    {
	        var me = bindable as PinView;
	        if (me == null)
	            return;

            if(string.IsNullOrEmpty(newValue as string))
            {
                foreach (var entry in Enumerable.Range(0, 4).Select(me.GetEntry))
                {
                    entry.Text = "";
                }
            }
	    }

        private void UpdatePinValue() => PinValue = GetCurrentDigits();

	    public static readonly BindableProperty EnterCommandProperty = BindableProperty.Create(nameof(EnterCommand), typeof(ICommand), typeof(PinView), null, BindingMode.TwoWay);

        public ICommand EnterCommand
        {
            get => (ICommand)GetValue(EnterCommandProperty);
            set => SetValue(EnterCommandProperty, (object)value);
        }

        private void InvokeEnterCommand()
        {
            var command = EnterCommand;
            if (command == null || !command.CanExecute(null))
                return;

            command.Execute(null);
        }

        private Entry GetEntry(int index) => (Entry)CodeStackLayout.Children[index];
	    private string GetCurrentDigits() => string.Join("", Enumerable.Range(0, 4).Select(GetEntry).Select(t => t.Text).Where(x => x != null).ToArray());
	    private int CurrentDigitIndex => GetCurrentDigits().Length;

	    public void Handle_Clicked(object sender, EventArgs e)
        {
            var b = (Button)sender;
            if (CurrentDigitIndex <= 3)
            {
                GetEntry(CurrentDigitIndex).Text = b.CommandParameter.ToString();
                UpdatePinValue();
            }

            if (CurrentDigitIndex == 4)
            {
                InvokeEnterCommand();
            }
        }

        public void Handle_Tapped(object sender, EventArgs e)
        {
            if (CurrentDigitIndex > 0)
            {
                GetEntry(CurrentDigitIndex - 1).Text = "";
                UpdatePinValue();
            }
        }
    }
}