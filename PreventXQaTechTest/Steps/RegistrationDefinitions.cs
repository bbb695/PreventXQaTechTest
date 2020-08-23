using PreventXQaTechTest.Drivers;
using PreventXQaTechTest.Drivers.Pages;
using PreventXQaTechTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace PreventXQaTechTest.Steps
{
    [Binding]
    public sealed class RegistrationDefinitions
    {

        private PagesFramework pagesFramework = new PagesFramework(new Drivers.Base.BaseDriver(Drivers.Base.BaseDriver.DriverType.Chrome, "https://www.sh.uk/register"));

        public RegistrationDefinitions(ScenarioContext scenarioContext)
        {
            
        }

        [Given("the data from test case (.*) is entered")]
        public void GivenTheDataFromTestCaseIsEntered(int number)
        {
            //TODO:
            
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
            //TODO: implement assert (verification) logic

            
        }

        [Then("the (.*) field should display an error")]
        public void ThenTheFieldShouldDisplayAnError(RegisterField errorField)
        {
            //TODO: implement assert (verification) logic

            
        }

        [Given("the register page is displayed")]
        public void GivenTheRegisterPageIsDisplayed()
        {
            pagesFramework.driver.GoToBaseURL();
        }
    }
}
