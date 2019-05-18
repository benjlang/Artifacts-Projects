using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Microsoft.Office.Interop.Excel;
using OpenQA.Selenium.Support.UI;
using System.Windows.Forms;

namespace LCAquaTimesheet
{
    class LogIn
    {
        static DriverHelper browser = new DriverHelper();
        public void LogIntoAqua(IWebDriver driver, string userName, string passWord)
        {
            driver.Navigate().GoToUrl("https://time.laughlin.com/webvantage/SignIn.aspx");      //goes to Aqua/Laughlin site
            browser.Wait(driver);                                                               //waits a maximum of 10 secondsfor element to load before failing

            driver.FindElement(By.Id("RadWindowSignIn_C_TextBoxUserID")).Clear();                               //clears the username textbox on the site
            browser.Wait(driver);
            driver.FindElement(By.Id("RadWindowSignIn_C_TextBoxUserID")).SendKeys(userName);                    //enters username on the site
            browser.Wait(driver);

            driver.FindElement(By.XPath("//*[@id='RadWindowSignIn_C_TextBoxPassword']")).Clear();               //clears password tectbox on the site
            browser.Wait(driver);
            driver.FindElement(By.XPath("//*[@id='RadWindowSignIn_C_TextBoxPassword']")).SendKeys(passWord);    //enters the password on the site
            browser.Wait(driver);

            driver.FindElement(By.Id("RadWindowSignIn_C_ButtonLogin")).Click();                                 //clicks the submit button on the site
            browser.Wait(driver);

        }

        public void GoToEntryFrame(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));

            driver.FindElement(By.Id("ImageApps")).Click();                                             //clicks the button to get to get to navigation bar
            browser.Wait(driver);                                                                       //waits a maximum of 10 secondsfor element to load before failing

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='RadTreeViewApps']/ul/li[2]/div/span[3]")));
            driver.FindElement(By.XPath("//*[@id='RadTreeViewApps']/ul/li[2]/div/span[3]")).Click();    //clicks on the timesheet button in navigation bar
            browser.Wait(driver);

            driver.FindElement(By.XPath("//*[@id='RadTreeViewApps']/ul/li[2]/ul/li[2]/div/span[2]")).Click();                                   //clicks on the "employee" button with timesheet tab (button)
            browser.Wait(driver);

            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//*[@id='RadWindowWrapper_Timesheet']/table/tbody/tr[2]/td[2]/iframe")));      //switches web controlling to timesheet entry frame
        }

        public void EnterWeek(IWebDriver driver, Range cellRange)
        {
            string chooseDate = cellRange.Cells[10][3].value2;                                                                       //retireves cell value for the week in exce input file
            

            if (chooseDate != null)         //if the user decides to enter a specific week, then enter it from the cell to the week textbox on the site
            {
                var replacements = new[]{                               //getting rid of '*' because excel is dumb (will oter wise read date as a double, not a string)
                            new{Find="*",Replace =""}, };

                foreach (var set in replacements)
                {
                    chooseDate = chooseDate.Replace(set.Find, set.Replace);     //replaces the '*'
                }

                driver.FindElement(By.XPath("//*[@id='ctl00_ContentPlaceHolderMain_RadDatePickerStartDate_dateInput']")).Clear();       //clears week textbox on the site
                browser.Wait(driver);
                SendKeys.SendWait("{ENTER}");
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("//*[@id='ctl00_ContentPlaceHolderMain_RadDatePickerStartDate_dateInput']")).SendKeys(chooseDate);      //enters the specific week
                browser.Wait(driver);
                driver.FindElement(By.XPath("//*[@id='ctl00_ContentPlaceHolderMain_RadDatePickerStartDate_dateInput']")).SendKeys("\n");            //enters the week using enter key
                browser.Wait(driver);
            }
           // else      //if the user decide to use the current week, then take today's date and enter it into the week textbox on the site
           // {
           //     driver.FindElement(By.XPath("//*[@id='ctl00_ContentPlaceHolderMain_RadDatePickerStartDate_dateInput']")).SendKeys(DateTime.Now.ToString("MM-dd-yyyy"));     //sends current date to week textbox
           //     browser.Wait(driver);
           //     driver.FindElement(By.XPath("//*[@id='ctl00_ContentPlaceHolderMain_RadDatePickerStartDate_dateInput']")).SendKeys("\n");                                    //enters the week using enter key
           //     browser.Wait(driver);
           // }
        }
    }
}
