using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LCAquaTimesheet
{
    class DriverHelper
    {
        public IWebDriver StartBrowser()
        {
            ChromeOptions options = new ChromeOptions();            //establishing options variable
            options.AddArguments("--disable-extensions");           // to disable extension
            options.AddArguments("--disable-notifications");        // to disable notification
            options.AddArguments("--disable-application-cache");    // to disable cache
            //options.AddArguments("headless");

            IWebDriver driver = new ChromeDriver(options);           //starts chrome browser

            return driver;                                           //returns driver variable 
        }

        public void Wait(IWebDriver driver)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); //wait maximum of 10 secs or fail (implicitly wait)
        }

        public void ReloadWait(IWebDriver driver)       //temporary note: loop to get rid of chrome notification
            //must find something to verify that the notification is gone
        {
            SendKeys.SendWait("{ENTER}");
        }
       
    }
}
