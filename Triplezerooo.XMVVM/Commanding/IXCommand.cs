using System.Windows.Input;

namespace Triplezerooo.XMVVM
{
    public interface IXCommand : ICommand
    {
        void ChangeCanExecute();
    }
}