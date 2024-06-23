using Sign.Api;
using Sign.Api.Middlewares;
using Sign.BoundContext.Domain;
using Sign.BoundContext.Infrastructure;
using Sign.BoundedContext.Controllers;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{Environment.MachineName}.json", optional: true);

// Collect assemblies
var assemblies = AppDomain.CurrentDomain
    .GetAssemblies()
    .ToList();
assemblies.Add(typeof(MarkerController).Assembly);
assemblies.Add(typeof(InfrastructureMarker).Assembly);

// Configure options
var section = builder.Configuration.GetSection(nameof(SignSettings));
builder.Services.Configure<SignSettings>(section);

var settings = new SignSettings();
section.Bind(settings);

// Add controllers
builder.Services.AddControllers();

builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen();

builder.Services.AddScoped<IWeatherRepository, WeatherRepository>();

builder.Services.AddScoped<IWeatherService, WeatherService>();

builder.Services.AddAutoMapper(assemblies);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
app.UseHsts();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.Use(ExitRouteMiddleware.Handle());
app.MapControllers();

app.Run();