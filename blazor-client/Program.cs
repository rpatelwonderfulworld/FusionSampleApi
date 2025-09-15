using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using BlazorClient;   // ✅ add this at the top

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

var apiBase = builder.Configuration["ApiBaseUrl"] ?? "http://localhost:5083/api";
builder.Services.AddScoped(sp => new ApiService(sp.GetRequiredService<HttpClient>(), apiBase));

await builder.Build().RunAsync();