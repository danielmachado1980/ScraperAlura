using ScraperAlura.DI;

var builder = WebApplication.CreateBuilder(args);

// Configuração e DI
builder.Services.AddModuleRpa(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "ScraperAlura API v1");
        c.RoutePrefix = string.Empty; // faz o swagger abrir na raiz /
    });
}

app.UseAuthorization();
app.MapControllers();

app.Run();
