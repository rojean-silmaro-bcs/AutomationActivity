using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation
{
    public static class Logger
    {
        public static void Log(string fileName, string message, string url ="")
        {
            try
            {
                StreamWriter sw;
                if (!File.Exists(fileName))
                {
                    //if(!Directory.Exists(resultsFolderPath))
                    //    Directory.CreateDirectory(resultsFolderPath);

                    sw = File.CreateText(fileName);

                    if (!string.IsNullOrWhiteSpace(url))
                    {
                        sw.WriteLine(string.Format("Url for this test: {0}{1}", url, Environment.NewLine));
                    }
                }
                else
                {
                    sw = File.AppendText(fileName);
                }

                sw.WriteLine(message);
                sw.WriteLine("{0}===================================================================================={0}", Environment.NewLine);
                sw.Flush();
                sw.Close();

            }
            catch
            {

            }
        }

        //public static void Screenshots(string fileName)
        //{
        //    IWebDriver webDriver = null;
        //    if (Browser.WebDriver != null) { webDriver = Browser.WebDriver; }

        //    try
        //    {
        //        Browser.ScrollToTop();

        //        var screenshot = GetFullPageScreenshot();
        //        screenshot.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
        //    }
        //    catch (Exception)
        //    {
        //    }
        //}
    }
}
