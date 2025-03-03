using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TrunUpPortal.Utilities;

namespace TrunUpPortal.Pages
{

    public class TimeAndMaterialPage
    {


        public IWebElement CreateTimeRecord(IWebDriver driver)
        {

            //Click on Create New Button
            IWebElement createNewButton = driver.FindElement(By.LinkText("Create New"));
            createNewButton.Click();

            //Click on Type code drop down

            IWebElement typeCodeDropdown = driver.FindElement(By.XPath("//span[contains(text(),'select')]"));
            typeCodeDropdown.Click();

            //Select Time from the drop down

            IWebElement time = driver.FindElement(By.XPath("//li[normalize-space()='Time']"));
            time.Click();

            //Enter Code into Code text box
            IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
            codeTextbox.SendKeys("TA_002");

            //Enter description into Description text box
            IWebElement description = driver.FindElement(By.Id("Description"));
            description.SendKeys("TestAnalystProgram");

            //Enter price into the Price text box                                                                          //Tag over lapping 
            IWebElement priceOverLap = driver.FindElement(By.XPath("//input[@class='k-formatted-value k-input']"));
            priceOverLap.Click();

            IWebElement priceTextbox = driver.FindElement(By.Id("Price"));
            priceTextbox.SendKeys("5000");

            //Click save button
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();

            //Click on goto the last page button

            Wait.WaitToBeClickable(driver, "XPath", "//span[@class='k-icon k-i-seek-e']", 10);   //calling the wait method
           
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//span[@class='k-icon k-i-seek-e']"));
            goToLastPageButton.Click();

            //Check if Time record has been created successfully
            IWebElement newRecord = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
           // Console.WriteLine("Code Number:" + newRecord.Text);

            return newRecord;

            ////Validation

            
            
            //if (newRecord.Text == "TA_010")
            //{
            //    Console.WriteLine("Time record has created successfully!");
            //}
            //else
            //{
            //    Console.WriteLine("Time record hasn't created!");
            //}
        }

        //Edit the record which already exists

        public void EditTimeAndMaterial(IWebDriver driver)
        {
            //goto the last page

            Wait.WaitToBeClickable(driver, "XPath", "//span[@class='k-icon k-i-seek-e']", 10);
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//span[@class='k-icon k-i-seek-e']"));
            goToLastPageButton.Click();

            //Click on Edit button of last record

            Wait.WaitToBeClickable(driver, "XPath", "//table[@role=\"grid\"]/tbody/tr[last()]/td[5]/a[1]", 10);
          
            IWebElement editButton = driver.FindElement(By.XPath("//table[@role=\"grid\"]/tbody/tr[last()]/td[5]/a[1]"));
            editButton.Click();

            //To edit code and description page

            Wait.WaitToBeClickable(driver, "Id", "Code", 10);
           
           IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
            codeTextbox.Clear();
            codeTextbox.SendKeys("TA");

            Wait.WaitToBeClickable(driver, "Id", "Description", 10);
           
            IWebElement description = driver.FindElement(By.Id("Description"));
            description.Clear();
            description.SendKeys("Auto");

            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();

            Thread.Sleep(3000);

           


        }


        public void DeleteTimeAndMaterial(IWebDriver driver)
        {
            //Goto last page

            Wait.WaitToBeClickable(driver, "XPath", "//span[@class='k-icon k-i-seek-e']", 10);
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//span[@class='k-icon k-i-seek-e']"));
            goToLastPageButton.Click();

            //Delete the last record from the last page

            Wait.WaitToBeClickable(driver, "XPath", "//table[@role=\"grid\"]/tbody/tr[last()]/td[5]/a[2]", 10);
            IWebElement deleteButton = driver.FindElement(By.XPath("//table[@role=\"grid\"]/tbody/tr[last()]/td[5]/a[2]"));
            deleteButton.Click();
            Thread.Sleep(5000);


            //Handle the Alert

            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.AlertIsPresent());

                //Switch to alert

                IAlert alert = driver.SwitchTo().Alert();

                alert.Accept();
              //  alert.Dismiss();

                Console.WriteLine("Alert handled successfully");
            }

            catch(Exception ex)
            {
                Console.WriteLine("Alert hasn't handled" + ex.Message);
            }




        }


    }


        

}

