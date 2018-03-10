using System.ComponentModel;
using Triplezerooo.XMVVM;

namespace Triplezerooo.XMVVM
{
    public static class CommandManager
    {
        public static IXCommand SetDependency(this IXCommand command, params INotifyPropertyChanged[] properties)
        {
            foreach (var property in properties)
            {
                property.PropertyChanged += (sender, args) => { command.ChangeCanExecute(); };
            }
            return command;
        }
    }
}