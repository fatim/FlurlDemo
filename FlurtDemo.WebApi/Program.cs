var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/square", async (int value) =>
{
    await Task.Delay(3000);
    return value * value;
});

app.Run();