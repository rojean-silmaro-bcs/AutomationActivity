using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace Automation.Pages
{
    public class SearchPage
    {
        public string GivenIGoToTheSearchPageModel()
        {
            string url = "https://devci.webjet.com.au/FlightSearch/FlightSearch/SearchFromIFrame?SidePanel=True";
            Browser.GoTo(url);

            return url;
        }

        public string GetTripType()
        {
            var returnType = Browser.FindElement(By.Id("ReturnType"), "Return type selected", 7);
            Command.Click(returnType, "Return type selected");

            return "Return";
        }

        public string GetOrigin()
        {
            var fromManila = Browser.FindElement(By.Id("FlightStops_0__CityFrom"), "From Manila", 0);
            Command.SendKeys(fromManila, "Manila", "From Manila");
            var fromSuggestedResult = Browser.FindElement(By.CssSelector("#ui-id-6>a>span"), "Select From Suggested Result (Top)", 7);
            Command.Click(fromSuggestedResult, "Select From Suggested Result (Top)");

            return "Manila";
        }

        public string GetDestination()
        {
            var toCebu = Browser.FindElement(By.Id("FlightStops_0__CityTo"), "To Cebu", 0);
            Command.SendKeys(toCebu, "Cebu", "To Cebu");
            var toSuggestedResult = Browser.FindElement(By.CssSelector("#ui-id-7>a>span"), "Select To Suggested Result (Top)", 7);
            Command.Click(toSuggestedResult, "Select To Suggested Result (Top)");

            return "Cebu";
        }

        public string GetDepartureDate()
        {
            string departDate = Command.SetDepartureDate(7);   //7 days from the current date
            Browser.js.ExecuteScript("document.getElementById('FlightStops_0__DepartureDate').value='" + departDate + "'");

            return departDate;
        }

        public string GetReturnDate()
        {
            string returnDate = Command.SetReturnDate(14);     //14 days from the current date
            Browser.js.ExecuteScript("document.getElementById('FlightStops_0__ReturnDate').value='" + returnDate + "'");

            return returnDate;
        }

        public string GetTravelClass()
        {
            var travelClass = Browser.FindElement(By.Id("TravelClass"), "Select Premium Economy Class", 0);
            Command.SelectByValue(travelClass, "PremiumEconomy", "Select Premium Economy Class");

            return "Premium Economy";
        }

        public string GetAdultPassengersCount()
        {
            var adultsCount = Browser.FindElement(By.Id("Adults"), "Set Adult Count to 1", 0);
            Command.SelectByValue(adultsCount, "1", "Set Adult Count to 1");

            return "1";
        }

        public string GetChildrenPassengersCount()
        {
            var childrenCount = Browser.FindElement(By.Id("Children"), "Set Children Count to 1", 0);
            Command.SelectByValue(childrenCount, "1", "Set Children Count to 1");

            return "1";
        }

        public void WhenIPressSearchFlightsModel()
        {
            var flightSearch = Browser.FindElement(By.Id("flight-search-button"), "Flight Search button clicked", 0);
            Command.Click(flightSearch, "Flight Search button clicked");

        }

        public void ThenTheResultPageShouldDisplayModel()
        {
            
            Browser.FindElement(By.CssSelector("#flight-search-widget-container>h2"), "Search Again", 60);
        }

    }
}
