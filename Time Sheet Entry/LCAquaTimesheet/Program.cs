using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using OpenQA.Selenium.Support.UI;

namespace LCAquaTimesheet
{
    class Program
    {
        static DriverHelper browser = new DriverHelper();
        static HideWindow window = new HideWindow();
        static MessageBoxInput inputMessage = new MessageBoxInput();
        static ExcelParts excel = new ExcelParts();
        static EnterTimeMain enter = new EnterTimeMain();
        static ExtraFeatures feature = new ExtraFeatures();
        static LogIn log = new LogIn();
        static void Main(string[] args)
        {
            window.WindowHide();        //hides CMD window
            string timeSheetLocation = @"C:\Users\blang\Desktop\TimeSheetUltimate.xlsx"; //not needed for final
            string userName = "blang";
            string passWord = "Thisisadev!0604";

            Range cellRange = excel.StartExcelInput(timeSheetLocation);
            
            IWebDriver driver = browser.StartBrowser(); //initiates browser and driver variable
           
            log.LogIntoAqua(driver, userName, passWord);

            log.GoToEntryFrame(driver);

            log.EnterWeek(driver, cellRange);

            enter.EnterTime(driver, cellRange);

            //Cannot switch to submit all frame, constant ID change
            //string validateTotal = feature.ValidateHours(cellRange, driver);

            feature.SetApproval(cellRange, driver);

            feature.SignOut(driver);

            driver.Close();

        }
    }
}
