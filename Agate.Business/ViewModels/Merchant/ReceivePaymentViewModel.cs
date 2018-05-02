using System;
using System.Collections.Generic;
using System.Text;
using Triplezerooo.XMVVM;

namespace Agate.Business.ViewModels.Merchant
{
    public class ReceivePaymentViewModel : BaseViewModel
    {
        private string amount = "0";

        public string Amount
        {
            get => amount;
            set
            {
                if (amount == value)
                    return;
                amount = value;
                Raise(nameof(Amount));
            }
        }
    }
}
