using OpenQA.Selenium;
using TrunUpPortal.Utilities;

namespace TrunUpPortal.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        //Locators
        private IWebElement userNameTextbox => driver.FindElement(By.Id("UserName"));
        private IWebElement passwordTextbox => driver.FindElement(By.Id("Password"));
        private IWebElement loginBtn => driver.FindElement(By.XPath("//*[@id='loginForm']/form/div[3]/input[1]"));


        //Enter valid username

        public void EnterUserName(string username)
        {
            Wait.WaitToBeVisible(driver, "Id", "UserName", 5);
            userNameTextbox.SendKeys(username);
        }


        //Enter valid password
        public void EnterPassword(string password)
        {
            Wait.WaitToBeVisible(driver, "Id", "Password", 5);
            passwordTextbox.SendKeys(password);
        }

        //Click login button
        public void ClickLoginButton()
        {
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id='loginForm']/form/div[3]/input[1]", 5);
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




