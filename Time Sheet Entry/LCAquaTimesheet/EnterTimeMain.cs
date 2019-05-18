using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace LCAquaTimesheet
{
    class EnterTimeMain
    {
        static DriverHelper browser = new DriverHelper();

        //each job has a sunday-saturday
        public static string[] hoursInputIdentify = { "//*[@id='TextBox_NewItemSunday']" , "//*[@id='TextBox_NewItemMonday']" , "//*[@id='TextBox_NewItemTuesday']" ,
                        "//*[@id='TextBox_NewItemWednesday']" , "//*[@id='TextBox_NewItemThursday']" , "//*[@id='TextBox_NewItemFriday']" , "//*[@id='TextBox_NewItemSaturday']"};

        //each job has a sunday-saturday for comments 
        public static string[] commentsInputIdentify = { "TextBox_SundayComments", "TextBox_MondayComments", "TextBox_TuesdayComments", "TextBox_WednesdayComments", "TextBox_ThursdayComments", "TextBox_FridayComments", "TextBox_SaturdayComments" };

        public void EnterTime(IWebDriver driver, Range cellRange)
        {
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));

            int rowJobNumber = 3;              //initial row cell value to be read
            double? jobNumber = cellRange.Cells[1][rowJobNumber].value2;      //job number is a double or null

            while (jobNumber != null)   //if there is a job number, enter the job, if empty, assume all have been entered and end the program
            {

                string stringJobNumber = jobNumber.ToString();      //excel reads numbers as doubles, must convert toa string to enter it into timesheet on site
                driver.FindElement(By.XPath("//*[@id='TextBox_JobCode']")).SendKeys(stringJobNumber);       //enters the job number into timesheet

                int arrayPlaceHolder = 0; //cycles through comment and hour element's ids

                for (int hoursPerDayColomn = 2; hoursPerDayColomn <= 8; ++hoursPerDayColomn)       //enter the amount of hours for each day, skip if hours are null, //initial row for hours cell for each day (goes accross sun-sat)
                {
                    EnterHours(driver, cellRange, hoursPerDayColomn, rowJobNumber, arrayPlaceHolder);   //Enterhours
                    EnterComments(driver, cellRange, hoursPerDayColomn, rowJobNumber, arrayPlaceHolder);    //EnterComments

                    ++arrayPlaceHolder; //go to next day, next array place thingy
                }

                //button is broken on site, will not click, tried with python too
                IWebElement button = driver.FindElement(By.XPath("//*[@id='newRowButtons_Add']"));
                button.Click();
                Thread.Sleep(5000);

                //wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='newRowButtons_Add']"))).Click();

                //IWebElement element = driver.FindElement(By.XPath("//*[@id='newRowButtons_Add']"));
                //IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                //js.ExecuteScript("arguments[0].click();", element);
                browser.Wait(driver);
                
                rowJobNumber = rowJobNumber + 2;  //cycles to next job number
                jobNumber = cellRange.Cells[1][rowJobNumber].value2; //go to next job number
            }
        }

        public void EnterHours(IWebDriver driver, Range cellRange, int hoursPerDayColomn, int rowJobNumber, int arrayPlaceHolder)
        {
            double? hoursPerDay = cellRange.Cells[hoursPerDayColomn][rowJobNumber].value2;    //takes hours per day under the same jobnumber

            if (hoursPerDay != null)  //don't enter hours in specific day if cell is null
            {
                string stringHoursNumber = hoursPerDay.ToString();  //must convert double to string in order to enter it in timesheet

                driver.FindElement(By.XPath(hoursInputIdentify[arrayPlaceHolder])).Clear(); //clears textbox, just for precaution
                browser.Wait(driver);
                driver.FindElement(By.XPath(hoursInputIdentify[arrayPlaceHolder])).SendKeys(stringHoursNumber);  //enters the hours for the designated day
                browser.Wait(driver);
            }
        }

        public void EnterComments(IWebDriver driver , Range cellRange, int hoursPerDayColomn, int rowJobNumber, int arrayPlaceHolder)
        {

            string commentsPerDay = cellRange.Cells[hoursPerDayColomn][rowJobNumber + 1].value2;

            if (commentsPerDay != null) //skip if comment box is empty, enter if filled in
            {
                driver.FindElement(By.Id(commentsInputIdentify[arrayPlaceHolder])).Clear();   //clears comment box, just for precaution
                driver.FindElement(By.Id(commentsInputIdentify[arrayPlaceHolder])).SendKeys(commentsPerDay);      //enters the comment for the designated day
            }
        }
    }
        
}
