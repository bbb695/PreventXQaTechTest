using PreventXQaTechTest.Drivers.Base;
using PreventXQaTechTest.Drivers.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace PreventXQaTechTest.Drivers
{
    class PagesFramework
    {
        public Pages pages;
        public BaseDriver driver;
        public Workflows workflows;

        public PagesFramework(BaseDriver driver)
        {
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
