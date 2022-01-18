using Kaihatsu.FileManager.Business.History;
using Kaihatsu.FileManager.Business.History.OperationsFactory;
using Kaihatsu.FileManager.Business.ItemBaseProcessing;
using Kaihatsu.FileManager.Business.Navigation;
using Kaihatsu.FileManager.Business.SearchService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddNavigationHistory();
builder.Services.AddNavigation();
builder.Services.AddProcessing();
builder.Services.AddSearch();
builder.Services.AddOperationsFactory();

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
