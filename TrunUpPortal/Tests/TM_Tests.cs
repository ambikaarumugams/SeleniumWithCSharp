using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrunUpPortal.Pages;
using TrunUpPortal.Utilities;

namespace TrunUpPortal.Tests
{
    [TestFixture]                                       //Instead of main method
    public class TM_Tests:CommonDriver

    {
        [SetUp]
        public void SetUpSteps()
        {
            //Open the chrome browser
            driver = new ChromeDriver();

            //Login page object initialization and definition
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginActions(driver);

            //Home page object initialization and definition
            HomePage homePageObj = new HomePage();
            homePageObj.NavigateToTMPage(driver);
        }

        [Test]
        public void CreateTime_Test()
        {
            //Time and Materials page object initialization and definition
            TimeAndMaterialPage timeAndMaterialPageObj = new TimeAndMaterialPage();
            var createdRecord=timeAndMaterialPageObj.CreateTimeRecord(driver);
            Assert.That(createdRecord, Is.Not.Null);
            Assert.That(createdRecord.Text, Is.EqualTo("TA_002"));
           
        }

        [Test]
        public void EditTime_Test()
        {
            TimeAndMaterialPage timeAndMaterialPageObj = new TimeAndMaterialPage();
            timeAndMaterialPageObj.EditTimeAndMaterial(driver);

        }
        [Test]
        public void DeleteTime_Test()
        {
            TimeAndMaterialPage timeAndMaterialPageObj = new TimeAndMaterialPage();
            timeAndMaterialPageObj.DeleteTimeAndMaterial(driver);
        }

        [TearDown]
        public void CloseTestRun()
        {
            //driver.Quit();
        }
    }
}
