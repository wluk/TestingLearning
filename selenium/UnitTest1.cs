using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace selenium
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            IWebDriver browser = null;

            var b = Convert.ToInt16(Console.ReadKey());

            switch (b)
            {
                case 1:
                    var opt = new FirefoxOptions();
                    var service =
                        FirefoxDriverService.CreateDefaultService(
                            @"C:\dev\yellow\git\packages\Selenium.Firefox.WebDriver.0.16.1\driver");
                    browser = new FirefoxDriver(service, opt, Timeout.InfiniteTimeSpan);
                    break;
                case 2:
                    browser = new ChromeDriver();
                    break;
            }

            browser.Navigate().GoToUrl("www.bing.com");
            Thread.Sleep(3000);

            browser.Close();
        }
    }
}
