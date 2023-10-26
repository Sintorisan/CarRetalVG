using CarRental.Business.Classes;
using CarRental.Common.Classes;
using CarRental.Common.Interfaces;
using CarRental.Data;
using CarRetalVG;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSingleton<BusinessLogic>();
builder.Services.AddSingleton<InputValues>();
builder.Services.AddSingleton<Messages>();
builder.Services.AddSingleton<IData, CollectionData>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
