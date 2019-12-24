using AutomationEssentials.Configurations;
using AutomationEssentials.DriverFactory;
using NUnit.Framework;


namespace Test
{

    public  class BasePage
    {
        BrowserType browser = BrowserType.Chrome;    


        [SetUp]
        public void InitalizeAutomationFramework()
        {
            ExecutoryFactory.InitDriver(browser);
        }
       
        [TearDown]
        public void CloseBrowser()
        {
            ExecutoryFactory.CloseDriver();
        }


    }
}
