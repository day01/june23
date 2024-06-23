using System;
using OpenQA.Selenium.Chrome;

namespace SpecflowLikeTests.Drivers
{
    public class Driver
    {
        public ChromeDriver DriverInstance { get; set; }
        
        public void Start()
        {
            var options = new ChromeOptions();
            DriverInstance = new ChromeDriver(options);
            DriverInstance.Url = "https://specflowoss.github.io/Calculator-Demo/Calculator.html";
        }
    }
}