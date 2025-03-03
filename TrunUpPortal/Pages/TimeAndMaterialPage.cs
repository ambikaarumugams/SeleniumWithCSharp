using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Diagnostics;
using TrunUpPortal.Utilities;

namespace TrunUpPortal.Pages
{

    public class TimeAndMaterialPage : CommonDriver
    {
        private const string GoToLastButtonPath = "//span[@class='k-icon k-i-seek-e']";

        IWebDriver driver;

        public TimeAndMaterialPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        //Create functionality locators

        private IWebElement createNewButton => driver.FindElement(By.LinkText("Create New"));                         //Click on Create New Button
        private IWebElement typeCodeDropdown => driver.FindElement(By.XPath("//span[contains(text(),'select')]"));   //Click on Type code drop down
        private IWebElement time => driver.FindElement(By.XPath("//li[normalize-space()='Time']"));                //Select Time from the drop down
        private IWebElement codeTextBox => driver.FindElement(By.Id("Code"));                       // Code text box
        private IWebElement descriptionTextBox => driver.FindElement(By.Id("Description"));            // Description text box
        private IWebElement priceOverLap => driver.FindElement(By.XPath("//input[@class='k-formatted-value k-input']"));    //Tag over lapping -Price text box
        private IWebElement priceTextbox => driver.FindElement(By.Id("Price"));
        private IWebElement saveButton => driver.FindElement(By.Id("SaveButton"));               //Click save button

        // Wait.WaitToBeClickable(driver, "XPath", "//span[@class='k-icon k-i-seek-e']", 10);   //calling the wait method
        private IWebElement goToLastPageButton => driver.FindElement(By.XPath(GoToLastButtonPath));
        private IWebElement newRecord => driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));




        public void ClickCreateNewButton()
        {
            createNewButton.Click();
        }

        public void ClickTypeCodeDropdown()
        {
            typeCodeDropdown.Click();
        }

        public void ClickTime()
        {
            time.Click();
        }

        public void EnterCode(string code)
        {
            codeTextBox.SendKeys(code);
        }

        public void EnterDescription(string description)
        {
            descriptionTextBox.SendKeys(description);
        }

        public void EnterPrice(string price)
        {
            priceOverLap.Click();
            priceTextbox.SendKeys(price);
        }

        public void ClickSaveButton()
        {
            saveButton.Click();
        }

        public void ClickGoToLastPageButton()
        {
            goToLastPageButton.Click();
        }

        public void CreateRecord(string code, string description, string price)
        {
            createNewButton.Click();
            typeCodeDropdown.Click();
            time.Click();
            codeTextBox.SendKeys(code);
            descriptionTextBox.SendKeys(description);
            priceOverLap.Click();
            priceTextbox.SendKeys(price);
            saveButton.Click();
            goToLastPageButton.Click();
        }

        //Edit the record which already exists

        private IWebElement editButton => driver.FindElement(By.XPath("//table[@role=\"grid\"]/tbody/tr[last()]/td[5]/a[1]"));

        public void ClickEditButton()
        {
            editButton.Click();
        }

        public void EditCodeTextBox(string code)
        {
            codeTextBox.Clear();
            EnterCode(code);

        }

        public void EditDescriptionTextBox(string description)
        {
            descriptionTextBox.Clear();
            EnterDescription(description);

        }

        public void ClickSave()
        {
            ClickSaveButton();
        }

        //Combined all methods of edit functionality

        public void Edit(string code, string description)
        {
            ClickEditButton();
            EditCodeTextBox(code);
            EditDescriptionTextBox(description);
            ClickSave();
            ClickGoToLastPageButton();
        }


        //Delete the last record from the last page
      
        private IWebElement deleteButton => driver.FindElement(By.XPath("//table[@role=\"grid\"]/tbody/tr[last()]/td[5]/a[2]"));

        public void ClickDeleteButton()
        {
            deleteButton.Click();
        }

        public void ClickAlert()
        {
            //Handle the Alert
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.AlertIsPresent());

                //Switch to alert
                IAlert alert = driver.SwitchTo().Alert();
                alert.Accept();
                //alert.Dismiss();

                Console.WriteLine("Alert handled successfully");
            }

            catch (Exception ex)
            {
                Console.WriteLine("Alert hasn't handled" + ex.Message);
            }
        }

        //Combined all delete methods
        public void Delete()
        {
            ClickGoToLastPageButton();
            ClickDeleteButton();
            ClickAlert();
        }



    }


}






