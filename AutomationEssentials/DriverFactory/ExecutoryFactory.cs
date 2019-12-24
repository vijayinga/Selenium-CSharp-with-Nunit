using AutomationEssentials.Browser;
using AutomationEssentials.Configurations;
using OpenQA.Selenium;
using System.Threading;

namespace AutomationEssentials.DriverFactory
{
    public class ExecutoryFactory
    {
        private static ThreadLocal<object> storedDriver = new ThreadLocal<object>();


        public static DriverType GetDriver<DriverType>()
        {
            return (DriverType)DriverStored;
        }

        public static object DriverStored
        {
            get
            {
                if (storedDriver == null)
                    return null;
                else
                    return storedDriver.Value;
            }
            set
            {
                storedDriver.Value = value;
            }
        }

        public static void InitDriver(BrowserType browser, Configuration config = null)
        {
            config = config ?? new Configuration();
            switch (browser)
            {
                case BrowserType.Chrome:
                   ChromeBrowserDriver  chrmoedriverInstance = new ChromeBrowserDriver();
                    chrmoedriverInstance.InitDriver(config);
                    DriverStored = chrmoedriverInstance.Driver;
                    break;

                case BrowserType.FireFox:
                    FirefoxBrowserDriver firefoxdriverInstance = new FirefoxBrowserDriver();
                    firefoxdriverInstance.InitDriver(config);
                    DriverStored = firefoxdriverInstance.Driver;
                    break;

            }

        }

        public static void CloseDriver()
        {
            IWebDriver driver = (IWebDriver)DriverStored;
            driver.Quit();
            DriverStored = null;
        }


    }
}
