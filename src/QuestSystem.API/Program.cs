using System.Text.Encodings.Web;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using QuestSystem.API.Middleware;
using QuestSystem.Data.Identities;
using QuestSystem.Domain.Abstractions;
using QuestSystem.Infrastructure.Repositories;
using QuestSystem.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Logging.ClearProviders();
builder.Logging.AddJsonConsole(options =>
{
    options.UseUtcTimestamp = true;
    options.TimestampFormat = "yyyy-MM-dd HH:mm:ss";
    options.JsonWriterOptions = new JsonWriterOptions
    {
        Indented = true,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
    };
});
builder.Services.AddControllers();
builder.Services.AddSwaggerDocument(options =>
{
    options.PostProcess = document =>
    {
        document.Info = new NSwag.OpenApiInfo
        {
            Title = "Quest System Api.",
            Version = "v1",
            Description = "An ASP.NET Core Web API for quest system api."
        };
    };
});

builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IQuestRepository, QuestRepository>();
builder.Services.AddScoped<IQuestService, QuestService>();
builder.Services.AddDbContext<QuestSystemDbContext>(options =>
{
    _ = options.UseNpgsql(builder.Configuration.GetConnectionString("Quests"));
});
var app = builder.Build();
app.UseOpenApi();
if (app.Environment.IsDevelopment())
{
    _ = app.UseSwagger();
    _ = app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
