using Guide.Translate.AntiCorruption.Facade;
using Guide.Translate.Business.Interfaces.External;
using Guide.Translate.Business.Interfaces.Services;
using Guide.Translate.Business.Services;
using Microsoft.AspNetCore.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Program));

// Services
builder.Services.AddScoped<ITranslateService, TranslateService>();

//Facades
builder.Services.AddScoped<IGPTFacade, GPTFacade>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

