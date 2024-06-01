using RestaurantApp.WebServer.Pages;
using RestaurantApp.CrossCuting.DependenciesApp;
using Microsoft.FluentUI.AspNetCore.Components;
using RestaurantApp.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

// Serviço para FluentUI
builder.Services.AddFluentUIComponents();
builder.Services.AddScoped<IDialogService, DialogService>();
builder.Services.AddScoped<IToastService, ToastService>();

// Registrar os serviços
var connectionString = builder.Configuration.GetConnectionString("MySql");
builder.Services.AddInfrastructure(options =>
{
    //options.UseSqlite(builder.Configuration.GetConnectionString("Sqlite"));
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 35)));
});

// Utilizando para o envio de notificações
//builder.Services.AddSignalR();

var app = builder.Build();

//CreateDatabase(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(RestaurantApp._Imports).Assembly);

// Mapear o hub SignalR
//app.MapHub<NotificationHub>("/seuHubPath");


app.Run();

static void CreateDatabase(WebApplication app)
{
    var serviceScope = app.Services.CreateScope();
    var dataContext = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
    dataContext?.Database.EnsureCreated();
}


