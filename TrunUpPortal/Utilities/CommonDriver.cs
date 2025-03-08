using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Communication;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System.Configuration;


namespace TrunUpPortal.Utilities
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
            driver.Quit();
        }
    }
}