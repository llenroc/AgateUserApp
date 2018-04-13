using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Agate.Business.Api;
using Agate.Contracts.Models.Account;
using HttpServerMock;
using HttpServerMock.ExtensionMethods;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Android;
using Xamarin.UITest.iOS;
using Xamarin.UITest.Queries;

namespace AgateTests
{
    [TestFixture(Platform.Android)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        //[Test]
        public void AppLaunches()
        {
            app.Screenshot("First screen.");
        }

        //[Test]
        public void Repl()
        {
            app.Repl();
        }

        [Test]
        public void SignUpFlow()
        {
            var ip = "10.0.2.2";   
            uint portNumber = 80;
            using (var apiServer = new HttpServerMock.HttpServerMock(portNumber))
            {
                apiServer.SetUpExpectation(HttpMethod.POST, "/api/v1/account/signup").Response(HttpStatusCode.OK,
                    HttpRequestContentType.Json, new SignUpResponseModel(1));

                app.Invoke("SetServicesAddress", $"http://{ip}:{portNumber}/api/v1/");

                app.EnterText("FirstNameEntry", "Meysam");
                app.DismissKeyboard();
                app.EnterText("LastNameEntry", "Naseri");
                app.DismissKeyboard();
                app.EnterText("MobileNumberEntry", "+61424554644");
                app.DismissKeyboard();
                app.EnterText("EmailEntry", "meysamnaseri@live.com");
                app.DismissKeyboard();
                app.Screenshot("comleted-sign-up-page");

                app.Tap("SignUpButton");
                app.WaitForElement("ConfirmationPage", "Expected to navigate to confirmation page", TimeSpan.FromSeconds(60));
                app.Screenshot("confirmation-page-after-sign-up");

                apiServer
                    .SetUpExpectation(HttpMethod.POST, "/api/v1/account/confirmSignup")
                    .Response(HttpStatusCode.OK, HttpRequestContentType.Json, new ConfirmSignUpResponse(1,"test access code", DateTime.Now.AddDays(1)));

                app.EnterText("ConfirmationCodeEntry", "123456");
                app.DismissKeyboard();

                app.Tap("ConfirmButton");
                app.WaitForElement("SetPinPage", "Expected to navigate to set pin page", TimeSpan.FromSeconds(60));
                app.Screenshot("set-pin-page");
            }
        }
    }
}

