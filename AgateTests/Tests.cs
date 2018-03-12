using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Android;
using Xamarin.UITest.iOS;
using Xamarin.UITest.Queries;

namespace AgateTests
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
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

        [Test]
        public void AppLaunches()
        {
            app.Screenshot("First screen.");
        }

        [Test]
        public void Repl()
        {
            app.Repl();
        }

        [Test]
        public void SignUpRedirectsUserToConfirmationPage()
        {
            app.EnterText("FirstNameEntry", "Meysam");
            app.DismissKeyboard();
            app.EnterText("LastNameEntry", "Naseri");
            app.DismissKeyboard();
            app.EnterText("MobileNumberEntry", "+61424556544");
            app.DismissKeyboard();
            app.EnterText("EmailEntry","meysamnaseri@live.com");
            app.DismissKeyboard();
            app.Screenshot("comleted-sign-up-page");
            app.DismissKeyboard();
            app.Tap("SignUpButton");
            app.WaitForElement("ConfirmationPage", "Expected to navigate to confirmation page",
                TimeSpan.FromSeconds(60));
            app.Screenshot("confirmation-page-after-sign-up");
        }
    }
}

