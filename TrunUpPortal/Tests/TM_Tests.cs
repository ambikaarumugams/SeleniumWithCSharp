using NUnit.Framework;
using TrunUpPortal.Pages;
using TrunUpPortal.Utilities;

namespace TrunUpPortal.Tests
{
    [TestFixture]                                       //Instead of main method
    public class TM_Tests:CommonDriver

    {
        private void Login()
        {
            //Login page object initialization and definition
            LoginPage loginPageObj = new LoginPage(driver);
            loginPageObj.Login("Hari", "123123");
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
        }

        [Test]
        public void CreateTime_Test()
        {
             Home_Test();
            //Time and Materials page object initialization and definition
            TimeAndMaterialPage timeAndMaterialPageObj = new TimeAndMaterialPage(driver);
            timeAndMaterialPageObj.CreateRecord("A_025","Automation","4000");
        }

        [Test]
        public void EditTime_Test()
        {
            CreateTime_Test();
            TimeAndMaterialPage timeAndMaterialPageObj = new TimeAndMaterialPage(driver);
            timeAndMaterialPageObj.Edit("A_050", "Test");
        }
     
        [Test]
        public void DeleteTime_Test()
        {
            CreateTime_Test();
            TimeAndMaterialPage timeAndMaterialPageObj = new TimeAndMaterialPage(driver);
            timeAndMaterialPageObj.Delete();
        }

    }
}
