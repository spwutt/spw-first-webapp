using Microsoft.Extensions.Configuration;
using spw_first_webapp.Models;
using spw_first_webapp.Services;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;
var appSettingsSection = configuration.GetSection("AppSettings");
var appSettings = appSettingsSection.Get<AppSettings>();

builder.Services.AddHttpClient("myapi", c =>
{
    c.BaseAddress = new Uri(appSettings.MyAPI);
});

// Add services to the container.
builder.Services.Configure<AppSettings>(appSettingsSection);
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddHttpContextAccessor();

builder.Services.AddTransient<IProfileService, ProfileService>();
builder.Services.AddTransient<IRequestService, RequestService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
