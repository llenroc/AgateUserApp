using System;
using Xamarin.Forms;

namespace Triplezerooo.XMVVM
{
    public class XCommand : Command, IXCommand
    {
        public XCommand(Action<object> execute) : base(execute)
        {
        }

        public XCommand(Action<object> execute, Func<object, bool> canExecute) : base(execute, canExecute)
        {
        }

        public XCommand(Action execute) : base(execute)
        {
        }

        public XCommand(Action execute, Func<bool> canExecute) : base(execute, canExecute)
        {
        }
    }
}