using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace TurnUpPortal.Utilities
{
    public class CommonDriver
    {
        public static IWebDriver driver;

        [SetUp]
        public void SetUpSteps()
        {
            //Open the chrome browser
            driver = new ChromeDriver();

            //Launch TurnUp Portal
            driver.Navigate().GoToUrl("http://horse.industryconnect.io/");
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void CloseTestRun()
        {
          //  driver.Quit();
        }
    }
}