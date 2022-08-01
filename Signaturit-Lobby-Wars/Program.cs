using Microsoft.OpenApi.Models;
using Signaturit_Lobby_Wars.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Dependency injection
builder.Services.AddSingleton<ILawsuits, Lawsuits>();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Signaturi Lobby Wars API",
        Description = "Signaturi Lobby Wars API",
        Contact = new OpenApiContact
        {
            Name = "Signaturit Company",
            Email = string.Empty,
            Url = new Uri("https://www.signaturit.com/es/"),
        }

    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
