using Microsoft.Extensions.Options;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ScraperAlura.Rpa.Interfaces;
using ScraperAlura.Rpa.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScraperAlura.Rpa.Selenium
{
    public class WebDriverFactory : IWebDriverFactory
    {
        private readonly RpaOptions _opts;
        public WebDriverFactory(IOptions<RpaOptions> opts) => _opts = opts.Value;

        public IWebDriver Criar()
        {
            var options = new ChromeOptions();
            if (_opts.Headless)
                options.AddArgument("--headless=new");

            var driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(_opts.NavegacaoTimeoutMs);
            return driver;
        }
    }
}
