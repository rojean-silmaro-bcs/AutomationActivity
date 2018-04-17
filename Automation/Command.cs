using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Automation
{
    class Command
    {
        public static void Click(IWebElement element, string name)
        {
            try
            {
                element.Click();
            }
            catch (Exception e)
            {
                throw new ApplicationException("Unable to click " + name, e);
            }
        }

        public static void SendKeys(IWebElement element, string keys, string name)
        {
            try
            {
                element.SendKeys(keys);
            }
            catch (Exception e)
            {
                throw new ApplicationException("Unable to type " + keys + " to " + name, e);
            }
        }

        public static string SetDepartureDate(int d)
        {
            var depart = DateTime.Now.AddDays(+d);
            string departDate = depart.Day + "/" + depart.Month + "/" + depart.Year;

            return departDate;
        }

        public static string SetReturnDate(int d)
        {
            var ret = DateTime.Now.AddDays(+d);
            string returnDate = ret.Day + "/" + ret.Month + "/" + ret.Year;

            return returnDate;
        }

        public static void SelectByValue(IWebElement element, string value, string name)
        {
            try
            {
                new SelectElement(element).SelectByValue(value);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to select element " + name + " by value " + value, ex);
            }
        }

        public static void SelectByText(IWebElement element, string text, string name, bool partial)
        {
            try
            {
                new SelectElement(element).SelectByText(text, partial);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to select element " + name + " by text " + text, ex);
            }
        }

    }
}
