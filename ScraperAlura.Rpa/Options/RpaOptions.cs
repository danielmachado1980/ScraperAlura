namespace ScraperAlura.Rpa.Options
{
    public class RpaOptions
    {
        public bool Headless { get; set; } = false;
        public int NavegacaoTimeoutMs { get; set; } = 15000;
        public UrlOptions Urls { get; set; } = new UrlOptions();
    }

    public class UrlOptions
    {
        public string AluraBusca { get; set; } = "https://www.alura.com.br/busca";
    }
}