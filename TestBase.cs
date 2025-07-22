using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestStack.White;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace ScreenShots
{
    public class TestBase
    {
        public Application application = null;
        public Window window = null;

        [TestInitialize]
        public void SetUp()
        {
            application = Application.Launch(@"D:\App\NewProGUI.exe");
            var windows = application.GetWindows();
            window = windows.Find(x => x.Name == "");
        }

        public void screenshot(string fileName)
        {
            Thread.Sleep(500);
            string filePath = $@"D:\App\SCREENSHOTS\Chinese_GUI_ScreenShots\{fileName}_{DateTime.Now:yyyyMMdd_HHmmss}.png";
            Bitmap screenshot = window.VisibleImage;
            screenshot.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
            Console.WriteLine($"Screenshot saved: {filePath}");
        }

        public void Login()
        {
            Button loginPasswordDigits = window.Get<Button>(SearchCriteria.ByAutomationId("").AndIndex(0));  //// Index 0 gives the password 111111
            for (int a = 0; a < 6; a++)
            {
                loginPasswordDigits.Click();
                Thread.Sleep(750);
            }
            Button LoginButton = window.Get<Button>(SearchCriteria.ByAutomationId("LoginOKButton"));
            LoginButton.Click();
            Thread.Sleep(2000);
        }

        public void returnFromHPTreatments()
        {
            Button ReturnBtn = window.Get<Button>(SearchCriteria.ByAutomationId(""));
            ReturnBtn.Click();
            Thread.Sleep(2000);
        }

        public void ClickOnScreen(int offsetX, int offsetY)
        {
            if (window == null) throw new InvalidOperationException("Window not initialized!");

            // Calculate the new mouse location relative to the window
            System.Windows.Point newLocation = new System.Windows.Point(window.Bounds.X + offsetX, window.Bounds.Y + offsetY);

            // Move the mouse and perform the click
            Mouse.Instance.Location = newLocation;
            Mouse.Instance.Click();
            Thread.Sleep(2000); // Optional delay to stabilize UI interaction
        }

        [TestCleanup]
        public void TearDown()
        {
            application?.Close();
        }
    }
}
