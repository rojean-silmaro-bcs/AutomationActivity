using System;
using TechTalk.SpecFlow;
using Automation;
using Automation.Pages;


namespace Test.StepDefinition
{
    [Binding]
    public class FlightSearchSteps : BaseSteps
    {
        SearchPage sp = new SearchPage();

        [BeforeScenario("FlightSearch")]
        public void Initialize()
        {
            try
            {
                this.BaseInitialize();
                Browser.Initialize();
            }
            catch
            {

            }
        }

        [Scope(Tag = "FlightSearch")]
        [Given(@"I go to the search page")]
        public void GivenIGoToTheSearchPage()
        {
            SiteUrl = sp.GivenIGoToTheSearchPageModel();
            //Logger.Log(Environment.CurrentDirectory + "\\ResultLogs.txt", "SiteUrl = "+ SiteUrl, SiteUrl);
        }

        [Scope(Tag = "FlightSearch")]
        [Given(@"I fill up the search details")]
        public void GivenIFillUpTheSearchDetails()
        {
            //SearchPage.GivenIFillUpSearchDetailsModel();
            TripType = sp.GetTripType();
            FromLocation = sp.GetOrigin();
            ToLocation = sp.GetDestination();
            DepartureDate = sp.GetDepartureDate();
            ReturnDate = sp.GetReturnDate();
            TravelClass = sp.GetTravelClass();
            AdultPassengers = sp.GetAdultPassengersCount();
            ChildPassengers = sp.GetChildrenPassengersCount();

        }

        [Scope(Tag = "FlightSearch")]
        [When(@"I press search flights")]
        public void WhenIPressSearchFlights()
        {
            sp.WhenIPressSearchFlightsModel();
        }

        [Scope(Tag = "FlightSearch")]
        [Then(@"the result page should display")]
        public void ThenTheResultPageShouldDisplay()
        {
            this.SetLogMessage();
            this.Log(SiteUrl);
            sp.ThenTheResultPageShouldDisplayModel();
            Browser.CloseAndQuit();
        }

        //[AfterScenario("FligthSearch")]
        //public void Cleanup()
        //{
        //    Browser.CloseAndQuit();
        //}
    }
}
