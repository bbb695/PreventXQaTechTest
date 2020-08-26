using NUnit.Framework;
using OpenQA.Selenium;
using PreventXQaTechTest.Drivers.Base;
using PreventXQaTechTest.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
        private By townCityContainer = By.XPath("//input[@id='contentBody_ctlContact_txtTownCity']/..");
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
        private By contactPreferenceSmsInput = By.XPath("//input[@id='contentBody_radContactPreference_1']/..");//Id("contentBody_radContactPreference_1");
        private By contactPreferenceEmailInput = By.Id("contentBody_radContactPreference_2");
        private By contactPreferenceContainer = By.XPath("//ul[@id='contentBody_radContactPreference']/..");
        private By contactPreferenceErrorIcon = By.XPath("//ul[@id='contentBody_radContactPreference']/../span[contains(@class,'glyphicon')]");

        //Your password
        private By passwordText = By.Id("contentBody_txtPassword");
        private By passwordContainer = By.XPath("//input[@id='contentBody_txtPassword']/..");
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
            if (GetAttributeFromElement(firstNameContainer, "class").Contains("has-error has-feedback"))
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
            if (GetAttributeFromElement(lastNameContainer, "class").Contains("has-error has-feedback"))
            {
                errorsDisplayed = false;
            }

            return errorsDisplayed;
        }

        public void SelectGenderIdentity(string gender)
        {

            try
            {
                SelectByIndexFromDropdown(genderIdentitySelect, int.Parse(gender));
            }
            catch (Exception)
            {
                logger.Info("Option not found, setting gender as free text");
                SelectByTextFromDropdown(genderIdentitySelect, "Other Gender (free text)");
                EnterText(genderFreeText, gender);
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
            SelectByIndexFromDropdown(sexAssignedSelect, int.Parse(assignedSex));
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
                SelectByIndexFromDropdown(partnerSexSelect, int.Parse(partnerSex));
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
            if (!GetAttributeFromElement(dobContainer, "class").Contains("has-error has-feedback"))
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
            if (!GetAttributeFromElement(ethnicityContainer, "class").Contains("has-error has-feedback"))
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
            if (!GetAttributeFromElement(address1Container, "class").Contains("has-error has-feedback"))
            {
                errorsDisplayed = false;
            }
            if (!GetAttributeFromElement(address1ErrorIcon, "style").Contains("display: block;"))
            {
                errorsDisplayed = false;
            }
            return errorsDisplayed;
        }

        public bool Address1CheckErrorIsNotDisplayed()
        {
            bool errorsDisplayed = true;
            if (GetAttributeFromElement(address1Container, "class").Contains("has-error has-feedback"))
            {
                errorsDisplayed = false;
            }
            if (GetAttributeFromElement(address1ErrorIcon, "style").Contains("display: block;"))
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
            if (!GetAttributeFromElement(townCityContainer, "class").Contains("has-error has-feedback"))
            {
                errorsDisplayed = false;
            }
            if (!GetAttributeFromElement(townCityErrorIcon, "style").Contains("display: block;"))
            {
                errorsDisplayed = false;
            }
            return errorsDisplayed;
        }

        public bool TownCityCheckErrorIsNotDisplayed()
        {
            bool errorsDisplayed = true;
            if (GetAttributeFromElement(townCityContainer, "class").Contains("has-error has-feedback"))
            {
                errorsDisplayed = false;
            }
            if (GetAttributeFromElement(townCityErrorIcon, "style").Contains("display: block;"))
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
            if (!GetAttributeFromElement(postcodeContainer, "class").Contains("has-error has-feedback"))
            {
                errorsDisplayed = false;
            }
            if (!GetAttributeFromElement(postcodeErrorIcon, "style").Contains("display: block;"))
            {
                errorsDisplayed = false;
            }
            return errorsDisplayed;
        }

        public bool PostcodeCheckErrorIsNotDisplayed()
        {
            bool errorsDisplayed = true;
            if (GetAttributeFromElement(postcodeContainer, "class").Contains("has-error has-feedback"))
            {
                errorsDisplayed = false;
            }
            if (GetAttributeFromElement(postcodeErrorIcon, "style").Contains("display: block;"))
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
            if (!GetAttributeFromElement(emailAddressContainer, "class").Contains("has-error has-feedback"))
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
            if (GetAttributeFromElement(emailAddressContainer, "class").Contains("has-error has-feedback"))
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
            if (!GetAttributeFromElement(contactPreferenceContainer, "class").Contains("has-error has-feedback"))
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
            if (GetAttributeFromElement(contactPreferenceContainer, "class").Contains("has-error has-feedback"))
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
            try
            {
                bool errorsDisplayed = true;
                if (!GetAttributeFromElement(registerErrorMessage, "text").Contains("You must agree to our terms of use and privacy policy."))
                {
                    errorsDisplayed = false;
                }

                return errorsDisplayed;
            }
            catch
            {
                return false;
            }
        }

        public bool TermsCheckErrorIsNotDisplayed()
        {
            bool errorsDisplayed = true;
            string errorText = GetAttributeFromElement(confirmPasswordContainer, "text");
            if (!String.IsNullOrEmpty(errorText) && errorText.Contains("You must agree to our terms of use and privacy policy."))
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

        public void CheckErrors(List<RegisterField> errorFields)
        {
            if (errorFields.Contains(RegisterField.Address1))
            {
                Assert.True(Address1CheckErrorIsDisplayed(), "Expected Address 1 to display error but not all parts were found");
            }
            else
            {
                Assert.True(Address1CheckErrorIsNotDisplayed(), "Expected no error for Address 1 but found one or more");
            }

            if (errorFields.Contains(RegisterField.Address2))
            {
                logger.Error("Field Address 2 has no errors to check");
            }

            if (errorFields.Contains(RegisterField.AssignedSex))
            {
                Assert.True(AssignedSexCheckErrorIsDisplayed(), "Expected Assigned Sex to display error but not all parts were found");
            }
            else
            {
                Assert.True(AssignedSexCheckErrorIsNotDisplayed(), "Expected no error for Assigned sex but found one or more");
            }

            if (errorFields.Contains(RegisterField.ConfirmPassword))
            {
                Assert.True(ConfirmPasswordCheckErrorIsDisplayed(), "Expected Confirm Password to display error but not all parts were found");
            }
            else
            {
                Assert.True(ConfirmPasswordCheckErrorIsNotDisplayed(), "Expected no error for Confirm Password but found one or more");
            }

            if (errorFields.Contains(RegisterField.ContactPreference))
            {
                Assert.True(ContactMethodCheckErrorIsDisplayed(), "Expected Contact Preference to display error but not all parts were found");
            }
            else
            {
                Assert.True(ContactMethodCheckErrorIsNotDisplayed(), "Expected no error for Contact Preference but found one or more");
            }

            if (errorFields.Contains(RegisterField.CountryOfBirth))
            {
                logger.Error("Field Country Of Birth has no errors to check");
            }

            if (errorFields.Contains(RegisterField.County))
            {
                logger.Error("Field County has no errors to check");
            }

            if (errorFields.Contains(RegisterField.DateOfBirth))
            {
                Assert.True(DateOfBirthCheckErrorIsDisplayed(), "Expected Data of Birth to display error but not all parts were found");
            }
            else
            {
                Assert.True(DateOfBirthCheckErrorIsNotDisplayed(), "Expected no error for Date of Birth but found one or more");
            }
           
            if (errorFields.Contains(RegisterField.EmailAddress))
            {
                Assert.True(EmailAddressCheckErrorIsDisplayed(), "Expected Email Address to display error but not all parts were found");
            }
            else
            {
                Assert.True(EmailAddressCheckErrorIsNotDisplayed(), "Expected no error for Email Address but found one or more");
            }

            if (errorFields.Contains(RegisterField.Ethnicity))
            {
                Assert.True(EthnicityCheckErrorIsDisplayed(), "Expected Ethnicity to display error but not all parts were found");
            }
            else
            {
                Assert.True(EthnicityCheckErrorIsNotDisplayed(), "Expected no error for Ethnicity but found one or more");
            }

            if (errorFields.Contains(RegisterField.FirstName))
            {
                Assert.True(FirstNameCheckErrorIsDisplayed(), "Expected First Name to display error but not all parts were found");
            }
            else
            {
                Assert.True(FirstNameCheckErrorIsNotDisplayed(), "Expected no error for First Name but found one or more");
            }

            if (errorFields.Contains(RegisterField.Gender))
            {
                Assert.True(GenderIdentityCheckErrorIsDisplayed(), "Expected Gender to display error but not all parts were found");
            }
            else
            {
                Assert.True(GenderIdentityCheckErrorIsNotDisplayed(), "Expected no error for Gender but found one or more");
            }

            if (errorFields.Contains(RegisterField.LastName))
            {
                Assert.True(LastNameCheckErrorIsDisplayed(), "Expected Last Name to display error but not all parts were found");
            }
            else
            {
                Assert.True(LastNameCheckErrorIsNotDisplayed(), "Expected no error for Last Name but found one or more");
            }

            if (errorFields.Contains(RegisterField.MobileNumber))
            {
                Assert.True(MobileNumberCheckErrorIsDisplayed(), "Expected Mobile Number to display error but not all parts were found");
            }
            else
            {
                Assert.True(MobileNumberCheckErrorIsNotDisplayed(), "Expected no error for Mobile Number but found one or more");
            }

            if (errorFields.Contains(RegisterField.PartnerSex))
            {
                Assert.True(PartnerSexCheckErrorIsDisplayed(), "Expected Partner Sex to display error but not all parts were found");
            }
            else
            {
                Assert.True(PartnerSexCheckErrorIsNotDisplayed(), "Expected no error for Partner Sex but found one or more");
            }

            if (errorFields.Contains(RegisterField.Password))
            {
                Assert.True(PasswordCheckErrorIsDisplayed(), "Expected Password to display error but not all parts were found");
            }
            else
            {
                Assert.True(PasswordCheckErrorIsNotDisplayed(), "Expected no error for Password but found one or more");
            }
                
            if (errorFields.Contains(RegisterField.Postcode))
            {
                Assert.True(PostcodeCheckErrorIsDisplayed(), "Expected Postcode to display error but not all parts were found");
            }
            else
            {
                Assert.True(PostcodeCheckErrorIsNotDisplayed(), "Expected no error for Postcode but found one or more");
            }

            if (errorFields.Contains(RegisterField.TownCity))
            {
                Assert.True(TownCityCheckErrorIsDisplayed(), "Expected Town/City to display error but not all parts were found");
            }
            else
            {
                Assert.True(TownCityCheckErrorIsNotDisplayed(), "Expected no error for Town/City but found one or more");
            }

            if (errorFields.Contains(RegisterField.ResearchConsent))
            {
                logger.Error("Field Country Of Birth has no errors to check");
            }
            
            if (errorFields.Contains(RegisterField.Terms))
            {
                Assert.True(TermsCheckErrorIsDisplayed(), "Expected Terms to display error but not all parts were found");
            }
            else
            {
                Assert.True(TermsCheckErrorIsNotDisplayed(), "Expected no error for Terms but found one or more");
            }
        }
    

        public void FillRegisterFormFromTestData(Dictionary<string, string> registrationData)
        {
            foreach (KeyValuePair<string, string> entry in registrationData)
            {
                if (!String.IsNullOrWhiteSpace(entry.Value))
                {
                    RegisterField field = RegisterField.NotSet;
                    
                    try
                    {
                        field = (RegisterField)Enum.Parse(typeof(RegisterField), entry.Key, true);
                    }
                    catch (Exception)
                    {
                        if (entry.Key.ToLower().Contains("age"))
                        {
                            field = RegisterField.DateOfBirth;
                        }
                    }
                    if (field != RegisterField.NotSet)
                    {
                        PopulateField(field, entry.Value);
                    }
                }
            }
        }
    }
}
