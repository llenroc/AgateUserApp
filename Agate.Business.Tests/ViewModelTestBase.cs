﻿using System.Diagnostics;
using Agate.Business.AppLogic;
using Agate.Business.Services;
using Moq;
using Plugin.Connectivity.Abstractions;
using Plugin.DeviceInfo.Abstractions;
using Plugin.SecureStorage.Abstractions;
using Triplezerooo.XMVVM;

namespace Agate.Business.Tests
{
    public class ViewModelTestBase
    {
        protected Mock<IDataFlow> dataFlow;
        protected Mock<IView> view;
        protected Mock<IViewService> viewService;
        protected Mock<IDeviceInfo> deviceInfo;
        protected Mock<IConnectivity> connectivity;
        protected Mock<IPhoneService> phoneService;
        protected Mock<ISecureStorage> secureStorage;
        protected Mock<IAppInfo> appInfo;

        public ViewModelTestBase()
        {
            view = new Mock<IView>();
            view
                .Setup(v => v.DisplayAlert(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Callback(
                    (string title, string message, string cancel) =>
                        Debug.WriteLine($"DisplayAlert called : {title} {message}"));


            dataFlow = new Mock<IDataFlow>();

            viewService = new Mock<IViewService>();

            deviceInfo = new Mock<IDeviceInfo>();
            deviceInfo.Setup(m => m.Id).Returns("testdevice");

            connectivity = new Mock<IConnectivity>();
            connectivity.Setup(m => m.IsConnected).Returns(true);

            phoneService = new Mock<IPhoneService>();
            phoneService.SetupAllProperties();

            secureStorage = new Mock<ISecureStorage>();

            appInfo = new Mock<IAppInfo>();
        }
    }
}