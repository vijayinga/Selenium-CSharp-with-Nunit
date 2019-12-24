﻿using AutomationEssentials.Configurations;
using AutomationEssentials.DriverFactory;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;

namespace AutomationEssentials.Browser
{
    class FirefoxBrowserDriver : IDrivers
    {
        public string FOLDER_PATH
        {
            get; set;
        }
        public object DesiredCapabilities
        {
            get
            {
                FirefoxOptions opts = new FirefoxOptions();
                opts.AcceptInsecureCertificates = true;
                opts.PageLoadStrategy = PageLoadStrategy.Eager;
                opts.AcceptInsecureCertificates = true;
                return opts;
            }
        }

        public object Driver
        {
            get; set;
        }

        public object DriverServices
        {
            get
            {

                FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(FOLDER_PATH);
                service.SuppressInitialDiagnosticInformation = true;
                return service;

            }
        }

        public void InitDriver(Configuration config)
        {
            FOLDER_PATH = config.DRIVER_EXE_FOLDER;
            config.DriverServices = config.DriverServices ?? DriverServices;
            config.DesiredCapabilities = config.DesiredCapabilities ?? DesiredCapabilities;
            IWebDriver driver = new FirefoxDriver((FirefoxDriverService)config.DriverServices, (FirefoxOptions)config.DesiredCapabilities, TimeSpan.FromSeconds(60));
            driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(Configuration.PageLoadTimeout);
                       Driver = driver;
        }


    }
}
