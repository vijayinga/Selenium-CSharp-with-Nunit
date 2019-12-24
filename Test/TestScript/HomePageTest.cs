using AutomationEssentials.SeleniumOperations;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using Test.Pages;

namespace Test
{
    [TestFixture]
    public class HomePageTest : BasePage
    {
        private SeleniumMethod page;      


        [SetUp]
        public void Setup()
        {
            page = new SeleniumMethod();
            page.NavigateTo("http://automationpractice.com/index.php");
        }
               

        [Test]
        public void NavigateToContactUsPage()
        {
            ContactPage contactPage = new ContactPage();

            contactPage.NavigateToContactUs();
        }

        [Test]
        public void VerifyCountofProductLinks()
        {
            ContactPage contactPage = new ContactPage();
            contactPage.VerifyCountofProductLinks("5");
        }
            
        
        [Test]
        public void VerifySearchProductFunctionality()
        {
            ContactPage contactPage = new ContactPage();
            contactPage.VerifySearchProduct("Test");
        }

      
              
      
    }
}
