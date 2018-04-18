using Automation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Test.StepDefinition
{
    public class BaseSteps
    {
        StringBuilder strBldr;

        public string GetLogMessage
        {
            get
            {
                if (strBldr != null)
                    return strBldr.ToString();
                return "";
            }
        }

        public string SiteUrl { get; set; }
        public string TripType { get; set; }
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        public string DepartureDate { get; set; }
        public string ReturnDate { get; set; }
        public string TravelClass { get; set; }
        public string AdultPassengers { get; set; }
        public string ChildPassengers { get; set; }
        public string InfantPassengers { get; set; }
        public string LogMessage { get; set; }
        private string logFileName { get; set; }
        public string LogFileName
        {
            get
            {
                logFileName = Environment.CurrentDirectory + "\\ResultLogs.txt";

                return logFileName;
            }
            set { logFileName = value; }
        }

        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string DomainName { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string Postcode { get; set; }
        public string Password { get; set; }
        public string SecQ { get; set; }
        public string SecA { get; set; }
        public string Birthdate { get; set; }
        private string emailAddress = string.Empty;
        public string EmailAddress
        {   get { return emailAddress; }
            set { emailAddress = value; }
        }
        public string PhoneNumberType { get; set; }
        public string Country { get; set; }
        public string State { get; set; }

        public void BaseInitialize()
        {
            string assemblyPath = AppDomain.CurrentDomain.BaseDirectory;

            Environment.CurrentDirectory = System.IO.Path.Combine(assemblyPath, @"..\..\Results");

        }

        public void Log(string url = "")
        {
            string urlsUsed = SiteUrl;

            Logger.Log(this.LogFileName, this.LogMessage, urlsUsed);
            this.LogMessage = string.Empty;
        }

        private void AppendToLog(string desc, string msg, bool addSpacing = false)
        {
            if (!string.IsNullOrWhiteSpace(msg))
            {
                if (addSpacing)
                    strBldr.AppendLine(Environment.NewLine + desc + msg);
                else
                    strBldr.AppendLine(desc + msg);
            }
        }

        public void SetLogMessage()
        {
            strBldr = new StringBuilder("");

            AppendToLog("*Site Url: ", SiteUrl);
            AppendToLog("*Trip Type: ", TripType);
            AppendToLog("*From Location: ", FromLocation);
            AppendToLog("*To Location: ", ToLocation);
            AppendToLog("*Departure Date: ", DepartureDate);
            AppendToLog("*Return Date: ", ReturnDate);
            AppendToLog("*Travel Class: ", TravelClass);
            AppendToLog("*Adult Passenger(s): ", AdultPassengers);
            AppendToLog("*Children Passenger(s): ", ChildPassengers);

            AppendToLog("*Title: ", Title);
            AppendToLog("*First Name: ", FirstName);
            AppendToLog("*Last Name: ", LastName);
            AppendToLog("*Trip Type: ", TripType);
            AppendToLog("*Phone Number Type: ", PhoneNumberType);
            AppendToLog("*Phone Number: ", PhoneNumber);
            AppendToLog("*Email: ", EmailAddress);
            AppendToLog("*Street Address: ", StreetAddress);
            AppendToLog("*Suburb City: ", City);
            AppendToLog("*Country: ", Country);
            AppendToLog("*State: ", State);
            AppendToLog("*Postcode: ", Postcode);
            AppendToLog("*Trip Type: ", TripType);
            AppendToLog("*Password: ", Password);
            AppendToLog("*Security Question: ", SecQ);
            AppendToLog("*Security Answer: ", SecA);
            AppendToLog("*Birthdate: ", Birthdate);

            LogMessage = strBldr.ToString();

        }

        public void SetLogMessage(Exception e)
        {
            //DefaultErrorLog("Failed", e.Message, e.StackTrace);

            strBldr = new StringBuilder("");

            strBldr.AppendLine("Status : Failed");
            strBldr.AppendLine("Error Message : " + e.Message);
            strBldr.AppendLine("Error StackTrace : " + e.StackTrace);

            LogMessage = strBldr.ToString();
        }

        public void SetLogMessage(InvalidOperationException ioe)
        {
            DefaultErrorLog("Failed", ioe.Message, ioe.StackTrace);

            LogMessage = strBldr.ToString();
        }

        public void SetLogMessage(NullReferenceException nre)
        {
            DefaultErrorLog("Failed", nre.Message, nre.StackTrace);

            LogMessage = strBldr.ToString();
        }

        private void DefaultErrorLog(string status, string errorMsg, string stackTrace)
        {
            strBldr = new StringBuilder("");

            strBldr.AppendLine("Status : " + status);
            strBldr.AppendLine("Error Message : " + errorMsg);
            strBldr.AppendLine("Error StackTrace : " + stackTrace);
        }
    }
}
