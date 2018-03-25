using System.Threading.Tasks;
using Triplezerooo.XMVVM;

namespace Agate.Business.AppLogic
{
    public interface IUXFlow
    {
        void DecideOnAppStartPage();
        Task<BaseViewModel> DecideOrderCardPage();
    }
}