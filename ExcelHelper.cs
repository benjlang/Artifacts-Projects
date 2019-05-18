using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using excelOutput = Microsoft.Office.Interop.Excel;

namespace Test
{
    class ExcelHelper
    {
        public static excelOutput.Application excelApplicationOuput;   //new application for the ouput books
        public static excelOutput.Workbook excelWorkbookOuput;       //initializing book/file for output
        
        //Purpose: To create a new sheet, name it the date/time, initialize sheet
        public Tuple<Worksheet, Workbook, Range> CreatingOuputWorksheet(string exeLocal)
        {
            excelApplicationOuput = null;                                //must do, do not ask why
            excelApplicationOuput = new excelOutput.Application();       // create Excell App
            excelApplicationOuput.DisplayAlerts = false;                 // turn off alerts

            excelOutput.Workbook excelWorkbookOuput = (Workbook)(excelApplicationOuput.Workbooks.Open(exeLocal));  // open the existing excel file 

            //takes newest sheet (1)
            excelOutput.Worksheet excelWorkSheetInitialOutput = (Worksheet)excelWorkbookOuput.Worksheets[1];            // define in which worksheet, do you want to add data

            var excelWorkSheetOutput = (Worksheet)excelWorkbookOuput.Worksheets.Add(Missing.Value,                      //add a new sheet within the excel book/file
                    excelWorkbookOuput.Worksheets[excelWorkbookOuput.Worksheets.Count],
                    Missing.Value, Missing.Value);

            excelWorkSheetOutput.Name = DateTime.Now.ToString("MM-dd-yyyy HH-MM-ss");            //names new worksheet the date and time

            Range excelRange = excelWorkSheetOutput.UsedRange;

            return Tuple.Create(excelWorkSheetOutput, excelWorkbookOuput, excelRange);                       //return the worksheet and workbook 

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
