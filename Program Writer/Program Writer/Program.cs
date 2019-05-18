using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//will later need:
//assertText
//assertEval

namespace Program_Writer
{
    class Program : MessageHelper
    {
        const int HIDE_CMD_WINDOW = 0; //variable for cmd window view setting
        static void Main(string[] args)
        {
            IntPtr myWindow = GetConsoleWindow();   //initializes window
            ShowWindow(myWindow, HIDE_CMD_WINDOW);  //hides window

            string location = "";
            string value = "filename";

            string fileName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            DialogResult input1 = InputBox("ENTER FILE NAME", "Enter TXT file to put code in", ref value);
            if (input1 == DialogResult.OK)
            {
                fileName = fileName + @"\" + value + ".txt";
            }

            if (input1 == DialogResult.Cancel)
            {
                Environment.Exit(0);
            }

            DialogResult input = InputBox("ENTER FILE", "Enter HTML file to transfer:", ref value);
            if (input == DialogResult.OK)
            {
                location = value;
            }

            if (input == DialogResult.Cancel)
            {
                Environment.Exit(0);
            }

            
            string colomn2 = "";
            string colomn3 = "";

            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--disable-extensions"); // to disable extension
            options.AddArguments("--disable-notifications"); // to disable notification
            options.AddArguments("--disable-application-cache"); // to disable cache
            options.AddArguments("--headless");
            IWebDriver driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl(location);

            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.WriteLine("from selenium import webdriver");
                writer.WriteLine("from selenium.webdriver.support.ui import WebDriverWait");
                writer.WriteLine("from selenium.webdriver.support import expected_conditions as EC");
                writer.WriteLine("from selenium.webdriver.common.by import By");
                writer.WriteLine("");

                writer.WriteLine("import smtplib");
                writer.WriteLine("from email.mime.text import MIMEText");
                writer.WriteLine("from email.mime.multipart import MIMEMultipart  # for emailing");
                writer.WriteLine("");

                writer.WriteLine("chromeDriver = 'C:\\Python27\\chromedriver.exe'  # chrome driver location");
                writer.WriteLine("options = webdriver.ChromeOptions()  # initializes options");
                writer.WriteLine("options.add_argument('headless')    # is option to have no visible driver");
                writer.WriteLine("driver = webdriver.Chrome(executable_path=chromeDriver)  #, chrome_options=options)  # opens chrome driver");
                writer.WriteLine("");

                writer.WriteLine("wait = WebDriverWait(driver,10)");
                writer.WriteLine(" ");

                try
                {
                    for (int row = 1; row <= 1000; ++row)
                    {
                        read = driver.FindElement(By.XPath("/html/body/table/tbody/tr[" + row + "]/td[1]")).Text;

                        if (read == "waitForPageToLoad")
                        {
                            writer.WriteLine("driver.set_page_load_timeout(10)");
                        }
                        else if (read == "click")
                        {
                            colomn2 = driver.FindElement(By.XPath("/ html / body / table / tbody / tr[" + row + "] / td[2]")).Text;
                            colomn2 = colomn2.Remove(0, 4);

                            writer.WriteLine("wait.until(EC.presence_of_element_located((By.CSS_SELECTOR, '" + colomn2 + "')))");
                            writer.WriteLine("driver.find_element_by_css_selector('" + colomn2 +"').click()");
                            writer.WriteLine("");
                        }
                        else if (read == "type")
                        {
                            colomn2 = driver.FindElement(By.XPath("/ html / body / table / tbody / tr[" + row + "] / td[2]")).Text;
                            colomn2 = colomn2.Remove(0, 4);

                            colomn3 = driver.FindElement(By.XPath("/ html / body / table / tbody / tr[" + row + "] / td[3]")).Text;

                            writer.WriteLine("wait.until(EC.presence_of_element_located((By.CSS_SELECTOR, '" + colomn2 + "')))");
                            writer.WriteLine("driver.find_element_by_css_selector('" + colomn2 + "').send_keys('" + colomn3 + "')");
                            writer.WriteLine("");
                        }
                        else if (read == "open")
                        {
                            colomn2 = driver.FindElement(By.XPath("/ html / body / table / tbody / tr[" + row + "] / td[2]")).Text;

                            writer.WriteLine("driver.get('" + colomn2 + "')");
                            writer.WriteLine("");
                        }
                        else if (read == "assertElementPresent" || read == "verifyElementPresent")
                        {
                            colomn2 = driver.FindElement(By.XPath("/ html / body / table / tbody / tr[" + row + "] / td[2]")).Text;
                            colomn2 = colomn2.Remove(0, 4);

                            writer.WriteLine("wait.until(EC.presence_of_element_located((By.CSS_SELECTOR, '" + colomn2 + "')))");
                            writer.WriteLine("wait.until(EC.visibility_of_element_located((By.CSS_SELECTOR, '" + colomn2 + "')))");
                            writer.WriteLine("");

                        }
                        else if (read == "assertText" || read == "verifyText")
                        {
                            colomn3 = driver.FindElement(By.XPath("/ html / body / table / tbody / tr[" + row + "] / td[3]")).Text;
                            colomn3 = colomn3.Replace("*", "");
                            colomn2 = driver.FindElement(By.XPath("/ html / body / table / tbody / tr[" + row + "] / td[2]")).Text;
                            colomn2 = colomn2.Remove(0, 4);

                            writer.WriteLine("wait.until(EC.presence_of_element_located((By.CSS_SELECTOR, '" + colomn2 +"')))");
                            writer.WriteLine("assert '" +colomn3 + "' == driver.find_element_by_css_selector('" + colomn2 +"').text");
                            writer.WriteLine("");

                            //writer.WriteLine("wait.until(EC.presence_of_element_located((By.PARTIAL_LINK_TEXT, '" + colomn3 + "')))  #assert text");
                            //writer.WriteLine("");
                        }
                        else if (read == "assertNotText")
                        {
                            colomn3 = driver.FindElement(By.XPath("/ html / body / table / tbody / tr[" + row + "] / td[3]")).Text;
                            colomn3 = colomn3.Replace("*", "");
                            colomn2 = driver.FindElement(By.XPath("/ html / body / table / tbody / tr[" + row + "] / td[2]")).Text;
                            colomn2 = colomn2.Remove(0, 4);

                            writer.WriteLine("wait.until(EC.presence_of_element_located((By.CSS_SELECTOR, '" + colomn2 + "')))");
                            writer.WriteLine("assert '" + colomn3 + "' != driver.find_element_by_css_selector('" + colomn2 + "').text");
                            writer.WriteLine("");
                        }
                        else if (read == "assertEval")
                        {
                            writer.WriteLine("LOOK ON GHOST INSPECTOR");
                        }
                        else if (read == "pause")
                        {
                            colomn2 = driver.FindElement(By.XPath("/ html / body / table / tbody / tr[" + row + "] / td[2]")).Text;
                            colomn2 = colomn2.Remove(1, 3);

                            writer.WriteLine("time.sleep(" +colomn2 +")");
                            writer.WriteLine("");
                        }
                        else if (read == "mouseOver")
                        {
                            writer.WriteLine("element = driver.find_element_by_css_selector('.list-inline > .motionpoint')");
                            writer.WriteLine("hover = ActionChains(driver).move_to_element(element)");
                            writer.WriteLine("hover.perform()");
                            writer.WriteLine("");
                        }


                        /*
                         else if (read == "click")
                        {
                            colomn2 = driver.FindElement(By.XPath("/ html / body / table / tbody / tr[" + row + "] / td[2]")).Text;
                            colomn2 = colomn2.Remove(0, 4);

                            writer.WriteLine("driver.find_element_by_css_selector('" + colomn2 + "').click()");
                            writer.WriteLine("");
                        }
                        else if (read == "type")
                        {
                            colomn2 = driver.FindElement(By.XPath("/ html / body / table / tbody / tr[" + row + "] / td[2]")).Text;
                            colomn2 = colomn2.Remove(0, 4);

                            colomn3 = driver.FindElement(By.XPath("/ html / body / table / tbody / tr[" + row + "] / td[3]")).Text;

                            writer.WriteLine("driver.find_element_by_css_selector('" + colomn2 + "').send_keys('" + colomn3 + "')");
                            writer.WriteLine("");
                        }
                        */

                    }
                }
                catch { }

                writer.WriteLine("driver.close()");
                writer.WriteLine("driver.close()");
                writer.WriteLine("");
                writer.WriteLine("from_user = 'LCtestingpython@gmail.com'  # emails used");
                writer.WriteLine("to_user = 'blang@laughlin.com'");
                writer.WriteLine("password = '404LCnotFound'");
                writer.WriteLine("");
                writer.WriteLine("subject = 'Test Failed: Lost Combo Landing Page'");
                writer.WriteLine("body = 'There has been an error with test Lost Combo Landing Page (UK) under EU/UK Lost Key or Combo'");
                writer.WriteLine("server = smtplib.SMTP('smtp.gmail.com', 587)  # server for chrome");
                writer.WriteLine("");
                writer.WriteLine("server.starttls()");
                writer.WriteLine("server.login(from_user, password)");
                writer.WriteLine("");
                writer.WriteLine("mag = MIMEMultipart()");
                writer.WriteLine("mag['From'] = from_user");
                writer.WriteLine("mag['To'] = to_user");
                writer.WriteLine("mag['Subject'] = subject");
                writer.WriteLine("");
                writer.WriteLine("mag.attach(MIMEText(body, 'plain'))     # sends email");
                writer.WriteLine("text = mag.as_string()");
                writer.WriteLine("# server.sendmail(from_user, to_user, text)");
                writer.WriteLine("server.close()");

                MessageBox.Show("DONE!");
            }

        }

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImport("kernel32")]
        static extern IntPtr GetConsoleWindow();
    }
}
