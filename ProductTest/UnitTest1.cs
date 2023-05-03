using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics.Metrics;
using static System.Net.WebRequestMethods;
using ProductTest.TestMethods;

namespace ProductTest
{
    public class Tests
    {
        private TestService testservice;
        IWebDriver webDriver;
        [SetUp]
        public void Setup()
        {
            webDriver = new ChromeDriver();
            testservice = new TestService(webDriver);
        }

        [Test]
        public void Test1()
        {
           
            webDriver.Url = "https://test.arco.sa/System/#/System/login";
            webDriver.Manage().Window.Maximize();

            Thread.Sleep(1000);

            testservice.login(webDriver);
            
            Thread.Sleep(2000);
            //webDriver.Navigate().Refresh();

            //IWebElement Mainmenu = webDriver.FindElement(By.XPath(".//*[@id=\"wrapper\"]/app-topnav/nav/div/div[1]/button[1]"));
            //Mainmenu.Click();

            Thread.Sleep(2000);

           // testservice.CreateAgent();

            //testservice.CreateCandidate();

            Thread.Sleep(5000);

            //testservice.CreateRecuritmentRequest();

            testservice.CreateRecuritmentRequestLines();

            testservice.logout(webDriver);

            // Assert.Pass();
        }


    }
}