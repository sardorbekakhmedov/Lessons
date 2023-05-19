using System.Reflection.Emit;
using Lesson_Configuration_appSetting.Configuration.ConfigServices;
using Lesson_Configuration_appSetting.Configuration.ConfigurationModels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Configuration.AddJsonFile("AppSettingServices/PlayMobile.json", optional: true, reloadOnChange: true);
builder.Services.AddSingleton<CustomOptions>();
builder.Services.Configure<PlayMobile>(builder.Configuration.GetSection(PlayMobile.SectionName));


/*
 var connectionString = builder.Configuration.GetValue<string>("ConnectionString");
Console.WriteLine(connectionString);

var userName = builder.Configuration.GetValue<string>("UserName");
Console.WriteLine(userName);

var password = builder.Configuration.GetValue<string>("Password");
Console.WriteLine(password);
*/

/*var playMobile = builder.Configuration.GetValue<string>("playmobile");
Console.WriteLine(playMobile);

var play = builder.Configuration.GetSection(PlayMobile.SectionName).Get<PlayMobile>();
Console.WriteLine(play.Limits.SmsTextLimits[2]);

var limits = builder.Configuration.GetSection(
    $"{PlayMobile.SectionName}:{Limits.SectionName}").Get<Limits>();

var limits = builder.Configuration
    .GetSection(PlayMobile.SectionName)
    .GetSection(Limits.SectionName)
    .Get<Limits>();

Console.WriteLine(limits.SmsTextLimit2);
*/


Console.WriteLine("\n========================== //  \\ ============================\n");


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


public interface IMan
{
    public void Max()
    {
        Console.WriteLine("Salom nima gap interface");
    }
}

public class Access : Abs, IMan
{
    public override void Min()
    {
        Console.WriteLine("Salomlar");
    }
}

public abstract class Abs
{
    public abstract void Min();

    protected Abs()
    {
        Console.WriteLine("Abstraction");
    }
}
