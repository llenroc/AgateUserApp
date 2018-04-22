using System;
using System.Collections.Generic;
using System.Text;

namespace Agate.Business.Services
{
    public interface IAppInfo
    {
        AppMode Mode { get; }
        string AppName { get; }
    }

    public enum AppMode
    {
        User,
        Merchant
    }
}
