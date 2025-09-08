using Microsoft.Extensions.Options;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ScraperAlura.Domain.Entities;
using ScraperAlura.Domain.Interfaces;
using ScraperAlura.Rpa.Interfaces;
using ScraperAlura.Rpa.Options;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ScraperAlura.Rpa.Selenium
{
    public class AluraScraper : ICursoScraper
    {
        private readonly IWebDriverFactory _factory;
        private readonly RpaOptions _options;

        public AluraScraper(IWebDriverFactory factory, IOptions<RpaOptions> options)
        {
            _factory = factory;
            _options = options.Value;
        }

        public Task<IReadOnlyList<Curso>> BuscarAsync(string termo)
        {
            using var driver = _factory.Criar();
            driver.Navigate().GoToUrl(_options.Urls.AluraBusca);

            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(_options.NavegacaoTimeoutMs));

            var inputBusca = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#busca-form-input")));
            inputBusca.Clear();
            inputBusca.SendKeys(termo);

            inputBusca.SendKeys(Keys.Enter);

            wait.Until(d => d.FindElements(By.CssSelector("li.busca-resultado")).Any());

            var chkCursos = wait.Until(d => d.FindElement(By.CssSelector("#type-filter--0")));

            if (!chkCursos.Selected)
            {
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", chkCursos);
            }

            // necessário porque o sub-filtro 'Cursos' não é aplicado na pesquisa ao executar a primeira busca
            var btnBuscar = driver.FindElement(By.CssSelector("input.busca-form-botao.--desktop[title='buscar']"));
            btnBuscar.Click();

            wait.Until(d => d.FindElements(By.CssSelector("li.busca-resultado")).Any());

            var cursos = driver.FindElements(By.CssSelector("li.busca-resultado"))
                .Select(li => new Curso
                {
                    Titulo = li.FindElement(By.CssSelector(".busca-resultado-nome"))
                            .Text,
                    Descricao = li.FindElement(By.CssSelector(".busca-resultado-descricao"))
                            .Text
                })
                .ToList();

            return Task.FromResult<IReadOnlyList<Curso>>(cursos);
        }
    }
}
