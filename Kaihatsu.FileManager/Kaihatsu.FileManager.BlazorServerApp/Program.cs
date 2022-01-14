using Kaihatsu.FileManager.BlazorServerApp.Data;
using Kaihatsu.FileManager.Business;
using Kaihatsu.FileManager.Business.History;
using Kaihatsu.FileManager.Business.ItemBaseProcessing;
using Kaihatsu.FileManager.Business.Navigation;
using Kaihatsu.FileManager.Business.SearchService;
using Kaihatsu.FileManager.Core.Abstraction;
using Kaihatsu.FileManager.Core.Abstraction.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddNavigationHistory();
builder.Services.AddNavigation();
builder.Services.AddProcessing();
builder.Services.AddSearch();

//builder.Services.AddSingleton<OperationsFactory>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
