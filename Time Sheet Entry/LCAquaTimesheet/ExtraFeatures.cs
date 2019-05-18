using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using OpenQA.Selenium;
using System.Drawing;

namespace LCAquaTimesheet
{
    class ExtraFeatures
    {
        public DriverHelper browser = new DriverHelper();

        public string ValidateHours(Range cellRange, IWebDriver driver)
        {
            string validateTotal = "no";

            double? total = cellRange.Cells[9][3].value2;
            string total_hours = total.ToString();

            string totalReal = driver.FindElement(By.XPath("//*[@id='WeekGrandTotal']")).Text;

            if (total_hours.Contains(".") == false)
                total_hours = total_hours + ".00";
            else
                total_hours = total_hours + "0";

            if (total_hours == totalReal)
            {
                validateTotal = "yes";
            }

            return validateTotal;
        }

        public void SetApproval(Range cellRange, IWebDriver driver)
        {
            string setApproaval = cellRange.Cells[12][3].value2;

            if (setApproaval == "X" || setApproaval == "x")
            {
                string message = "Are you sure you want to set approval?";
                string caption = "Set Approval";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                result = MessageBox.Show(message, caption, buttons,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                MessageBoxOptions.RightAlign);

                if (result == DialogResult.Yes)
                {
                    driver.FindElement(By.XPath("//*[@id='RadToolbarButtonSetApproval']/span/span/span/span")).Click();
                    browser.Wait(driver);

                    //int noOfFrames = driver.FindElements(By.TagName("iframe")).size();

                    driver.SwitchTo().Frame(0);
                    //driver.SwitchTo().Frame(driver.FindElement(By.XPath("//*[@id='RadWindowWrapper_RadWindowManagerParent1553115396788']/table/tbody/tr[2]/td[2]/iframe")));
                    //*[@class ="rwWindowContent rwExternalContent"]/iframe
                    //*[@id="RadWindowWrapper_RadWindowManagerParent1553115541431"]/table/tbody/tr[2]/td[2]/iframe


                    browser.Wait(driver);
                    driver.FindElement(By.XPath("//*[@id='ctl00_ContentPlaceHolderMain_BtnSubmitAll']")).Click();
                    browser.Wait(driver);
                    driver.SwitchTo().DefaultContent();
                }
                
            }
        }
        public void SignOut(IWebDriver driver)
        {
            driver.SwitchTo().DefaultContent();
            driver.FindElement(By.Id("ASPxBinaryImageEmp")).Click();
            browser.Wait(driver);
            driver.FindElement(By.XPath("//*[@id='RadTreeViewUser']/ul/li[2]/ul/li[2]/div/span[2]")).Click();
            browser.Wait(driver);
        }
    

    /*-----------------SET APPROAVAL---------------------------
           string setApproaval = x1range.Cells[10][8].value2;
           correctSet = correctSet.Remove(0, 1);

           if (setApproaval == "X" || setApproaval == "x")
           {
               if (validateTotal == "yes")
               {
                   string message = "Are you sure you want to set approval?";
                   string caption = "Set Approval";
                   MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                   DialogResult result;

                   result = MessageBox.Show(message, caption, buttons,
                   MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                   MessageBoxOptions.RightAlign);

                   if (result == DialogResult.Yes)
                   {
                       IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                       IList<string> tabs = new List<string>(driver.WindowHandles);
                       driver.SwitchTo().Window(tabs[1]);

                       string url = "https://time.laughlin.com/webvantage/Timesheet_SupervisorApproval.aspx?emp=089897&sd=" + correctSet + "&opener=Timesheet";
                       driver.Navigate().GoToUrl(url);
                       Thread.Sleep(2000);

                       driver.FindElement(By.XPath("//*[@id='ctl00_ContentPlaceHolderMain_BtnSubmitAll']")).Click();
                       //*[@id="ctl00_ContentPlaceHolderMain_BtnSubmitAll"]
                       driver.Navigate().Refresh();
                       Thread.Sleep(5000);
                       driver.SwitchTo().Window(driver.WindowHandles[0]);
                       driver.SwitchTo().DefaultContent();
                       driver.SwitchTo().Frame(driver.FindElement(By.XPath("//*[@id='RadWindowWrapper_Timesheet']/table/tbody/tr[2]/td[2]/iframe")));
                   }
               }


           }
           */
    //----------SIGNING OUT-------------------------------------
   

            //----------VALIDATING TOTAL HOURS ENTERED-------------------
       //     if (validateTotal == "yes")
         //   {
           //     MessageBox.Show("Time was entered");
           // }/
           // else
           // {
             //   driver.Quit();
                /*
                string message = "Total hours did not match time sheet, Do you want to view?";
                string caption = "Error";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                result = MessageBox.Show(message, caption, buttons,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                MessageBoxOptions.RightAlign);

                if (result == DialogResult.Yes)
                {
                    IWebDriver Driver = new ChromeDriver();
                    Driver.Navigate().GoToUrl("https://time.laughlin.com/webvantage/SignIn.aspx");
                    Driver.Manage().Window.Maximize();

                    //----------LOGGING IN---------------------------------------
                    Driver.FindElement(By.Id("RadWindowSignIn_C_TextBoxUserID")).Clear();
                    Thread.Sleep(1000);
                    Driver.FindElement(By.Id("RadWindowSignIn_C_TextBoxUserID")).SendKeys("BLANG");
                    Thread.Sleep(1000);
                    Driver.FindElement(By.XPath("//*[@id='RadWindowSignIn_C_TextBoxPassword']")).SendKeys("Thisisadev!0604");
                    Driver.FindElement(By.Id("RadWindowSignIn_C_ButtonLogin")).Click();
                    Thread.Sleep(3000);

                    //----------GETTING TO TIMESHEET----------------------------
                    Driver.FindElement(By.Id("ImageApps")).Click();
                    Thread.Sleep(1000);
                    Driver.FindElement(By.XPath("//*[@id='RadTreeViewApps']/ul/li[2]/div/span[3]")).Click();
                    Thread.Sleep(1000);
                    Driver.FindElement(By.XPath("//*[@id='RadTreeViewApps']/ul/li[2]/ul/li[2]/div/span[2]")).Click();
                    Thread.Sleep(5000);
                }*/
            }
}

