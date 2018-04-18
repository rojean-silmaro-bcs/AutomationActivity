using System;
using NUnit.Framework;
using NUnit;
using TechTalk.SpecFlow;
using Automation;
using Automation.Pages;

namespace Test.StepDefinition
{
    [Binding]
    public class CreateAccountSteps : BaseSteps
    {
        JoinPage jp = new JoinPage();

        [BeforeScenario("CreateAccount")]
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

        [Scope(Tag = "CreateAccount")]
        [Given(@"(.*) as title, (.*) as first name, (.*) as last name, (.*) as phone number type, (.*) as mobile, (.*)#(.*) as email, (.*) as st. addr., (.*) as city, (.*) as country, (.*) as state, (.*) as postcode, (.*) as password, (.*) as security question, (.*) as security answer, (.*) as birthdate, (.*) as url")]
        public void GivenIFillUpUserAccountDetails(string title, string firstName, string lastName, string phoneNumberType, string number, string userName, string domainName, string streetAddress, string city, string country, string state, string postcode, string password, string secQ, string secA, string birthdate, string url)
        {
            try
            {
                SiteUrl = url;
                Title = title;
                FirstName = firstName;
                LastName = lastName;
                PhoneNumberType = phoneNumberType;
                PhoneNumber = number;
                UserName = userName;
                DomainName = domainName;
                StreetAddress = streetAddress;
                City = city;
                Country = country;
                State = state;
                Postcode = postcode;
                Password = password;
                SecQ = secQ;
                SecA = secA;
                Birthdate = birthdate;
            }
            catch
            {

            }
        }

        [Scope(Tag = "CreateAccount")]
        [When(@"I go to home page")]
        public void WhenIGoToHomePage()
        {
            try
            {
                jp.WhenIGoToHomePageModel(SiteUrl);
            }
            catch (InvalidOperationException ioe)
            {
                this.SetLogMessage(ioe);
            }
            catch (Exception e)
            {
                this.SetLogMessage(e);
            }
        }

        [Scope(Tag = "CreateAccount")]
        [Then(@"sign up for an account using the given details")]
        public void ThenSignUpForAnAccountUsingTheGivenDetails()
        {
            try
            {
                jp.ClickJoinLink();
                jp.SelectTitle(Title);
                jp.InputFirstName(FirstName);
                jp.InputLastName(LastName);
                jp.SelectPhoneNumberType(PhoneNumberType);
                jp.InputPhoneNumber(PhoneNumber);
                this.EmailAddress = jp.InputEmailAddress(UserName, DomainName);
                jp.ConfirmEmailAddress(EmailAddress);
                jp.InputStreetAddress(StreetAddress);
                jp.InputSuburbCity(City);
                jp.SelectCountry(Country);
                jp.SelectState(State);
                jp.InputPostCode(Postcode);
                jp.InputPassword(Password);
                jp.ConfirmPassword(Password);
                jp.SelectSecurityQuestion(SecQ);
                jp.InputSecurityAnswer(SecA);
                jp.InputBirthDate(Birthdate);
                jp.ClickAgreedToTerms();
                jp.ClickMyProfileSubmit();

                Assert.True(jp.CheckIfLoggedIn());
            }
            catch (InvalidOperationException ioe)
            {
                this.SetLogMessage(ioe);
            }
            catch (NullReferenceException nre)
            {
                this.SetLogMessage(nre);
            }

            catch (Exception e)
            {
                this.SetLogMessage(e);
            }
            this.SetLogMessage();
        }

        [AfterScenario("CreateAccount")]
        public void Cleanup()
        {  
            this.Log(SiteUrl);
            Browser.CloseAndQuit();
        }
    }
}
