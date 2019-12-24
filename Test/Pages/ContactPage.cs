using AutomationEssentials.SeleniumOperations;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace Test.Pages
{
    public class ContactPage
    {
        private SeleniumMethod page;
       public ContactPage()
        {
            page = new SeleniumMethod();
        }

        private readonly By _contactLink = By.XPath("//a[@title='Contact us']");
        private readonly By _homeContent = By.XPath("//div[@id='htmlcontent_home']//li");
        private readonly By _search = By.Id("search_query_top");


        public void NavigateToContactUs()
        {
            IWebElement element = page.WaitForElement(_contactLink);            
            page.MoveToElement(_contactLink);
            
        }

        public void VerifyCountofProductLinks(string count)
        {
            List<IWebElement> elements = page.WaitForElements(_homeContent);
            Assert.True(elements.Count == 5);
        }

        public void VerifySearchProduct(string productName)
        {
            page.SendValuesToWebElement(_search, productName);
            Assert.AreEqual("Test", page.WaitForElement(_search).GetAttribute("value"));
        }


    }
}
