using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using excelTimeSheet = Microsoft.Office.Interop.Excel;

namespace LCAquaTimesheet
{
    class ExcelParts
    {
        public Range StartExcelInput(string timeSheetLocation)
        {
            excelTimeSheet.Application excelInputApplication = new Application();                                       //starts new excel application
            excelTimeSheet.Workbook excelInputworkbook = excelInputApplication.Workbooks.Open(timeSheetLocation);      //opens inout excel timesheet
            excelTimeSheet._Worksheet excelInputworksheet = excelInputworkbook.Sheets[1];                             //uses sheet 1 to scan for data
            excelTimeSheet.Range cellRange = excelInputworksheet.UsedRange;                                          //creates range of cells on the sheet

            return cellRange;                                                               //returns cellRange for input reading
        }

        public void EndExcel()
        {
            foreach (Process proc in Process.GetProcessesByName("Excel"))                   //enda all "excel" named tasks running on pc
            {
                proc.Kill();
            }

            foreach (Process proc in Process.GetProcessesByName("chromedriver"))            //ends all "chromedriver" named tasks running on pc
            {
                proc.Kill();

            }
        }
       
    }
}
