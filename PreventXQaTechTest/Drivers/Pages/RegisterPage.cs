using OpenQA.Selenium;
using PreventXQaTechTest.Drivers.Base;
using PreventXQaTechTest.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace PreventXQaTechTest.Drivers.Pages
{
    class RegisterPage : BasePage
    {
        //list of identifiers for all static elements on page
        //About you
        private By firstNameText = By.Id("contentBody_txtFirstName");
        private By firstNameContainer = By.XPath("//input[@id='contentBody_txtFirstName']/..");
        private By firstNameErrorIcon = By.XPath("//span[@id='contentBody_valFirstName']/span[@class='glyphicon glyphicon-remove form-control-feedback']");
        private By lastNameText = By.Id("contentBody_txtLastName");
        private By lastNameContainer = By.XPath("//input[@id='contentBody_txtLastName']/..");
        private By lastNameErrorIcon = By.XPath("//span[@id='contentBody_valLastName']/span[@class='glyphicon glyphicon-remove form-control-feedback']");
        private By genderIdentitySelect = By.Id("contentBody_drpGender");
        private By genderIdentityContainer = By.XPath("//select[@id = 'contentBody_drpGender']/..");
        private By genderFreeText = By.Id("contentBody_txtGenderOther");
        private By sexAssignedSelect = By.Id("contentBody_drpAssignedSex");
        private By sexAssignedContainer = By.XPath("//select[@id='contentBody_drpAssignedSex']/..");
        private By partnerSexSelect = By.Id("contentBody_drpPartnerSex");
        private By partnerSexContainer = By.XPath("//select[@id='contentBody_drpPartnerSex']/..");
        private By dobDaySelect = By.Id("contentBody_drpDay");
        private By dobMonthSelect = By.Id("contentBody_drpMonth");
        private By dobYearSelect = By.Id("contentBody_drpYear");
        private By dobContainer = By.XPath("//select[@id='contentBody_drpDay']/../..");
        private By ethnicitySelect = By.Id("contentBody_drpEthnicity");
        private By ethnicityContainer = By.XPath("//select[@id='contentBody_drpEthnicity']/..");
        private By countryOfBirthSelect = By.Id("contentBody_drpBirthCountry");

        //Where you live
        private By address1Text = By.Id("contentBody_ctlContact_txtAddress1");
        private By address1Container = By.XPath("//input[@id='contentBody_ctlContact_txtAddress1']/..");
        private By address1ErrorIcon = By.XPath("//span[@id='contentBody_ctlContact_valAddress1']/span");
        private By address2Text = By.Id("contentBody_ctlContact_txtAddress2");
        private By townCityText = By.Id("contentBody_ctlContact_txtTownCity");
        private By townCityContainer = By.XPath("//input[@id='contentBody_ctlContact_txtAddress2']/..");
        private By townCityErrorIcon = By.XPath("//span[@id='contentBody_ctlContact_valTownCity']/span");
        private By countyText = By.Id("contentBody_ctlContact_txtCounty");
        private By postcodeText = By.Id("contentBody_ctlContact_txtPostCode");
        private By postcodeContainer = By.XPath("//input[@id='contentBody_ctlContact_txtPostCode']/..");
        private By postcodeErrorIcon = By.XPath("//span[@id='contentBody_ctlContact_valPostcode']/span");
        private By lookupButton = By.Id("contentBody_ctlContact_btnLookup");

        //Contact preferences
        private By emailAddressText = By.Id("contentBody_txtEmailAddress");
        private By emailAddressContainer = By.XPath("//input[@id='contentBody_txtEmailAddress']/..");
        private By emailAddressErrorIcon = By.XPath("//input[@id='contentBody_txtEmailAddress']/../span[contains(@class,'glyphicon')]");
        private By mobileNumberText = By.Id("contentBody_txtMobileNumber");
        private By mobileNumberContainer = By.XPath("//input[@id='contentBody_txtMobileNumber']/..");
        private By mobileNumberErrorIcon = By.XPath("//input[@id='contentBody_txtMobileNumber']/../span[contains(@class,'glyphicon')]");
        private By contactPreferenceBothInput = By.Id("contentBody_radContactPreference_0");
        private By contactPreferenceSmsInput = By.Id("contentBody_radContactPreference_1");
        private By contactPreferenceEmailInput = By.Id("contentBody_radContactPreference_2");
        private By contactPreferenceContainer = By.XPath("//ul[@id='contentBody_radContactPreference']/..");
        private By contactPreferenceErrorIcon = By.XPath("//ul[@id='contentBody_radContactPreference']/../span[contains(@class,'glyphicon')]");

        //Your password
        private By passwordText = By.Id("contentBody_txtPassword");
        private By passwordContainer = By.XPath("//input[@id='contentBody_txtPassword']/../..");
        private By passwordErrorIcon = By.XPath("//input[@id='contentBody_txtPassword']/../span[contains(@class,'glyphicon')]");
        private By passwordVerdict = By.XPath("//span[@class='password-verdict']");
        private By confirmPasswordText = By.Id("contentBody_txtPasswordConfirm");
        private By confirmPasswordContainer = By.XPath("//input[@id='contentBody_txtPasswordConfirm']/..");
        private By confirmPasswordErrorIcon = By.XPath("//input[@id='contentBody_txtPasswordConfirm']/../span[contains(@class,'glyphicon')]");

        //Agree & consent
        private By researchConsentCheckBox = By.Id("contentBody_chkResearchConsent");
        private By termsConsentCheckBox = By.Id("contentBody_chkTerms");
        private By registerButton = By.Id("contentBody_btnRegister");
        private By registerErrorMessage = By.Id("contentBody_lblError");

        public RegisterPage(BaseDriver driver) : base(driver)
        { }

        //About you
        public void FillFirstName(string firstName)
        {
            EnterText(firstNameText, firstName);
        }

        public bool FirstNameCheckErrorIsDisplayed()
        {
            bool errorsDisplayed = true;
            if (GetAttributeFromElement(firstNameErrorIcon, "style").Contains("visibility:hidden;"))
            {
                errorsDisplayed = false;
            }
            if (!GetAttributeFromElement(firstNameContainer, "class").Contains("has-error has-feedback"))
            {
                errorsDisplayed = false;
            }

            return errorsDisplayed;
        }

        public bool FirstNameCheckErrorIsNotDisplayed()
        {
            bool errorsDisplayed = true;
            if (GetAttributeFromElement(firstNameErrorIcon, "style").Contains("visibility: visible;"))
            {
                errorsDisplayed = false;
            }
            if (!GetAttributeFromElement(firstNameContainer, "class").Contains("has-error has-feedback"))
            {
                errorsDisplayed = false;
            }

            return errorsDisplayed;
        }

        public void FillLastName(string lastName)
        {
            EnterText(lastNameText, lastName);
        }

        public bool LastNameCheckErrorIsDisplayed()
        {
            bool errorsDisplayed = true;
            if (GetAttributeFromElement(lastNameErrorIcon, "style").Contains("visibility:hidden;"))
            {
                errorsDisplayed = false;
            }
            if (!GetAttributeFromElement(lastNameContainer, "class").Contains("has-error has-feedback"))
            {
                errorsDisplayed = false;
            }

            return errorsDisplayed;
        }

        public bool LastNameCheckErrorIsNotDisplayed()
        {
            bool errorsDisplayed = true;
            if (GetAttributeFromElement(lastNameErrorIcon, "style").Contains("visibility: visible;"))
            {
                errorsDisplayed = false;
            }
            if (!GetAttributeFromElement(lastNameContainer, "class").Contains("has-error has-feedback"))
            {
                errorsDisplayed = false;
            }

            return errorsDisplayed;
        }

        public void SelectGenderIdentity(string gender)
        {

            try
            {
                SelectByTextFromDropdown(genderIdentitySelect, gender);
            }
            catch (NoSuchElementException)
            {
                logger.Info("Option not found, setting gender as free text");
                SelectByTextFromDropdown(genderIdentitySelect, "Other Gender (free text)");
                EnterText(genderFreeText, gender);
            }
            catch (Exception e)
            {
                logger.Error(e);
            }
        }

        public bool GenderIdentityCheckErrorIsDisplayed()
        {
            bool errorsDisplayed = true;
            if (!GetAttributeFromElement(genderIdentityContainer, "class").Contains("form-group has-error has-feedback"))
            {
                errorsDisplayed = false;
            }
            
            return errorsDisplayed;
        }

        public bool GenderIdentityCheckErrorIsNotDisplayed()
        {
            return !GenderIdentityCheckErrorIsDisplayed();
        }

        public void SelectAssignedSex(string assignedSex)
        {
            SelectByTextFromDropdown(sexAssignedSelect, assignedSex);
        }

        public bool AssignedSexCheckErrorIsDisplayed()
        {
            bool errorsDisplayed = true;
            if (!GetAttributeFromElement(sexAssignedContainer, "class").Contains("form-group has-error has-feedback"))
            {
                errorsDisplayed = false;
            }

            return errorsDisplayed;
        }

        public bool AssignedSexCheckErrorIsNotDisplayed()
        {
            return !AssignedSexCheckErrorIsDisplayed();
        }

        public void SelectPartnerSex(string partnerSex)
        {
                SelectByTextFromDropdown(partnerSexSelect, partnerSex);
        }

        public bool PartnerSexCheckErrorIsDisplayed()
        {
            bool errorsDisplayed = true;
            if (!GetAttributeFromElement(partnerSexContainer, "class").Contains("form-group has-error has-feedback"))
            {
                errorsDisplayed = false;
            }

            return errorsDisplayed;
        }

        public bool PartnerSexCheckErrorIsNotDisplayed()
        {
            return !PartnerSexCheckErrorIsDisplayed();
        }

        public void SetDateOfBirth(DateTime dateOfBirth)
        {
            SetDateOfBirth(dateOfBirth.Day, dateOfBirth.Month, dateOfBirth.Year);
        }

        public void SetDateOfBirth(int day, int month, int year)
        {
            SelectByValueFromDropdown(dobDaySelect, day.ToString());
            SelectByValueFromDropdown(dobMonthSelect, month.ToString());
            SelectByValueFromDropdown(dobYearSelect, year.ToString());
        }

        public void SetDateOfBirth(int age, int plusDays)
        {
            SetDateOfBirth(DateTime.Today.AddYears(-age).AddDays(plusDays));
        }

        public bool DateOfBirthCheckErrorIsDisplayed()
        {
            bool errorsDisplayed = true;
            if (!GetAttributeFromElement(dobContainer, "class").Contains("row has-error has-feedback"))
            {
                errorsDisplayed = false;
            }

            return errorsDisplayed;
        }

        public bool DateOfBirthCheckErrorIsNotDisplayed()
        {
            return !DateOfBirthCheckErrorIsDisplayed();
        }

        public void SelectEthnicity(string ethnicity)
        {
            SelectByTextFromDropdown(ethnicitySelect, ethnicity);
        }

        public bool EthnicityCheckErrorIsDisplayed()
        {
            bool errorsDisplayed = true;
            if (!GetAttributeFromElement(ethnicityContainer, "class").Contains("form-group has-error has-feedback"))
            {
                errorsDisplayed = false;
            }

            return errorsDisplayed;
        }

        public bool EthnicityCheckErrorIsNotDisplayed()
        {
            return !EthnicityCheckErrorIsDisplayed();
        }

        public void SelectCountryOfBirth(string countryOfBirth)
        {
            SelectByTextFromDropdown(countryOfBirthSelect, countryOfBirth);
        }

        //Where you live
        public void FillAddress1(string address1)
        {
            EnterText(address1Text, address1);
        }

        public bool Address1CheckErrorIsDisplayed()
        {
            bool errorsDisplayed = true;
            if (!GetAttributeFromElement(address1Container, "class").Contains("col-sm-9 has-error has-feedback"))
            {
                errorsDisplayed = false;
            }
            if (!GetAttributeFromElement(address1ErrorIcon, "style").Contains("visibility: visible;"))
            {
                errorsDisplayed = false;
            }
            return errorsDisplayed;
        }

        public bool Address1CheckErrorIsNotDisplayed()
        {
            bool errorsDisplayed = true;
            if (GetAttributeFromElement(address1Container, "class").Contains("col-sm-9 has-error has-feedback"))
            {
                errorsDisplayed = false;
            }
            if (GetAttributeFromElement(address1ErrorIcon, "style").Contains("visibility: visible;"))
            {
                errorsDisplayed = false;
            }
            return errorsDisplayed;
        }

        public void FillAddress2(string address2)
        {
            EnterText(address2Text, address2);
        }

        public void FillTownCity(string townCity)
        {
            EnterText(townCityText, townCity);
        }

        public bool TownCityCheckErrorIsDisplayed()
        {
            bool errorsDisplayed = true;
            if (!GetAttributeFromElement(townCityContainer, "class").Contains("col-sm-9 has-error has-feedback"))
            {
                errorsDisplayed = false;
            }
            if (!GetAttributeFromElement(townCityErrorIcon, "style").Contains("visibility: visible;"))
            {
                errorsDisplayed = false;
            }
            return errorsDisplayed;
        }

        public bool TownCityCheckErrorIsNotDisplayed()
        {
            bool errorsDisplayed = true;
            if (GetAttributeFromElement(townCityContainer, "class").Contains("col-sm-9 has-error has-feedback"))
            {
                errorsDisplayed = false;
            }
            if (GetAttributeFromElement(townCityErrorIcon, "style").Contains("visibility: visible;"))
            {
                errorsDisplayed = false;
            }
            return errorsDisplayed;
        }

        public void FillCounty(string county)
        {
            EnterText(countyText, county);
        }

        public void FillPostcode(string postcode)
        {
            EnterText(postcodeText, postcode);
        }

        public bool PostcodeCheckErrorIsDisplayed()
        {
            bool errorsDisplayed = true;
            if (!GetAttributeFromElement(townCityContainer, "class").Contains("col-sm-9 has-error has-feedback"))
            {
                errorsDisplayed = false;
            }
            if (!GetAttributeFromElement(townCityErrorIcon, "style").Contains("visibility: visible;"))
            {
                errorsDisplayed = false;
            }
            return errorsDisplayed;
        }

        public bool PostcodeCheckErrorIsNotDisplayed()
        {
            bool errorsDisplayed = true;
            if (GetAttributeFromElement(townCityContainer, "class").Contains("col-sm-9 has-error has-feedback"))
            {
                errorsDisplayed = false;
            }
            if (GetAttributeFromElement(townCityErrorIcon, "style").Contains("visibility: visible;"))
            {
                errorsDisplayed = false;
            }
            return errorsDisplayed;
        }

        public void FillEmailAddress(string emailAddress)
        {
            EnterText(emailAddressText, emailAddress);
        }

        public bool EmailAddressCheckErrorIsDisplayed()
        {
            bool errorsDisplayed = true;
            if (!GetAttributeFromElement(emailAddressContainer, "class").Contains("em has-error has-feedback"))
            {
                errorsDisplayed = false;
            }
            if (!GetAttributeFromElement(emailAddressErrorIcon, "style").Contains("display: block;"))
            {
                errorsDisplayed = false;
            }
            return errorsDisplayed;
        }

        public bool EmailAddressCheckErrorIsNotDisplayed()
        {
            bool errorsDisplayed = true;
            if (GetAttributeFromElement(emailAddressContainer, "class").Contains("em has-error has-feedback"))
            {
                errorsDisplayed = false;
            }
            if (GetAttributeFromElement(emailAddressErrorIcon, "style").Contains("display: block;"))
            {
                errorsDisplayed = false;
            }
            return errorsDisplayed;
        }

        public void FillMobileNumber(string mobileNumber)
        {
            EnterText(mobileNumberText, mobileNumber);
        }

        public bool MobileNumberCheckErrorIsDisplayed()
        {
            bool errorsDisplayed = true;
            if (!GetAttributeFromElement(mobileNumberContainer, "class").Contains("has-error has-feedback"))
            {
                errorsDisplayed = false;
            }
            if (!GetAttributeFromElement(mobileNumberErrorIcon, "style").Contains("display: block;"))
            {
                errorsDisplayed = false;
            }
            return errorsDisplayed;
        }

        public bool MobileNumberCheckErrorIsNotDisplayed()
        {
            bool errorsDisplayed = true;
            if (GetAttributeFromElement(mobileNumberContainer, "class").Contains("has-error has-feedback"))
            {
                errorsDisplayed = false;
            }
            if (GetAttributeFromElement(mobileNumberErrorIcon, "style").Contains("display: block;"))
            {
                errorsDisplayed = false;
            }
            return errorsDisplayed;
        }

        public void SelectContactMethod(string contactMethod)
        {
            switch (contactMethod)
            {
                case "SMS":
                    ClickElement(contactPreferenceSmsInput);
                    break;
                case "Both":
                    ClickElement(contactPreferenceBothInput);
                    break;
                case "Email":
                    ClickElement(contactPreferenceEmailInput);
                    break;
                default:
                    throw new Exception("Unrecognised contact method");            }
        }

        public bool ContactMethodCheckErrorIsDisplayed()
        {
            bool errorsDisplayed = true;
            if (!GetAttributeFromElement(contactPreferenceContainer, "class").Contains("form-group has-error has-feedback"))
            {
                errorsDisplayed = false;
            }
            if (!GetAttributeFromElement(contactPreferenceErrorIcon, "style").Contains("display: block;"))
            {
                errorsDisplayed = false;
            }
            return errorsDisplayed;
        }

        public bool ContactMethodCheckErrorIsNotDisplayed()
        {
            bool errorsDisplayed = true;
            if (GetAttributeFromElement(contactPreferenceContainer, "class").Contains("form-group has-error has-feedback"))
            {
                errorsDisplayed = false;
            }
            if (GetAttributeFromElement(contactPreferenceErrorIcon, "style").Contains("display: block;"))
            {
                errorsDisplayed = false;
            }
            return errorsDisplayed;
        }

        public void FillPassword(string password)
        {
            EnterText(passwordText, password);
        }

        public bool PasswordCheckErrorIsDisplayed()
        {
            bool errorsDisplayed = true;
            if (!GetAttributeFromElement(passwordContainer, "class").Contains("has-error has-feedback"))
            {
                errorsDisplayed = false;
            }
            if (!GetAttributeFromElement(passwordErrorIcon, "style").Contains("display: block;"))
            {
                errorsDisplayed = false;
            }
            return errorsDisplayed;
        }

        public bool PasswordCheckErrorIsNotDisplayed()
        {
            bool errorsDisplayed = true;
            if (GetAttributeFromElement(passwordContainer, "class").Contains("has-error has-feedback"))
            {
                errorsDisplayed = false;
            }
            if (GetAttributeFromElement(passwordErrorIcon, "style").Contains("display: block;"))
            {
                errorsDisplayed = false;
            }
            return errorsDisplayed;
        }

        public void FillConfirmPassword(string confirmPassword)
        {
            EnterText(confirmPasswordText, confirmPassword);
        }

        public bool ConfirmPasswordCheckErrorIsDisplayed()
        {
            bool errorsDisplayed = true;
            if (!GetAttributeFromElement(confirmPasswordContainer, "class").Contains("has-error has-feedback"))
            {
                errorsDisplayed = false;
            }
            if (!GetAttributeFromElement(confirmPasswordErrorIcon, "style").Contains("display: block;"))
            {
                errorsDisplayed = false;
            }
            return errorsDisplayed;
        }

        public bool ConfirmPasswordCheckErrorIsNotDisplayed()
        {
            bool errorsDisplayed = true;
            if (GetAttributeFromElement(confirmPasswordContainer, "class").Contains("has-error has-feedback"))
            {
                errorsDisplayed = false;
            }
            if (GetAttributeFromElement(confirmPasswordErrorIcon, "style").Contains("display: block;"))
            {
                errorsDisplayed = false;
            }
            return errorsDisplayed;
        }

        public void ClickResearchConsent()
        {
            ClickElement(researchConsentCheckBox);
        }

        public void ClickAcceptTerms()
        {
            ClickElement(termsConsentCheckBox);
        }

        public bool TermsCheckErrorIsDisplayed()
        {
            bool errorsDisplayed = true;
            if (!GetAttributeFromElement(confirmPasswordContainer, "text").Contains("You must agree to our terms of use and privacy policy."))
            {
                errorsDisplayed = false;
            }
            
            return errorsDisplayed;
        }

        public bool TermsCheckErrorIsNotDisplayed()
        {
            bool errorsDisplayed = true;
            if (GetAttributeFromElement(confirmPasswordContainer, "text").Contains("You must agree to our terms of use and privacy policy."))
            {
                errorsDisplayed = false;
            }
            
            return errorsDisplayed;
        }

        public void ClickRegister()
        {
            ClickElement(registerButton);
        }

        public void PopulateField(RegisterField field, string value)
        {
            switch (field)
            {
                case RegisterField.Address1:
                    FillAddress1(value);
                    break;
                case RegisterField.Address2:
                    FillAddress2(value);
                    break;
                case RegisterField.AssignedSex:
                    SelectAssignedSex(value);
                    break;
                case RegisterField.ConfirmPassword:
                    FillConfirmPassword(value);
                    break;
                case RegisterField.ContactPreference:
                    SelectContactMethod(value);
                    break;
                case RegisterField.CountryOfBirth:
                    SelectCountryOfBirth(value);
                    break;
                case RegisterField.County:
                    FillCounty(value);
                    break;
                case RegisterField.DateOfBirth:
                    if (value.Contains("/"))
                    {
                        String[] dateParts = value.Split("/");
                        SetDateOfBirth(int.Parse(dateParts[0]), int.Parse(dateParts[1]), int.Parse(dateParts[2])); 
                    }
                    else if (value.Contains(","))
                    {
                        int index = value.IndexOf(",");
                        int age = int.Parse(value.Substring(0, index));
                        int addDays;
                            if (value.Contains("-"))
                        {
                            addDays = -int.Parse(value.Substring(index + 1, value.Length).Replace("-", ""));
                        }
                            else
                        {
                            addDays = int.Parse(value.Substring(index + 1, value.Length).Replace("+", ""));
                        }
                        SetDateOfBirth(age, addDays);
                    }
                    else
                    {
                        SetDateOfBirth(int.Parse(value), 0);
                    }
                    break;
                case RegisterField.EmailAddress:
                    FillEmailAddress(value);
                    break;
                case RegisterField.Ethnicity:
                    SelectEthnicity(value);
                    break;
                case RegisterField.FirstName:
                    FillFirstName(value);
                    break;
                case RegisterField.Gender:
                    SelectGenderIdentity(value);
                    break;
                case RegisterField.LastName:
                    FillLastName(value);
                    break;
                case RegisterField.MobileNumber:
                    FillMobileNumber(value);
                    break;
                case RegisterField.PartnerSex:
                    SelectPartnerSex(value);
                    break;
                case RegisterField.Password:
                    FillPassword(value);
                    break;
                case RegisterField.Postcode:
                    FillPostcode(value);
                    break;
                case RegisterField.TownCity:
                    FillTownCity(value);
                    break;
                case RegisterField.ResearchConsent:
                    if (value.ToLower().Contains("yes") || value.ToLower().Contains("true"))
                    {
                        ClickResearchConsent();
                    }
                    break;
                case RegisterField.Terms:
                    if (value.ToLower().Contains("yes") || value.ToLower().Contains("true"))
                    {
                        ClickAcceptTerms();
                    }
                    break;
            }
        }

        public void FillRegisterFormFromTestData(int testCaseId)
        {
            //todo
        }
    }
}
