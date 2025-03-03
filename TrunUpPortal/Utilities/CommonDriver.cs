using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;


namespace TrunUpPortal.Utilities
{


    public class CommonDriver
    {
        public static IWebDriver driver;


        [SetUp]
        public void SetUpSteps(string browser)
        {
            switch(browser.ToLower())
            {
                case "Chrome": driver = new ChromeDriver();
                    break;
                case "Firefox":
                    driver = new FirefoxDriver();
                    break;
                case "Edge": driver = new EdgeDriver();
                    break;
                default:Console.WriteLine("Invalid Browser!");
                    return;
            }

            //Open the chrome browser
           //driver = new ChromeDriver();

            //Launch TurnUp Portal
            driver.Navigate().GoToUrl("http://horse.industryconnect.io/");
            driver.Manage().Window.Maximize();

        }


        [TearDown]
        public void CloseTestRun()
        {
            driver.Quit();
        }
    }
}