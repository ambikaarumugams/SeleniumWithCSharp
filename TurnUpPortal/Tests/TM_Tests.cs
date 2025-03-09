using NUnit.Framework;
using TurnUpPortal.Pages;
using TurnUpPortal.Utilities;

namespace TurnUpPortal.Tests
{
    [TestFixture]
    public class TM_Tests:CommonDriver

    {
        private void Login()
        {
            //Login page object initialization and definition
            LoginPage loginPageObj = new LoginPage(driver);
            loginPageObj.Login("Hari", "123123");

            //Assertion
            string loggedInMsg = loginPageObj.GetLoginText();
            Assert.That(loggedInMsg == "Hello hari!", "Actual and Expected result don't match!");
        }

        [Test]
        public void Login_Test()
        {
            Login();
        }

        [Test]
        public void Home_Test()
        {
            Login();
            //Home page object initialization and definition
            HomePage homePageObj = new HomePage(driver);
            homePageObj.GoToTimeAndMaterials();
            
            //Assertion
            bool createNewMsgDisplayed = homePageObj.CreateBtnDisplayed();
            Assert.That(createNewMsgDisplayed == true, "Actual and Expected are not matched!");
        }

        [Test]
        public void CreateTime_Test()
        {
             Home_Test();
            //Time and Materials page object initialization and definition
            TimeAndMaterialPage timeAndMaterialPageObj = new TimeAndMaterialPage(driver);
            timeAndMaterialPageObj.CreateRecord("A_025","Automation","4000");

            //Assertion
            string newCodeTxt = timeAndMaterialPageObj.GetNewCode();
            string newDescriptionTxt = timeAndMaterialPageObj.GetNewDescription();
            string newPriceTxt = timeAndMaterialPageObj.GetNewPrice();

            Assert.That(newCodeTxt == "A_025", "Actual and Expected results don't match!");
            Assert.That(newDescriptionTxt == "Automation", "Actual and Expected results don't match!");
            Assert.That(newPriceTxt == "$4,000.00", "Actual and Expected results don't match!");
        }

        [Test]
        public void EditTime_Test()
        {
            CreateTime_Test();
            TimeAndMaterialPage timeAndMaterialPageObj = new TimeAndMaterialPage(driver);
            timeAndMaterialPageObj.Edit("A_050", "Test");

            //Assertion
            string editedCodeTxt = timeAndMaterialPageObj.GetEditedCode();
            string editedDescriptionTxt = timeAndMaterialPageObj.GetEditedDescription();

            Assert.That(editedCodeTxt == "A_050", "Actual and Expected don't match!");
            Assert.That(editedDescriptionTxt == "Test", "Actual and Expected don't match!");
        }
     
        [Test]
        public void DeleteTime_Test()
        {
            CreateTime_Test();
            TimeAndMaterialPage timeAndMaterialPageObj = new TimeAndMaterialPage(driver);
            timeAndMaterialPageObj.Delete();
                                                                                                                                                //check
            //Assertion
            string lastCodeTxt = timeAndMaterialPageObj.GetLastCode();
            string lastDescriptionTxt = timeAndMaterialPageObj.GetLastDescription();

            Assert.That(lastCodeTxt != "A_050", "Actual and Expected both are matching!");
            Assert.That(lastDescriptionTxt != "Test", "Actual and Expected both are matching!");
        }

    }
}
