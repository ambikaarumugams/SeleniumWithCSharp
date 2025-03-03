using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrunUpPortal.Utilities;

namespace TrunUpPortal.Pages
{
    public class HomePage : CommonDriver

    {
        IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        //Navigate to Time and Material Page
        private IWebElement administrationTab => driver.FindElement(By.XPath("//a[normalize-space()='Administration']"));
        private IWebElement timeAndMaterialsLink => driver.FindElement(By.XPath("//a[normalize-space()='Time & Materials']"));

        //Click on Administration link
        public void ClickAdminLink()
        {
            administrationTab.Click();
        }


        //Click on Tim&Materials link
        public void ClickTimeAndMaterialsLink()
        {
            timeAndMaterialsLink.Click();
        }

        public void GoToTimeAndMaterials()
        {
            administrationTab.Click();
            timeAndMaterialsLink.Click();
        }
    }


}

