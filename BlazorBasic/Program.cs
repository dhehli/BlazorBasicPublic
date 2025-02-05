using BlazorBasic.Components.Account;
using BlazorBasic.Components;
using BlazorBasic.Data;
using FluentEmail.Core;
using FluentEmail.Mailgun;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DevExpress.Blazor;
using BlazorBasic.Data.Services;
using Blazorise;
using Blazorise.Tailwind;
using Blazorise.Icons.FontAwesome;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();
builder.Services.AddScoped(typeof(IMessageLocalizerHelper<>), typeof(MessageLocalizerHelper<>));

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = IdentityConstants.ApplicationScheme;
    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
})
    .AddIdentityCookies();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services
    .AddDbContextFactory<ApplicationDbContext>(options =>
        options.UseSqlServer(connectionString));


builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

// Add Mailgun Email Sender
var mailgunConfig = builder.Configuration.GetSection("MailGun");
var domain = mailgunConfig["Domain"];
var apiKey = mailgunConfig["ApiKey"];
var fromEmail = mailgunConfig["FromEmail"];

builder.Services
    .AddFluentEmail(fromEmail)
    .AddMailGunSender(domain, apiKey);

builder.Services
    .AddBlazorise()
    .AddTailwindProviders()
    .AddFontAwesomeIcons();

// Register Mailgun email sender implementation
builder.Services.AddScoped<IEmailSender<ApplicationUser>, MailgunEmailSender>();

builder.Services.AddDevExpressBlazor(configure => configure.BootstrapVersion = BootstrapVersion.v5);

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IStoreService, StoreService>();

builder.Services.AddScoped<INetliveToastService, NetliveToastService>();


builder.Services.AddLocalization(options =>
{
    options.ResourcesPath = "Locales";
});

builder.Services.AddScoped(typeof(MessageLocalizerHelper<>));

builder.Services.AddControllers();

var app = builder.Build();

// Add locales
string[] supportedCultures = ["en-US", "de-CH"];
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

app.UseRequestLocalization(localizationOptions);

app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
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
    .AddInteractiveServerRenderMode();

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.Run();
