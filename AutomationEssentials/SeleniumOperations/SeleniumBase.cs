using AutomationEssentials.Configurations;
using AutomationEssentials.DriverFactory;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AutomationEssentials.SeleniumOperations
{
    public class SeleniumMethod
    {

        private IWebDriver driver = ExecutoryFactory.GetDriver<IWebDriver>();
        private readonly double _driverTimeout = Configuration.PageLoadTimeout;
        private readonly int _pollingInterval = 500;
                     
        public void NavigateTo(string url)
        {
            driver.Navigate().GoToUrl(url);
        }
          
                          
        public void SendValuesToWebElement(By by, string value)
        {
            WaitForElement(by).SendKeys(value);
        }                 
                      
              
        public IWebElement WaitForElement(By by)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(_driverTimeout));
            if (_pollingInterval > 0)
            {
                wait.PollingInterval = TimeSpan.FromMilliseconds(_pollingInterval);
            }

            IWebElement element = wait.Until(d => driver.FindElement(by));
            return element;
        }

        
        public List<IWebElement> WaitForElements(By by)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(_driverTimeout));
            if (_pollingInterval > 0)
            {
                wait.PollingInterval = TimeSpan.FromMilliseconds(_pollingInterval);
            }

            IReadOnlyCollection<IWebElement> elements = wait.Until(d => driver.FindElements(by));
            return elements.ToList();
        }
         
              
        public void MoveToElement(By by)
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(IsElementDisplayed(by)).Build().Perform();
        }

        
        
        public void ScrollToElement(By by)
        {
            int scrollBy = IsElementEnabled(by).Location.Y + 25;
            GetJavaScriptExecutor().ExecuteScript("window.scrollBy(0," + scrollBy + ");");
        }


        
        public IJavaScriptExecutor GetJavaScriptExecutor()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            return js;
        }    
       


        
        private IWebElement IsElementDisplayed(By by)
        {
            IWebElement element = WaitForElement(by);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(_driverTimeout));
            wait.Until(e => element.Displayed);
            return element;
        }

        
        private IWebElement IsElementEnabled(By by)
        {
            IWebElement element = IsElementDisplayed(by);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(_driverTimeout));
            wait.Until(e => element.Enabled);
            return element;
        }

        
    }



}

