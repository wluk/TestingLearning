using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace UI_TEST
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver browser = null;

            Console.Write("Select browser: 1. ff, 2. ch: ");
            var b = Convert.ToInt16(Console.ReadLine());

            switch (b)
            {
                case 1:
                    var optionsFirefox = new FirefoxOptions();
                    var serviceFirefox = FirefoxDriverService.CreateDefaultService();
                    //    FirefoxDriverService.CreateDefaultService(
                    //        @"C:\dev\yellow\git\packages\Selenium.Firefox.WebDriver.0.16.1\driver");
                    browser = new FirefoxDriver(serviceFirefox, optionsFirefox, Timeout.InfiniteTimeSpan);
                    break;
                case 2:
                    var optionsChrome = new ChromeOptions();
                    var serviceChrome = ChromeDriverService.CreateDefaultService();
                    browser = new ChromeDriver(serviceChrome, optionsChrome, Timeout.InfiniteTimeSpan);
                    break;
            }

            if (browser == null) return;
            browser.Navigate().GoToUrl("www.bing.com");
            Thread.Sleep(3000);

            browser.Close();
        }
    }
}
