using OpenQA.Selenium;
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
      //  public IWebElement codeTextbox;
       // public IWebElement description;


        public void CreateTimeRecord(IWebDriver driver)
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
            Console.WriteLine("Code Number:" + newRecord.Text);

            //Validation

            if (newRecord.Text == "TA_002")
            {
                Console.WriteLine("Time record has created successfully!");
            }
            else
            {
                Console.WriteLine("Time record hasn't created!");
            }
        }  

        //Edit the record which already exists

        public void EditTimeAndMaterial(IWebDriver driver)
        {

            //Click on Edit button

            Wait.WaitToBeClickable(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[1]", 10);
          
            IWebElement editButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
            editButton.Click();

            //To edit code and description page

            Wait.WaitToBeClickable(driver, "Id", "Code", 10);
           
           IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
            codeTextbox.Clear();
            codeTextbox.SendKeys("TA_005");

            Wait.WaitToBeClickable(driver, "Id", "Description", 10);
           
            IWebElement description = driver.FindElement(By.Id("Description"));
            description.Clear();
            description.SendKeys("Test");

            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();

            Wait.WaitToBeClickable(driver, "XPath", "//span[@class='k-icon k-i-seek-e']", 10);
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//span[@class='k-icon k-i-seek-e']"));
            goToLastPageButton.Click();


        }


        public void DeleteTimeAndMaterial(IWebDriver driver)
        {
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[9]/td[5]/a[2]", 10);
            IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[9]/td[5]/a[2]"));
            deleteButton.Click();

            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//span[@class='k-icon k-i-seek-e']"));
            goToLastPageButton.Click();



        }
       

   }


        

}

