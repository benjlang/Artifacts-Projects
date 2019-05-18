using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using OpenQA.Selenium;

namespace LCAquaTimesheet
{
    class DeleteJobsHelper
    {
        static LogIn login = new LogIn();
        static DriverHelper browser = new DriverHelper();
        public void DeleteAllJobs(IWebDriver driver, Range cellRange)
        {
            string deleteAll = cellRange.Cells[11][4].value2;       //user's decision to delete all in excel sheet (X)

            string amount = driver.FindElement(By.XPath("//*[@id='ctl00_ContentPlaceHolderMain_RadGridTimesheetNew_ctl00']/tfoot/tr[2]/td/table/tbody/tr/td/div[5]/strong[1]")).Text;   //gets the number of jobs entered on the timesheet
            double amountDouble = Convert.ToDouble(amount);     //converts that to a double cuz selenium is married to vars and strings

            if (deleteAll == "X" || deleteAll == "x")       //if the user wants to delete the jobs, then do it
            {
                for (double r = 0; r < amountDouble; ++r)   //for loop that deltes all the amount of jobs present
                {
                    driver.FindElement(By.Id("ctl00_ContentPlaceHolderMain_RadGridTimesheetNew_ctl00_ctl04_DivDelete")).Click(); //hits the red X button on the job
                    browser.Wait(driver);                                                                                       //waits a maximum of 10 seconds the element to load or fail
                    SendKeys.SendWait("{ENTER}");   //gets rid of stupid notification "aRE yoU SUre yOU WAnt tO dElETe iT?"
                    browser.Wait(driver);
                    driver.Navigate().Refresh();    //refreshes the screen for some reason ??

                    login.GoToEntryFrame(driver);           //switches over to timesheet frame

                    login.EnterWeek(driver, cellRange);     //enters the week for timesheet
                }
            }
        }
    }
}
