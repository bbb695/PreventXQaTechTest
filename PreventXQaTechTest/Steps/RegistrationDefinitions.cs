using PreventXQaTechTest.Drivers;
using PreventXQaTechTest.Drivers.Pages;
using PreventXQaTechTest.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;
using TechTalk.SpecFlow;

namespace PreventXQaTechTest.Steps
{
    [Binding]
    public sealed class RegistrationDefinitions
    {

        private PagesFramework pagesFramework;
        private List<RegisterField> errorFields;
        private Dictionary<string, string> testCase;

        [Given("the data from test case (.*) is entered")]
        public void GivenTheDataFromTestCaseIsEntered(int number)
        {

            XDocument testData = pagesFramework.testData;
            var query = (IEnumerable)testData.XPathEvaluate("/Registration/TestCase[@id='" + number + "']/TestCaseData");
            
            this.testCase = query.Cast<XElement>().Elements().ToDictionary(x => x.Name.LocalName, x => x.Value);

            errorFields = new List<RegisterField>();

            foreach (string expectedError in testCase["Expected_Results_Validation"].Split(","))
            {
                errorFields.Add((RegisterField)Enum.Parse(typeof(RegisterField), expectedError, true));
            }

            pagesFramework.pages.registerPage.FillRegisterFormFromTestData(testCase);
        }

        [Given("the (.*) field is populated with (.*)")]
        public void GivenTheFieldIsPopulatedWithValue(RegisterField field, String data)
        {
            pagesFramework.pages.registerPage.PopulateField(field, data);
        }

        [When("the Register button is clicked")]
        public void WhenTheRegisterButtonIsClicked()
        {
            pagesFramework.pages.registerPage.ClickRegister();
        }

        [Then("the correct fields should display an error")]
        public void ThenTheFieldShouldDisplayAnError()
        {
            pagesFramework.pages.registerPage.CheckErrors(errorFields);

            pagesFramework.driver.QuitDriver();
        }

        [Then("only the (.*) field should display an error")]
        public void ThenOnlyTheFieldShouldDisplayAnError(RegisterField errorField)
        {
            errorFields = new List<RegisterField>();
            errorFields.Add(errorField);
            pagesFramework.pages.registerPage.CheckErrors(errorFields);
            pagesFramework.driver.QuitDriver();
        }

        [Given("the register page is displayed")]
        public void GivenTheRegisterPageIsDisplayed()
        {
            pagesFramework = new PagesFramework(new Drivers.Base.BaseDriver(Drivers.Base.BaseDriver.DriverType.Chrome, "https://www.sh.uk/register"));
            pagesFramework.driver.GoToBaseURL();
        }
    }
}
