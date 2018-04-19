using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Automation
{
    public class Browser
    {
        static IWebDriver webDriver = null;
        static string browserName = string.Empty;
        public static IJavaScriptExecutor js = null;

        public static IWebDriver WebDriver
        {
            get { return webDriver; }
        }

        public static IJavaScriptExecutor JS
        {
            get { return js; }
        }

        public static IWebElement FindElement(By locator, string elementName, int timeoutInSeconds)
        {
            try
            {
                if (timeoutInSeconds > 0)
                {
                    var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(timeoutInSeconds));
                    return wait.Until(drv => drv.FindElement(locator));
                }

                return webDriver.FindElement(locator);
            }
            catch (Exception e)
            {
                if (elementName == "")
                {
                    var elementId = locator.ToString().Split(new string[] { ":" }, StringSplitOptions.None);
                    elementName = elementId.Last().Trim();
                }
                throw new Exception(string.Format("{0} was not found", elementName), e);
            }
        }

        public static void Initialize()
        {
            webDriver = new ChromeDriver();
            webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(20);
            browserName = "Chrome (Desktop)";

            //js = (IJavaScriptExecutor)webDriver;
        }

        public static void GoTo(string url)
        {
            try
            {
                webDriver.Url = url;
            }
            catch
            {
                webDriver.Navigate().Refresh();
            }
        }
        public static void ScrollToTop()
        {
            ((IJavaScriptExecutor)Browser.WebDriver).ExecuteScript(String.Format("window.scrollBy({0}, {1})", 0, -10000));
        }
        public static void KillProcess()
        {
            var chromeDriverProcesses = Process.GetProcesses().
                     Where(pr => pr.ProcessName == "chromedriver");

            foreach (var process in chromeDriverProcesses)
            {
                process.Kill();
            }
        }

        public static void CloseAndQuit()
        {
            Thread.Sleep(2000);
            webDriver.Close();
            webDriver.Quit();
            KillProcess();
        }

    }
}
