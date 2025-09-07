using OpenQA.Selenium;
using ScraperAlura.Domain.Entities;
using ScraperAlura.Domain.Interfaces;
using ScraperAlura.Rpa.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScraperAlura.Rpa.Selenium
{
    public class AluraScraper : ICursoScraper
    {
        private readonly IWebDriverFactory _factory;
        public AluraScraper(IWebDriverFactory factory) => _factory = factory;

        public Task<IReadOnlyList<Curso>> BuscarAsync(string termo)
        {
            using var driver = _factory.Criar();
            driver.Navigate().GoToUrl($"https://www.alura.com.br/busca?query={termo}");

            var cursos = driver.FindElements(By.CssSelector(".busca-resultado a"))
                .Select(el => new Curso
                {
                    Titulo = el.Text,
                    Url = el.GetAttribute("href")
                })
                .ToList();

            return Task.FromResult<IReadOnlyList<Curso>>(cursos);
        }
    }
}
