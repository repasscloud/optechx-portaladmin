using OptechXPortalAdmin.Data;
using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.CookiePolicy;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddAuth0WebAppAuthentication(options => {
      options.Domain = builder.Configuration["Auth0:Domain"]!;
      options.ClientId = builder.Configuration["Auth0:ClientId"]!;
    });

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<QuizService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();

    // Redirect to HTTPS with a specific port (e.g., 5000 for development)
    app.UseHttpsRedirection();
    
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
