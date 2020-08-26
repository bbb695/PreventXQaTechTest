using PreventXQaTechTest.Drivers.Base;
using PreventXQaTechTest.Drivers.Pages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace PreventXQaTechTest.Drivers
{
    class PagesFramework
    {
        public Pages pages;
        public BaseDriver driver;
        //public Workflows workflows;
        public XDocument testData;

        public PagesFramework(BaseDriver driver)
        {
            this.testData = XDocument.Load(Path.GetFullPath(@"C:\TestData\AutomationTest.xml"));
            this.driver = driver;
            this.pages = new Pages(this.driver);
            //this.workflows = new Workflows();
        }

        public class Pages
        {
            public RegisterPage registerPage;

            public Pages(BaseDriver driver)
            {
                registerPage = new RegisterPage(driver);
            }
        }

        public class Workflows
        {
            
        }
    }
}
