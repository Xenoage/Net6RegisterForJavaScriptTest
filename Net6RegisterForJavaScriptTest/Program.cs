using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Net6RegisterForJavaScriptTest;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
// Not working without parameter "javaScriptInitializer" (see https://github.com/dotnet/aspnetcore/issues/38044 )
builder.RootComponents.RegisterForJavaScript<App>(identifier: "app", javaScriptInitializer: "initApp");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
