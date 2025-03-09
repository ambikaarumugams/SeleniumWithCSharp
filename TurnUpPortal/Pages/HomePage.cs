using OpenQA.Selenium;
using TurnUpPortal.Utilities;

namespace TurnUpPortal.Pages
{
    public class HomePage

    {
        private readonly IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        //Navigate to Time and Material Page
        private IWebElement administrationTab => driver.FindElement(By.XPath("//a[normalize-space()='Administration']"));
        private IWebElement timeAndMaterialsLink => driver.FindElement(By.XPath("//a[normalize-space()='Time & Materials']"));
        private IWebElement Create => driver.FindElement(By.XPath("//a[normalize-space()='Create New']"));

        //Click on Administration link
        public void ClickAdminLink()
        {
            Wait.WaitToBeClickable(driver, "XPath", "//a[normalize-space()='Administration']", 5);
            administrationTab.Click();
        }


        //Click on Tim&Materials link
        public void ClickTimeAndMaterialsLink()
        {
            Wait.WaitToBeVisible(driver, "XPath", "//a[normalize-space()='Time & Materials']", 5);
            timeAndMaterialsLink.Click();
        }

        public bool CreateBtnDisplayed()
        {
            return Create.Displayed;
        }


        //Combined all the methods
        public void GoToTimeAndMaterials()
        {
            administrationTab.Click();
            timeAndMaterialsLink.Click();
           
        }
    }


}

