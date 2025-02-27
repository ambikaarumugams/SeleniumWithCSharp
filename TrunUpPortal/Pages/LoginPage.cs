using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrunUpPortal.Pages
{
    public class LoginPage
    {
        //Functions that allow users to login to TurnUp Portal
        public void LoginActions(IWebDriver driver)
        {
            //Launch TurnUp Portal
            driver.Navigate().GoToUrl("http://horse.industryconnect.io/");

            //To maximize the window
            driver.Manage().Window.Maximize();

            //Identify username textbox and enter valid username

            IWebElement userNameTextbox = driver.FindElement(By.Id("UserName"));
            userNameTextbox.SendKeys("Hari");


            //Identify password textbox and enter valid password

            IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
            passwordTextbox.SendKeys("123123");


            //Identify login button and click on it

            IWebElement loginBtn = driver.FindElement(By.XPath("//*[@id='loginForm']/form/div[3]/input[1]"));
            loginBtn.Click();
        }


    }
}
