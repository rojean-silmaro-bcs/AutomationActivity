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

<<<<<<< HEAD
        public static void Screenshots(string fileName)
        {
            IWebDriver webDriver = null;
            if (Browser.WebDriver != null) { webDriver = Browser.WebDriver; }

            //((ITakesScreenshot)webDriver).GetScreenshot().SaveAsFile(fileName);

            Browser.ScrollToTop();

            var screenshot = GetFullPageScreenshot();
            screenshot.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
        }

        public static Bitmap GetFullPageScreenshot()
        {

            Bitmap stitchedImage = null;
            try
            {
                long totalwidth1 = (long)((IJavaScriptExecutor)Browser.WebDriver).ExecuteScript("return document.body.offsetWidth");//documentElement.scrollWidth");

                long totalHeight1 = (long)((IJavaScriptExecutor)Browser.WebDriver).ExecuteScript("return  document.body.parentNode.scrollHeight");

                int totalWidth = (int)totalwidth1;
                int totalHeight = (int)totalHeight1;

                // Get the Size of the Viewport
                long viewportWidth1 = (long)((IJavaScriptExecutor)Browser.WebDriver).ExecuteScript("return document.body.clientWidth");//documentElement.scrollWidth");
                long viewportHeight1 = (long)((IJavaScriptExecutor)Browser.WebDriver).ExecuteScript("return window.innerHeight");//documentElement.scrollWidth");

                int viewportWidth = (int)viewportWidth1;
                int viewportHeight = (int)viewportHeight1;


                // Split the Screen in multiple Rectangles
                List<Rectangle> rectangles = new List<Rectangle>();
                // Loop until the Total Height is reached
                for (int i = 0; i < totalHeight; i += viewportHeight)
                {
                    int newHeight = viewportHeight;
                    // Fix if the Height of the Element is too big
                    if (i + viewportHeight > totalHeight)
                    {
                        newHeight = totalHeight - i;
                    }
                    // Loop until the Total Width is reached
                    for (int ii = 0; ii < totalWidth; ii += viewportWidth)
                    {
                        int newWidth = viewportWidth;
                        // Fix if the Width of the Element is too big
                        if (ii + viewportWidth > totalWidth)
                        {
                            newWidth = totalWidth - ii;
                        }

                        // Create and add the Rectangle
                        Rectangle currRect = new Rectangle(ii, i, newWidth, newHeight);
                        rectangles.Add(currRect);
                    }
                }

                // Build the Image
                stitchedImage = new Bitmap(totalWidth, totalHeight);
                // Get all Screenshots and stitch them together
                Rectangle previous = Rectangle.Empty;
                foreach (var rectangle in rectangles)
                {
                    // Calculate the Scrolling (if needed)
                    if (previous != Rectangle.Empty)
                    {
                        int xDiff = rectangle.Right - previous.Right;
                        int yDiff = rectangle.Bottom - previous.Bottom;
                        // Scroll
                        //selenium.RunScript(String.Format("window.scrollBy({0}, {1})", xDiff, yDiff));
                        ((IJavaScriptExecutor)Browser.WebDriver).ExecuteScript(String.Format("window.scrollBy({0}, {1})", xDiff, yDiff));
                        System.Threading.Thread.Sleep(200);
                    }

                    // Take Screenshot
                    var screenshot = ((ITakesScreenshot)Browser.WebDriver).GetScreenshot();

                    // Build an Image out of the Screenshot
                    Image screenshotImage;
                    using (MemoryStream memStream = new MemoryStream(screenshot.AsByteArray))
                    {
                        screenshotImage = Image.FromStream(memStream);
                    }

                    // Calculate the Source Rectangle
                    Rectangle sourceRectangle = new Rectangle(viewportWidth - rectangle.Width, viewportHeight - rectangle.Height, rectangle.Width, rectangle.Height);

                    // Copy the Image
                    using (Graphics g = Graphics.FromImage(stitchedImage))
                    {
                        g.DrawImage(screenshotImage, rectangle, sourceRectangle, GraphicsUnit.Pixel);
                    }

                    // Set the Previous Rectangle
                    previous = rectangle;
                }
            }
            catch (Exception ex)
            {
                // handle
            }
            return stitchedImage;
        }

        public static void Dispose() { }
=======
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
>>>>>>> a85f4627529e05f7678ec255b59c90f23b834e17
    }
}
