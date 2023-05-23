using System.Security.Claims;
using Lesson_74_AuthenticationHandler_Task.Extensions;
using Lesson_74_AuthenticationHandler_Task.Services.AppSettingsServices;
using Lesson_74_AuthenticationHandler_Task.Services.AuthHandlerServices;
using Lesson_74_AuthenticationHandler_Task.Services.ConfigureServices;
using Lesson74Data.Interfaces;
using Lesson74Data.RepositoryServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGenWithToken();

/*builder.Services.AddAuthentication("Bearer")
    .AddScheme<JwtBearerOptions, AuthHandler>("Bearer", null);
*/

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", builder1 =>
    {
        builder1.RequireClaim(ClaimTypes.Role, "Admin");
    });

    options.AddPolicy("Student", builder2 =>
    {
        builder2.RequireAssertion(
            handler => handler.User.HasClaim(ClaimTypes.Role, "Student") 
                       || handler.User.HasClaim(ClaimTypes.Role, "Admin"));
    });


    options.AddPolicy("Teacher", builder3 =>
    {
        builder3.RequireAssertion(
            handler => handler.User.HasClaim(ClaimTypes.Role, "Teacher")
                       || handler.User.HasClaim(ClaimTypes.Role, "Admin"));
    });


    options.AddPolicy("User", builder3 =>
    {
        builder3.RequireAssertion(
            handler => handler.User.HasClaim(ClaimTypes.Role, "User")
                       || handler.User.HasClaim(ClaimTypes.Role, "Admin"));
    });


});

builder.Services.AddJwtConfiguration(builder.Configuration);

builder.Services.AddScoped<IJwtTokenServices, JwtTokenServices>();
builder.Services.AddScoped<ISmallestMultipleFinder, SmallestMultipleFinder>();

builder.Services.Configure<UsersDataPath>(builder.Configuration.GetSection(UsersDataPath.SectionName));
builder.Services.Configure<JwtSettingsConfigure>(builder.Configuration.GetSection(JwtSettingsConfigure.SectionName));


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

app.MapControllers();

app.Run();

