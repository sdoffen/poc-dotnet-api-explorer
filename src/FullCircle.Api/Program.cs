using FullCircle.Api.Configuration;
using FullCircle.Extensions.ProblemDetails;
using FullCircle.Extensions.WebApi;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.ConfigureVcaOpenApi(builder.Configuration);
builder.Services.ConfigureVcaProblemDetails();

builder.Services.ConfigureOptions<RouteOptionsConfigurator>();
builder.Services.ConfigureOptions<MvcOptionsConfigurator>();
builder.Services.ConfigureOptions<JsonOptionsConfigurator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseVcaSwaggerUI(app.Environment.IsDevelopment());
app.UseVcaProblemDetails();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
