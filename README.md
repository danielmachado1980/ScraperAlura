# ScraperAlura

ScraperAlura é um projeto RPA/.NET que utiliza arquitetura DDD (Domain-Driven Design) e automação com Selenium para realizar scraping de cursos na plataforma Alura.

## Estrutura do Projeto

- **ScraperAlura.Domain**: Camada de domínio, contém entidades, interfaces e serviços de negócio.
- **ScraperAlura.Infra**: Implementações de repositórios e persistência.
- **ScraperAlura.Rpa**: Módulo de automação (Robotic Process Automation) usando Selenium WebDriver.
- **ScraperAlura.DI**: Configuração de injeção de dependências.
- **ScraperAlura.Api**: API REST para expor funcionalidades do scraper.
- **ScraperAlura.ConsoleApp**: Aplicação de linha de comando para execução do scraper.

## Principais Tecnologias

- [.NET 8.0](https://dotnet.microsoft.com/)
- [Selenium WebDriver](https://www.selenium.dev/)
- [Microsoft.Extensions.DependencyInjection](https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection)
- DDD (Domain-Driven Design)

## Como funciona

1. **Automação Selenium**: O módulo [`ScraperAlura.Rpa`](ScraperAlura.Rpa/) implementa o scraper usando Selenium para navegar e coletar dados dos cursos.
2. **Domínio**: Entidades como [`Curso`](ScraperAlura.Domain/Entities/Curso.cs) e interfaces como [`ICursoScraper`](ScraperAlura.Domain/Interfaces/ICursoScraper.cs) definem as regras de negócio.
3. **Injeção de Dependências**: O método [`DependencyInjection.AddModuleRpa`](ScraperAlura.DI/DependencyInjection.cs) registra todos os serviços necessários.
4. **API/Console**: O scraper pode ser executado via API REST ([`ScraperAlura.Api`](ScraperAlura.Api/)) ou CLI ([`ScraperAlura.ConsoleApp`](ScraperAlura.ConsoleApp/)).

## Como executar

1. **Pré-requisitos**: .NET 8 SDK instalado.
2. **Restaurar pacotes**:
   ```sh
   dotnet restore
   ```
3. **Build**:
   ```sh
   dotnet build
   ```
4. **Executar ConsoleApp**:
   ```sh
   dotnet run --project ScraperAlura.ConsoleApp
   ```
5. **Executar API**:
   ```sh
   $env:DOTNET_ENVIRONMENT="Development"
   dotnet run --project ScraperAlura.Api
   ```
6. **Acessar API**:
   ```sh
		http://localhost:5000
	```
## Configuração

Edite os arquivos `appsettings.json` em cada projeto para configurar URLs, timeouts e opções do Selenium.

## DDD

- **Entidades**: Representam os objetos de negócio (ex: Curso).
- **Serviços de Domínio**: Lógica de negócio centralizada.
- **Repositórios**: Abstraem o acesso a dados.

## Selenium

- Utilizado para automação de navegação e scraping.
- Implementação principal em [`AluraScraper`](ScraperAlura.Rpa/Selenium/AluraScraper.cs).
- Configuração de WebDriver via [`WebDriverFactory`](ScraperAlura.Rpa/Selenium/WebDriverFactory.cs).

## Contribuição

1. Fork o projeto
2. Crie uma branch (`git checkout -b feature/nome`)
3. Commit suas alterações
4. Envie um Pull Request

## Licença

MIT

