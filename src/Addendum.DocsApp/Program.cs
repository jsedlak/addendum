using Addendum.DocsApp;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Addendum;
using Addendum.DocsApp.Components;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddAddendum()
    .WithAssembly(typeof(Button).Assembly)
    .Build();

await builder.Build().RunAsync();
