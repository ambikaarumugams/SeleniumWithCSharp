using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TrunUpPortal.Utilities;

namespace TrunUpPortal.Pages
{
    public class LoginPage : CommonDriver
    {
        IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement userNameTextbox => driver.FindElement(By.Id("UserName"));
        private IWebElement passwordTextbox => driver.FindElement(By.Id("Password"));
        private IWebElement loginBtn => driver.FindElement(By.XPath("//*[@id='loginForm']/form/div[3]/input[1]"));


        //enter valid username

        public void EnterUserName(string username)
        {
            userNameTextbox.SendKeys(username);
        }


        //enter valid password
        public void EnterPassword(string password)
        {
            passwordTextbox.SendKeys(password);
        }

        //click login button
        public void ClickLoginButton()
        {
            loginBtn.Click();
        }

        //Combined all methods
        public void Login(string username, string password)
        {
            EnterUserName(username);
            EnterPassword(password);
            ClickLoginButton();
        }
    }
}




