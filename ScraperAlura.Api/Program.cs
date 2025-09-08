using ScraperAlura.DI;

var builder = WebApplication.CreateBuilder(args);

// Configuração e DI
builder.Services.AddModuleRpa(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "ScraperAlura API", Version = "v1" });

    // Caminho do arquivo XML com comentários
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "ScraperAlura API v1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseAuthorization();
app.MapControllers();

app.Run();
