using System.Diagnostics;
using Flurl.Http;
using Flurl.Http.Configuration;
using Microsoft.Extensions.DependencyInjection;

var apiEndpoint = "http://localhost:5000/square";

var sc = new ServiceCollection();
sc.AddSingleton<IFlurlClient, FlurlClient>();
sc.AddSingleton<IFlurlClientFactory, PerBaseUrlFlurlClientFactory>();
var provider = sc.BuildServiceProvider();

var factory = provider.GetService<IFlurlClientFactory>();
var client = factory.Get(apiEndpoint);

var sw = new Stopwatch();
sw.Start();

var task1 = SendRequest(client, 5);
var task2 = SendRequest(client, 6);
await Task.WhenAll(task1, task2);

sw.Stop();
Console.WriteLine($"{sw.ElapsedMilliseconds}ms");

Task<string> SendRequest(IFlurlClient client, int parameter)
{
    var task = client
        .Request()
        .SetQueryParams(new {value = 3})
        .GetStringAsync();
    return task;
}