using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Automation.Pages
{
    public class JoinPage
    {
        public void WhenIGoToHomePageModel(string url)
        {
            Browser.GoTo(url);
        }

        public void ClickJoinLink()
        {
            var myAccount = Browser.FindElement(By.Id("my-account"), "My Account Link", 7);
            Command.Click(myAccount, "My Account Link Clicked");

            var joinButton = Browser.FindElement(By.CssSelector("#my-account>ul>li:nth-child(1)>a"), "Join link", 7);
            Command.Click(joinButton, "Join Link Clicked");
        }

        public void SelectTitle(string t)
        {
            var title = Browser.FindElement(By.Id("Salutation"), "Salutation", 7);
            Command.SelectByValue(title, t, "Select Title");
        }

        public void InputFirstName(string fn)
        {
            var firstName = Browser.FindElement(By.Id("FirstName"), "First Name", 0);
            Command.SendKeys(firstName, fn, "First Name");
        }

        public void InputLastName(string ln)
        {
            var lastName = Browser.FindElement(By.Id("LastName"), "Last Name", 0);
            Command.SendKeys(lastName, ln, "Last Name");
        }

        public void SelectPhoneNumberType(string t)
        {
            var phoneNumberType = Browser.FindElement(By.Id("PhoneNumberType"), "Phone Number Type", 0);
            Command.SelectByValue(phoneNumberType, t, "Select Phone Number Type");
        }

        public void InputPhoneNumber(string pn)
        {
            var phoneNumber = Browser.FindElement(By.Id("PhoneNumber"), "Phone Number", 0);
            Command.SendKeys(phoneNumber, pn, "Phone Number");
        }

        public string InputEmailAddress(string user, string domain)
        {
            string emailAddress = String.Concat(user, DateTime.Now.ToString("ddMMyyyyHHmmss"), domain);

            var email = Browser.FindElement(By.Id("EmailAddress"), "Email Address", 0);
            Command.SendKeys(email, emailAddress, "Email Address");

            return emailAddress;
        }

        public void ConfirmEmailAddress(string eac)
        {
            var emailAddressConfirmation = Browser.FindElement(By.Id("EmailAddressConfirmation"), "Email Address Confirmation", 0);
            Command.SendKeys(emailAddressConfirmation, eac, "Email Address Confirmation");
        }

        public void InputStreetAddress(string sa)
        {
            var streetAddress = Browser.FindElement(By.Id("Address_StreetAddress"), "Street Address", 0);
            Command.SendKeys(streetAddress, sa, "Street Address");
        }

        public void InputSuburbCity(string sc)
        {
            var suburbCity = Browser.FindElement(By.Id("Address_Suburb"), "Suburb City", 0);
            Command.SendKeys(suburbCity, sc, "Suburb City");
        }

        public void SelectCountry(string c)
        {
            var country = Browser.FindElement(By.Id("ddlCountries"), "Countries", 0);
            Command.SelectByText(country, c, "Select Country", false);
        }

        public void SelectState(string s)
        {
            var state = Browser.FindElement(By.Id("ddlStates"), "States", 0);
            Command.SelectByValue(state, s, "Select States");
        }

        public void InputPostCode(string pc)
        {
            var postcode = Browser.FindElement(By.Id("ddlPostcode"), "Postcode", 0);
            Command.SendKeys(postcode, pc, "Postcode");
        }

        public void InputPassword(string pwd)
        {
            var password = Browser.FindElement(By.Id("Password"), "Password", 0);
            Command.SendKeys(password, pwd, "Password");
        }

        public void ConfirmPassword(string pwd)
        {
            var passwordConfirm = Browser.FindElement(By.Id("PasswordConfirmation"), "Password Confirmation", 0);
            Command.SendKeys(passwordConfirm, pwd, "Password Confirmation");
        }

        public void SelectSecurityQuestion(string q)
        {
            var question = Browser.FindElement(By.Id("SecurityQuestionCode"), "Security Question Code", 0);
            Command.SelectByText(question, q, "Security Question Code", true);

            //q = Browser.WebDriver.FindElement(By.Id("SecurityQuestionCode")).Text;

            //return q;
        }

        public void InputSecurityAnswer(string a)
        {
            var securityAnswer = Browser.FindElement(By.Id("SecurityAnswer"), "Security Answer", 0);
            Command.SendKeys(securityAnswer, a, "Security Answer");
        }

        public void InputBirthDate(string bd)
        {
            var birthDate = Browser.FindElement(By.Id("DateOfBirth"), "Birth Date", 0);
            Command.SendKeys(birthDate, bd, "Birth Date");
        }

        public void ClickAgreedToTerms()
        {
            var agreedToTerms = Browser.FindElement(By.Id("AgreedToTerms"), "Agreed to Terms", 0);
            Command.Click(agreedToTerms, "Agreed to Terms");
        }

        public void ClickMyProfileSubmit()
        {
            var myProfileSubmit = Browser.FindElement(By.Id("myProfileSubmit"), "My Profile Submit", 0);
            Command.Click(myProfileSubmit, "My Profile Submit");
        }

        public bool CheckIfLoggedIn()
        {

            try
            {
                Browser.FindElement(By.XPath("//*[@id='my-account']//*[contains(text(),'Logout')]"), "Logout text", 30);

                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
