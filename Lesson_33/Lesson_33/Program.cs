
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

WebApplication app = builder.Build();

/*
app.MapGet("/", () => "Hello MVC");

app.MapGet("/add", () => "Add Function");

app.MapGet("/sub", () => "Sub Function");

app.MapGet("/phones", () => "Redmi, Apple, Samsung");

app.MapGet("/phones/1", () => "Xiomi model: X10, price: 5,500,000 ");

app.MapGet("/sum", (int a, int b) => $"Result sum function : {a + b}"); // sum?a=10&b=5

app.MapGet("/sub1", (int a, int b) => $"Result sub function : {a - b}"); // sub1?a=10&b=5

app.MapGet("/sub2/{a}/{b}", (int a, int b) => $"Result sub function : {a - b}"); // sub2/10/5

app.MapGet("/sum1", (int a, int b) => $"Result sum  (and) function : {a + b}");

app.MapGet("/sum2", (int a, int b, int c) => $"Result sum  (and) function : {a + b + c}");

app.MapGet("categories/{name}", (string name) =>
{
    if (name == "samsung")
        return "A51, A73, Galaxy 23 ultra";

    else if (name == "apple")
        return "X10, X11 pro, x15";

    else if (name == "redmi")
        return "X19, X71 loock, psa";

    return "not found error 404";
});*/

/*app.UseRouting();

app.MapControllers();
app.MapGet("", () => "First page");
*/


// HomeController
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}");


app.Run();
