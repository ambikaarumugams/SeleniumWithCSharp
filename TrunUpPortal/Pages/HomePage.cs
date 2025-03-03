using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrunUpPortal.Pages
{
    public class HomePage 

    {
        public void NavigateToTMPage(IWebDriver driver)
        {
            //Navigate to Time and Material Page
            IWebElement administrationTab = driver.FindElement(By.XPath("//a[normalize-space()='Administration']"));
            administrationTab.Click();

            //Click on Tim&Materials link
            IWebElement timeAndMaterialsLink = driver.FindElement(By.XPath("//a[normalize-space()='Time & Materials']"));
            timeAndMaterialsLink.Click();
        }

    }
}
