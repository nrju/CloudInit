var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.MapGet("/", () => "Hello World!");
app.Run();

// The lines below are required for ASP.NET integration tests.

#pragma warning disable CA1515,CS1591
public partial class Program { }
#pragma warning restore CA1515,CS1591
