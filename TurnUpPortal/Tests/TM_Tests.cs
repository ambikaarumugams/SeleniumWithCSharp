using NUnit.Framework;
using TurnUpPortal.Pages;
using TurnUpPortal.Utilities;

namespace TurnUpPortal.Tests
{

    // [TestFixture]                                     -  Non -Parameterized TestFixture

    [TestFixture("Chrome", "http://horse.industryconnect.io/", "hari", "123123")]        // Parameterized - DDT
    [TestFixture("Edge", "http://horse.industryconnect.io/", "hari", "123123")]
    //[TestFixture("Firefox", "http://horse.industryconnect.io/", "hari", "123123")]    //install firefox

    public class TM_Tests:CommonDriver
    {
        private readonly string _username;
        private readonly string _password;

        public TM_Tests(string browser, string url,string username, string password) : base(browser, url)
        {
            _username = username;
            _password = password;
        }

        //[TestCase("Hari", "123123")]                                        - passed
        private void Login()
        {
            //Login page object initialization and definition
            LoginPage loginPageObj = new LoginPage(driver);
            loginPageObj.Login(_username,_password);

            //Assertion
            string loggedInMsg = loginPageObj.GetLoginText();
            Assert.That(loggedInMsg == "Hello hari!", "Actual and Expected result don't match!");
        }

        [Test, Order(1)]
        [Category("smoke")]                    //Category to group the tests
        public void Login_Test()
        {
            Login();
        }

        [Test, Order(2)]
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

        [TestCase("A_030"), Order(3)]
        public void CreateTime_Test(string code)
        {
             Home_Test();
            //Time and Materials page object initialization and definition
            TimeAndMaterialPage timeAndMaterialPageObj = new TimeAndMaterialPage(driver);
            timeAndMaterialPageObj.CreateRecord(code,"Automation","4000");

            //Assertion
            string newCodeTxt = timeAndMaterialPageObj.GetNewCode();
            string newDescriptionTxt = timeAndMaterialPageObj.GetNewDescription();
            string newPriceTxt = timeAndMaterialPageObj.GetNewPrice();

            Assert.That(newCodeTxt == code, "Actual and Expected results don't match!");
            Assert.That(newDescriptionTxt == "Automation", "Actual and Expected results don't match!");
            Assert.That(newPriceTxt == "$4,000.00", "Actual and Expected results don't match!");
        }

        [Test, Order(4)]
        public void EditTime_Test()
        {
            string code = "A_050";
            CreateTime_Test(code);
            TimeAndMaterialPage timeAndMaterialPageObj = new TimeAndMaterialPage(driver);
            timeAndMaterialPageObj.Edit(code, "Test");

            //Assertion
            string editedCodeTxt = timeAndMaterialPageObj.GetEditedCode();
            string editedDescriptionTxt = timeAndMaterialPageObj.GetEditedDescription();

            Assert.That(editedCodeTxt == code, "Actual and Expected don't match!");
            Assert.That(editedDescriptionTxt == "Test", "Actual and Expected don't match!");
        }
     
        [Test, Order(5)]
        [Category("Regression")]
        public void DeleteTime_Test()
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 101);
            string code = $"A_{randomNumber}";
            CreateTime_Test(code);
            TimeAndMaterialPage timeAndMaterialPageObj = new TimeAndMaterialPage(driver);
            timeAndMaterialPageObj.Delete();
                                                                                                                                                
            string lastCodeTxt = timeAndMaterialPageObj.GetLastCode();
            Assert.That(lastCodeTxt,Does.Not.Contain(code), "Record was not deleted!");
        }

    }
}
