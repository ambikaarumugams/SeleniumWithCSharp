using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TrunUpPortal.Pages;
public class Program
{
    public static void Main(string[] args)
    {
        //Open Chrome Browser
        IWebDriver driver = new ChromeDriver();


        //Login page object initialization and definition
        LoginPage loginPageObj = new LoginPage();
        loginPageObj.LoginActions(driver);

        //Home page object initialization and definition
        HomePage homePageObj = new HomePage();
        homePageObj.NavigateToTMPage(driver);

        //Time and Materials page object initialization and definition
        TimeAndMaterialPage timeAndMaterialPageObj = new TimeAndMaterialPage();
        timeAndMaterialPageObj.CreateTimeRecord(driver);

        //Edit the existing details
        timeAndMaterialPageObj.EditTimeAndMaterial(driver);

        //Delete the record
        timeAndMaterialPageObj.DeleteTimeAndMaterial(driver);     //no such element exception

    }
}