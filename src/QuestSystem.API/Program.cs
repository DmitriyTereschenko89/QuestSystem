using Microsoft.EntityFrameworkCore;
using QuestSystem.Data.Identities;
using QuestSystem.Domain.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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
builder.Services.AddDbContext<QuestSystemDbContext>(options =>
{
    _ = options.UseNpgsql(builder.Configuration.GetConnectionString("Database"));
});
var app = builder.Build();
app.UseOpenApi();
if (app.Environment.IsDevelopment())
{
    _ = app.UseSwagger();
    _ = app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
