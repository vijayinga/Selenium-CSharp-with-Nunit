﻿using AutomationEssentials.Configurations;
using AutomationEssentials.DriverFactory;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace AutomationEssentials.Browser
{
    public class ChromeBrowserDriver : IDrivers
    {
        public string FOLDER_PATH
        {
            get; set;
        }

        public object Driver { get; set; }

        public object DriverServices
        {
            get
            {
                ChromeDriverService service = ChromeDriverService.CreateDefaultService(FOLDER_PATH);
                service.HideCommandPromptWindow = false;
                service.SuppressInitialDiagnosticInformation = true;
                return service;
            }
        }

        public object DesiredCapabilities
        {
            get
            {
                ChromeOptions opts = new ChromeOptions();
                return opts;
            }
        }

        public void InitDriver(Configuration config)
        {
            FOLDER_PATH = config.DRIVER_EXE_FOLDER;
            config.DesiredCapabilities = config.DesiredCapabilities ?? DesiredCapabilities;
            config.DriverServices = config.DriverServices ?? DriverServices;
            IWebDriver driver = new ChromeDriver((ChromeDriverService)config.DriverServices, (ChromeOptions)config.DesiredCapabilities, TimeSpan.FromSeconds(60));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(Configuration.PageLoadTimeout);
                        Driver = driver;
        }


    }
}
