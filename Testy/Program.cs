using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Testy
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IWebDriver browser = null;

            var options = new ChromeOptions
            {
                BinaryLocation = @"C:\Users\luwe\Downloads\GoogleChromePortable57\GoogleChromePortable.exe"
            };

            var options2 = new ChromeOptions();
            
            options.AddArgument("disable-infobars");

            var service = ChromeDriverService.CreateDefaultService();

            browser = new ChromeDriver(service, options2, Timeout.InfiniteTimeSpan);
            browser.Navigate().GoToUrl("http://bing.com");
            Console.WriteLine("OK");

            Thread.Sleep(900);
            browser.Close();
        }
    }
}