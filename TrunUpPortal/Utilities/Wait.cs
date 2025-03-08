using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrunUpPortal.Utilities
{
    public class Wait
    {
        //Generic functions to wait for an element to be clickable

        public static void WaitToBeClickable(IWebDriver driver,string locatorType,string locatorValue,int seconds)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, seconds));
            if(locatorType == "XPath")
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(locatorValue)));
            }

            if (locatorType == "Id")
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(locatorValue)));
            }
        }
        
           
       

    }
}
