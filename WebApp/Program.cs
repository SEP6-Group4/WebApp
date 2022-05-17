using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WebApp;
using WebApp.Data.FavoriteMovie;
using WebApp.Data.Movies;
using WebApp.Data.Users;
using WebApp.Models.Authentication;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<IMovieService, MovieService>();
builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddSingleton<IFavoriteMovieService, FavoriteMovieService>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();

builder.Services.AddAuthorizationCore(options =>
{
    options.AddPolicy("SecurityLevel1", a =>
        a.RequireAuthenticatedUser().RequireClaim("Level", "1"));
});

await builder.Build().RunAsync();
