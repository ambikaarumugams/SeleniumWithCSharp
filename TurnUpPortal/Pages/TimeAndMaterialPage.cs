using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TurnUpPortal.Utilities;

namespace TurnUpPortal.Pages
{
    public class TimeAndMaterialPage
    {
       private readonly IWebDriver driver;

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
        private IWebElement goToLastPageButton => driver.FindElement(By.XPath("//span[@class='k-icon k-i-seek-e']"));
        private IWebElement newCode => driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
        private IWebElement newDescription => driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));
        private IWebElement newPrice => driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[4]"));


        //Methods
        public void ClickCreateNewButton()
        {
            Wait.WaitToBeClickable(driver,"LinkText", "Create New", 5);
            createNewButton.Click();
        }

        public void ClickTypeCodeDropdown()
        {
            Wait.WaitToBeClickable(driver,"XPath","//span[contains(text(),'select')]",5);
            typeCodeDropdown.Click();
        }

        public void ClickTime()
        {
            Wait.WaitToBeClickable(driver,"XPath","//li[normalize-space()='Time']",5);
            time.Click();
        }

        public void EnterCode(string code)
        {
            Wait.WaitToBeVisible(driver, "Id","Code",5);
            codeTextBox.SendKeys(code);
        }

        public void EnterDescription(string description)
        {
            Wait.WaitToBeVisible(driver, "Id", "Description", 5);
            descriptionTextBox.SendKeys(description);
        }

        public void EnterPrice(string price)
        {
            Wait.WaitToBeClickable(driver, "XPath", "//input[@class='k-formatted-value k-input']", 5);
            priceOverLap.Click();
            Wait.WaitToBeVisible(driver, "Id", "Price", 5);
            priceTextbox.SendKeys(price);
        }

        public void ClickSaveButton()
        {
            Wait.WaitToBeClickable(driver, "Id", "SaveButton", 5);
            saveButton.Click();
        }

        public void ClickGoToLastPageButton()
        {
            Wait.WaitToBeClickable(driver, "XPath", "//span[@class='k-icon k-i-seek-e']", 5);
            goToLastPageButton.Click();
        }

        public string GetNewCode()
        {
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]", 5);
            return newCode.Text;
        }

        public string GetNewDescription()
        {
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]", 5);
            return newDescription.Text;
        }

        public string GetNewPrice()
        {
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[4]", 5);
            return newPrice.Text;
        }


        //Combined all methods
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
        private IWebElement editedCode => driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
        private IWebElement editedDescription => driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));


        //Edit Methods
        public void ClickEditButton()
        {
            Wait.WaitToBeClickable(driver, "XPath", "//table[@role=\"grid\"]/tbody/tr[last()]/td[5]/a[1]", 5);
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

        public string GetEditedCode()
        {
            Wait.WaitToBeVisible(driver,"XPath", "//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]", 5);
            return editedCode.Text;
        }

        public string GetEditedDescription()
        {
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]", 5);
            return editedDescription.Text;
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
        private IWebElement lastCode => driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
        private IWebElement lastDescription => driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));


        //Delete Methods 
        public void ClickDeleteButton()
        {
            Wait.WaitToBeClickable(driver, "XPath", "//table[@role=\"grid\"]/tbody/tr[last()]/td[5]/a[2]", 5);
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

        public string GetLastCode()
        {
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]", 5);
            return lastCode.Text;
        }

        public string GetLastDescription()
        {
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]", 5);
            return lastDescription.Text;
        }

        //Combined all delete methods
        public void Delete()
        {
            ClickGoToLastPageButton();
            ClickDeleteButton();
            ClickAlert();
            ClickGoToLastPageButton();
        } 
    }
}






