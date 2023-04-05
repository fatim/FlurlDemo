using System.Diagnostics;
using Flurl;
using Flurl.Http;

var apiEndpoint = "http://localhost:5000/square";

var sw = new Stopwatch();
sw.Start();

var task1 = SendRequest(apiEndpoint, 5);
var task2 = SendRequest(apiEndpoint, 6);
await Task.WhenAll(task1, task2);

sw.Stop();
Console.WriteLine($"{sw.ElapsedMilliseconds}ms");

Task<string> SendRequest(string url, int parameter)
{
    var task = url
        .SetQueryParams(new {value = parameter})
        .GetStringAsync();
    return task;
}
