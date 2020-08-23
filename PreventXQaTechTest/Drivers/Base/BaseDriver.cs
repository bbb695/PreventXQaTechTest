using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;

namespace PreventXQaTechTest.Drivers.Base
{
    public class BaseDriver
    {
        public IWebDriver webDriver { private set; get; }
        public String browserName { private set; get; }
        public String browserVersion { private set; get; }
        public ICapabilities capabilities { private set; get; }
        private string baseURL;

        public enum DriverType
        {
            Chrome,
            Ie,
            FireFox,
            Edge,
            Phantom,
            Remote
        }

        public BaseDriver(DriverType driverType, string baseURL)
        {
            this.baseURL = baseURL;
            switch (driverType)
            {
                case DriverType.Chrome:
                    ChromeOptions chromeOptions = new ChromeOptions();
                    //add chrome options here.
                    webDriver = new ChromeDriver(chromeOptions);
                    browserName = "Chrome";
                    break;
                case DriverType.Edge:
                    EdgeOptions edgeOptions = new EdgeOptions();
                    //add edge options here.
                    webDriver = new EdgeDriver(edgeOptions);
                    //capabilities = ((RemoteWebDriver)webDriver).Capabilities;
                    browserName = "Edge";
                    break;
                case DriverType.Ie:
                    InternetExplorerOptions ieOptions = new InternetExplorerOptions();
                    //add IE options here.
                    webDriver = new InternetExplorerDriver(ieOptions);
                    browserName = "IE";
                    break;
                case DriverType.FireFox:
                    FirefoxOptions fireFoxOptions = new FirefoxOptions();
                    //add firefox options here.
                    webDriver = new FirefoxDriver();
                    browserName = "FireFox";
                    break;
                case DriverType.Phantom:
                    break;
                    /*case DriverType.Remote:
                        DriverOptions driverOptions = new DriverOptions();
                        driver = new RemoteWebDriver(driverOptions);
                        break;*/
                    //TODO workout how remore driver will work.   
            }

            GoToBaseURL();
        }

        public void QuitDriver()
        {
            if (webDriver != null)
            {
                try
                {
                    webDriver.Quit();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public void Reset()
        {
            webDriver.Manage().Cookies.DeleteAllCookies();
            GoToBaseURL();
        }

        public void GoToBaseURL()
        {
            webDriver.Navigate().GoToUrl(baseURL);
        }
    }
}
