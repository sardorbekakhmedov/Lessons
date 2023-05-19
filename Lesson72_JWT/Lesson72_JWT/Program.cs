using Identity_Data.Context;
using Lesson72_JWT.ServiceExtensions;
using Lesson72_JWT.Services;
using Lesson72_JWT.Services.AppSettingModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration().WriteTo
    .File("Services/Logs/Loggers.txt", LogEventLevel.Error, rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Logging.AddSerilog(logger);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "api",
        Version = "v1",
        Description = "API for",
        TermsOfService = new Uri("https://localhost:7060"),
    });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Description = "JWT Bearer. : \"Authorization: Bearer { token }\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[]{}
        }
    });
});

// Custom json file qo'shish
//builder.Configuration.AddJsonFile("secret.json", optional: true, reloadOnChange: true).Build();

builder.Services.Configure<InMemoryAppSettings>(builder.Configuration.GetSection(InMemoryAppSettings.SectionName));
builder.Services.Configure<DataBaseAppSettings>(builder.Configuration.GetSection(DataBaseAppSettings.SectionName));
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection(JwtSettings.SectionName));

builder.Services.AddDbContext<AppDbContext>(config =>
{
    //  var connectionString = builder.Configuration.GetValue<string>(MemoryAppSettings.SectionName);
    var connectionString = SecretConfigurationManager.GetSecretValue(new InMemoryAppSettings());

    config.UseInMemoryDatabase(connectionString!);
});

builder.Services.AddJwtConfiguration(builder.Configuration);

builder.Services.AddScoped<CreateJwtToken>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

// Custom logger middleware
app.UseLoggerMiddleware();

app.MapControllers();

app.Run();
