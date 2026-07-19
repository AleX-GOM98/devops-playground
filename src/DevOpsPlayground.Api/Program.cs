using DevOpsPlayground.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using DevOpsPlayground.Application.Clientes.Interfaces;
using DevOpsPlayground.Application.Clientes.Services;
using DevOpsPlayground.Application.Produtos.Interfaces;
using DevOpsPlayground.Application.Produtos.Services;
using DevOpsPlayground.Application.Pedidos.Interfaces;
using DevOpsPlayground.Application.Pedidos.Services;
using DevOpsPlayground.Api.Middlewares;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IProdutoService, ProdutoService>();
builder.Services.AddScoped<IPedidoService, PedidoService>();
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("Postgres")));

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var errors = context.ModelState
            .Where(x => x.Value?.Errors.Count > 0)
            .Select(x => new
            {
                Campo = x.Key,
                Erros = x.Value!.Errors.Select(e => e.ErrorMessage)
            });

        return new BadRequestObjectResult(new
        {
            Message = "Erro de validação.",
            Errors = errors
        });
    };
});
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsEnvironment("Docker"))
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpsRedirection();
app.MapHealthChecks("/health");
app.MapControllers();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
