using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;


namespace TurnUpPortal.Utilities
{
    public class CommonDriver
    {
        public static IWebDriver driver;
        public string browser;
        public string url;

        //Constructor 1
        public CommonDriver(string browser, string url)
        {
            this.browser = browser;
            this.url = url;
        }


        [SetUp]
        public void SetUpSteps()
        {
            //Open the chrome browser
           // driver = new ChromeDriver();
           switch(browser.ToLower())
            {
                case "chrome":
                    driver = new ChromeDriver();
                    break;
                case "edge":
                    driver = new EdgeDriver();
                    break;
                case "firefox":
                    driver = new FirefoxDriver();
                    break;
                default:
                    throw new ArgumentException($"Browser '{browser}' is not supported");

            }

            //Launch TurnUp Portal
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void CloseTestRun()
        {
          //  driver.Quit();
        }
    }
}