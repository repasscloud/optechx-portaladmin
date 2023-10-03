using Auth0.AspNetCore.Authentication;
using Blazored.Toast;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.HttpOverrides;
using OptechXPortalAdmin.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddAuth0WebAppAuthentication(options => {
        options.Domain = builder.Configuration["Auth0:Domain"]!;
        options.ClientId = builder.Configuration["Auth0:ClientId"]!;
    });

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddBlazoredToast();  // toast notifications
builder.Services.AddScoped<ILegendModalService, LegendModalService>();

// Configure and register HttpClient
builder.Services.AddHttpClient<ISupportTicketService, SupportTicketService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["OptechX-URLs:BASE-API"]!);
    client.DefaultRequestHeaders.Add("X-Admin-API-Key", builder.Configuration["X-Admin:Api-Key"]);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();

    // Redirect to HTTPS (default port 443)
    app.UseHttpsRedirection();

    // Add the following lines to configure HTTPS redirection middleware
    var forwardingOptions = new ForwardedHeadersOptions
    {
        ForwardedHeaders = ForwardedHeaders.XForwardedProto
    };
    forwardingOptions.KnownNetworks.Clear();
    forwardingOptions.KnownProxies.Clear();
    app.UseForwardedHeaders(forwardingOptions);
    
    // Configure the cookie policy to set SameSite=None and Secure for cookies
    app.UseCookiePolicy(new CookiePolicyOptions
    {
        MinimumSameSitePolicy = SameSiteMode.None, // Allow cross-site cookies
        HttpOnly = HttpOnlyPolicy.None, // Allow JavaScript access to cookies if needed
        Secure = CookieSecurePolicy.Always // Require cookies to be sent over HTTPS
    });
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
