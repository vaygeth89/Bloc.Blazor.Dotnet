using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Bloc.Blazor.Example;
using Bloc.Blazor.Example.Blocs;
using Bloc.Blazor.Example.Services;
using Bloc.Blazor.Example.States;
using Bloc.Models;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddScoped<IReportService, ReportService>();
builder.Services.AddScoped(sp => new BlocBuilder<ReportCubit, ReportState>(new(sp.GetService<IReportService>())));
builder.Services.AddScoped(sp => new BlocBuilder<CountCubit, CountState>(new()));
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();