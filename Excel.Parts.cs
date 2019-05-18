using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using excelOutput = Microsoft.Office.Interop.Excel;
using excelInput = Microsoft.Office.Interop.Excel;
using System.Reflection;
using Microsoft.Office.Core;
using System.Diagnostics;
using OpenQA.Selenium;

namespace Facebook.Ad.Scraper
{
    class ExcelHelper
    {
        BrowserDriver browser = new BrowserDriver();                   //gets class BrowserDriver

        public static excelOutput.Application excelApplicationOuput;   //new application for the ouput books
        //public static excelOutput.Workbook excelWorkbookOuput;       //initializing book/file for output
        //public static excelOutput.Worksheet excelWorkSheetOutput;    //initializing sheet within book/file for ouput

        public static string exeLocal = @"L:\Dept Admin\Media\Media\Social\PPI Competitive";   //retrieving path of executable path
        //public static string exeLocal = @"C:\Users\blang\Desktop";   //retrieving path of executable path
        public static string file = exeLocal + @"\InputData.xlsx";                       //adding file name to path

        //Reason for all global: need range to be for other functions, all other declarations are dragged in as well
        public static excelInput.Application excelApplicationInput = new excelInput.Application();              //new application for the input book
        public static excelInput.Workbook excelWorkbookInput = excelApplicationInput.Workbooks.Open(file);      //retrieving file
        public static excelInput.Worksheet excelWorksheetInput = excelWorkbookInput.Sheets[1];                  //determinig which sheet to use
        public excelInput.Range excelRangeInput = excelWorksheetInput.UsedRange;                                //initializing range of cells on sheet

        public static int ROW_INITIAL = 2; //inital row value for looping cell inputs

        public static string excel = "Excel";                   //Task Manager name for excel programs
        public static string chromeDriver = "chromedriver";    //Task manger name for the chrome driver.exe, not browser

        //Purpose: Holds like a lot of variables to make life easier for variable transfer in functions
        public struct InputInfo //put in seperate file
        {
            public string userName;         //username of user for facebook.com
            public string passWord;         //password for user for facebook.com
            public double amountOfPosts;    //amount of posts to capture/record
            public string url;              //url of the facebook page
            public string excelFilePath;    //location of the excel file to put images in

        }

        //Purpose: to pair variables to excel cell locations, give all variables (initial) value
        public InputInfo ExcelInputBook()
        {
            var inputInfo = new InputInfo
            {
                userName = excelRangeInput.Cells[1][2].value2,                  //gets value from cell colomn 1, row 2, for username
                passWord = excelRangeInput.Cells[2][2].value2,                  //gets value from cell colomn 2, row 2, for password
                amountOfPosts = excelRangeInput.Cells[7][2].value2,             //gets value from cell colomn 7, row 2, for amount of posts screenshotted
                url = excelRangeInput.Cells[4][ROW_INITIAL].value2,             //gets first cell value, just for initalization
                excelFilePath = excelRangeInput.Cells[6][ROW_INITIAL].value2    //gets first cell value, just for initialization
            };
          
            return inputInfo;                                                   //returns the whole skew of variables
        }

        //Purpose: To create a new sheet, name it the date/time, initialize sheet
        public  Tuple<Worksheet, Workbook> CreatingOuputWorksheet(string excelFilePath)
        {
            excelApplicationOuput = null;                                //must do, do not ask why
            excelApplicationOuput = new excelOutput.Application();       // create Excell App
            excelApplicationOuput.DisplayAlerts = false;                 // turn off alerts

            excelOutput.Workbook excelWorkbookOuput = (Workbook)(excelApplicationOuput.Workbooks.Open(excelFilePath));  // open the existing excel file 

            //takes newest sheet (1)
            excelOutput.Worksheet excelWorkSheetInitialOutput = (Worksheet)excelWorkbookOuput.Worksheets[1];            // define in which worksheet, do you want to add data

            var excelWorkSheetOutput = (Worksheet)excelWorkbookOuput.Worksheets.Add(Missing.Value,                      //add a new sheet within the excel book/file
                    excelWorkbookOuput.Worksheets[excelWorkbookOuput.Worksheets.Count],
                    Missing.Value, Missing.Value);
        
            excelWorkSheetOutput.Name = DateTime.Now.ToString("MM-dd-yyyy HH-MM-ss");            //names new worksheet the date and time
            
            return Tuple.Create(excelWorkSheetOutput, excelWorkbookOuput);                       //return the worksheet and workbook 
            
        }

        //Purpose: Save excel ouput file, end excel session, end excel & chromedriver in task manager 
        public void EndEverything(IWebDriver driver)
        {
            driver.Quit();                                                                      //ends the chrome browser

            foreach (Process proc in Process.GetProcessesByName(excel))                         //ends excel in task manager
            {
                proc.Kill();
            }

            foreach (Process proc in Process.GetProcessesByName(chromeDriver))                  //ends chromedriver in task manager
            {
                proc.Kill();

            }

            Environment.Exit(0);                                                                //exit the entire program
        }

        public void SaveExcelFile(string excelFilePath, Workbook excelWorkbookOutput)
        {
            try
            {
                excelWorkbookOutput.SaveAs(excelFilePath, Missing.Value, Missing.Value, Missing.Value,
                                      Missing.Value, Missing.Value, XlSaveAsAccessMode.xlNoChange,
                                      Missing.Value, Missing.Value, Missing.Value,
                                      Missing.Value, Missing.Value);                // Save data in excel

                excelWorkbookOutput.Close(true, excelFilePath, Missing.Value);      // close the worksheet  
            }
            finally
            {
                if (excelApplicationOuput != null)
                {
                    excelApplicationOuput.Quit();                                   // close the excel application
                }
            }

        }
    }
}
