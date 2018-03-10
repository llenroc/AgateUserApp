using System;
using System.Collections.Generic;
using System.Text;

namespace OpalApp.Services
{
    public interface IDevice
    {
        string GetDeviceId(); // todo : this one or Plugin.DeviceInfo.CrossDeviceInfo.Current.Id
        string GetPhoneNumber();
    }
}
