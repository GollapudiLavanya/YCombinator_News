using log4net;
using log4net.Repository;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace YCombinator.Base
{
    public class BaseClass
    {
        public static IWebDriver driver;
        private static readonly ILog log = LogManager.GetLogger(typeof(Tests));
        public Dictionary<int, string> mapping;

        //Get the default ILoggingRepository
        private static readonly ILoggerRepository repository = log4net.LogManager.GetRepository(Assembly.GetCallingAssembly());

        [SetUp]
        public void Setup()
        {

            log.Info("Entering Setup");

            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("start-maximized");
            chromeOptions.AddArgument("--disable-notifications");

            driver = new ChromeDriver(chromeOptions);
            driver.Url = "https://news.ycombinator.com/news";

            log.Info("Exiting setup");

        }

        [TearDown]
        public void TearDown()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
            driver.Quit();
        }
    }
}
