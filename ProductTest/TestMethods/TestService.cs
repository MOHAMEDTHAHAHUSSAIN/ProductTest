using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProductTest.TestMethods
{
    public class TestService
    {
        private IWebDriver WebDriver;

        public TestService(IWebDriver driver)
        {
            WebDriver = driver;
        }

        public void login(IWebDriver webDriver)
        {
            IWebElement ele = webDriver.FindElement(By.XPath("//*[@id=\"signin-email\"]"));
            ele.SendKeys("a.hyder");

            Thread.Sleep(1000);

            IWebElement ele1 = webDriver.FindElement(By.XPath("//*[@id=\"signin-password\"]"));
            ele1.SendKeys("123456");

            Thread.Sleep(1000);

            var ele2 = webDriver.FindElement(By.XPath("//*[@id=\"Login\"]"));
            ele2.Click();
        }

        public void logout(IWebDriver webDriver)
        {
            Thread.Sleep(2000);
            //Menu button
            webDriver.FindElement(By.XPath("//*[@class=\"user-account top_user-account\"]/a")).Click();

            Thread.Sleep(2000);

            var logout = webDriver.FindElement(By.XPath("//*[text()='Logout ']"));
            logout.Click();
        }

        public void CreateAgent()
        {
            WebDriver.Navigate().GoToUrl("https://test.arco.sa/System/#/System/Recruitment/Agent");
            Thread.Sleep(4000);

            //IWebElement menu = webDriver.FindElement(By.XPath("//*[@class=\"navbar-btn\"]/button[@class=\"btn-toggle-offcanvas\"]"));
            IWebElement menu = WebDriver.FindElement(By.XPath(".//*[@id=\"main-content\"]/div/app-module-index/app-dynamic-list/div[1]/div[2]/div/div[1]/div/div[2]/div/div/div/button[1]"));
            menu.Click();

            //Thread.Sleep(2000);

            //var AgentName = WebDriver.FindElement(By.Id("AgentName"));
            //AgentName.SendKeys("Ibrahim");

            //var LicenseNumber = WebDriver.FindElement(By.Id("LicenseNumber"));
            //LicenseNumber.SendKeys("8335043");

            //var Country = WebDriver.FindElement(By.XPath(".//*[@id=\"cdk-drop-list-5\"]/div[1]/div[1]/app-dropdown-field/div/div[2]/div/div[1]/label"));
            //Country.Click();

            //Thread.Sleep(6000);

            //var CountryTable = WebDriver.FindElements(By.XPath("//div[@class=\"control-table autoComplete_dropdown tree-table\"]/table/tbody/tr/td/span")).ElementAt(5);
            //CountryTable.Click();

            //Thread.Sleep(2000);

            //var uploadAttachment = WebDriver.FindElement(By.XPath(".//Input[@id=\"file_10\"]"));
            //uploadAttachment.SendKeys("C:/Users/FAAZ1/Documents/mt.txt");

            //Thread.Sleep(2000);

            //var submit = WebDriver.FindElement(By.XPath("//app-ticket-create/div/div/div[2]/button[1]"));
            //submit.Click();

            Thread.Sleep(2000);
        }

        public void CreateCandidate(IWebDriver driver = null)
        {
            Thread.Sleep(2000);
            WebDriver.Navigate().GoToUrl("https://test.arco.sa/System/#/System/Recruitment/Candidate");

            Thread.Sleep(5000);

            //Click Add Button
            WebDriver.FindElement(By.XPath("//button[@class=\"view_text\"][1]")).Click();

            Thread.Sleep(2000);

            var CandidateName = WebDriver.FindElement(By.XPath("//*[@Id=\"Name\"]"));
            CandidateName.SendKeys("Test Candidate");


            //AgentId
            ClickDropdown(0, 7,6);

            //sector
            ClickDropdown(5,1);
            Thread.Sleep(3000);

            // submit 
            WebDriver.FindElement(By.XPath("//app-ticket-create/div/div/div[2]/button[1]")).Click();
        }

        public void CreateRecuritmentRequest()
        {
            Thread.Sleep(2000);
            WebDriver.Navigate().GoToUrl("https://test.arco.sa/System/#/System/Recruitment/RecruitmentRequest");
            Thread.Sleep(2000);

            WebDriver.Navigate().Refresh();

            Thread.Sleep(5000);
            //Click Add Button
            WebDriver.FindElement(By.XPath("//button[@class=\"view_text\"][1]")).Click();

            Thread.Sleep(2000);

            var RequestName = WebDriver.FindElement(By.XPath("//*[@Id=\"Description\"]"));
            RequestName.SendKeys("Test Automation 1");

            Thread.Sleep(2000);

            //WebDriver.FindElement(By.XPath("//*[@Id=\"StartDate\"]")).Click();
            //Thread.Sleep(2000);
            //WebDriver.FindElement(By.XPath("//bs-days-calendar-view//table//tbody/tr[2]/td[6]/span")).Click();

            ClickCalender("StartDate", 2, 6);


            //RequestedBy 
            ClickDropdown(0, 2);

            //Sector 
            ClickDropdown(1, 2);

            Thread.Sleep(2000);

            // submit 
            WebDriver.FindElement(By.XPath("//app-ticket-create//button[1]")).Click();
        }

        public void CreateRecuritmentRequestLines()
        {

            Thread.Sleep(2000);
            WebDriver.Navigate().GoToUrl("https://test.arco.sa/System/#/System/Recruitment/RecruitmentRequest?RequestId=100");
            Thread.Sleep(2000);

            WebDriver.FindElement(By.XPath("//app-dynamic-list/div[1]/div/div/div[1]/div/div[2]/div/div/div/button[1]")).Click();

            var NoOfEmployees = WebDriver.FindElement(By.XPath("//*[@Id=\"NoOfEmployees\"]"));
            NoOfEmployees.SendKeys("10");


            ClickDropdown(1, 2);


            ClickDropdown(2, 6);

            // submit 
            WebDriver.FindElement(By.XPath("//app-ticket-create//button[1]")).Click();
        }

        public void CreateDemmandLetter()
        {
            Thread.Sleep(2000);
            WebDriver.Navigate().GoToUrl("https://test.arco.sa/System/#/System/Recruitment/RecruitmentRequest?RequestId=100");
            Thread.Sleep(2000);

        }

        public void CreateDemmandLetterLines()
        {


        }

        public void ClickDropdown(int LableIndex,int ValueIndex,int pagination = 0)
        {
            Thread.Sleep(3000);
            //WebDriver.FindElements(By.XPath(Xpath)).ElementAt(index).Click();
            WebDriver.FindElements(By.XPath("//app-dropdown-field//div[@class=\"control-input\"]/label")).ElementAt(LableIndex).Click();
            if (pagination > 0)
            {
                Thread.Sleep(3000);
                WebDriver.FindElement(By.XPath($"//pagination-template//li[{pagination}]")).Click();
            }
            Thread.Sleep(3000);
            //WebDriver.FindElements(By.XPath("//div[@class=\"control-table autoComplete_dropdown tree-table\"]//tbody//td/span")).ElementAt(ValueIndex).Click();
            WebDriver.FindElement(By.XPath($"//app-dropdown-field//table//tbody/tr[{ValueIndex}]/td/span")).Click();
        }

        public void ClickCalender(string Id,int row,int col)
        {
            Thread.Sleep(3000);
            WebDriver.FindElement(By.XPath($"//*[@Id=\"{Id}\"]")).Click();
            Thread.Sleep(2000);
            WebDriver.FindElement(By.XPath($"//bs-days-calendar-view//table//tbody/tr[{row}]/td[{col}]/span")).Click();
        }

    }
}
