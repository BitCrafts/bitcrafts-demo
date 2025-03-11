using BitCrafts.Infrastructure.Abstraction.Application;
using BitCrafts.Infrastructure.Application.Avalonia.Extensions;
using BitCrafts.Infrastructure.Extensions;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

services
    .AddBitCraftsInfrastructure()
    .AddBitCraftsAvaloniaApplication();

var provider = services.BuildServiceProvider();
var factory = provider.GetService<IApplicationFactory>();
if (factory == null)
    throw new NullReferenceException("factory is null");

var app = factory.CreateApplication();
app.ServiceProvider = provider;
await app.StartAsync();
app.Dispose();