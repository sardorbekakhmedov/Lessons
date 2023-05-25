using Lesson_75_Docker.Context;
using Lesson_75_Docker.Entities;
using Lesson_75_Docker.Extensions;
using Lesson_75_Docker.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection(JwtSettings.SectionName));
builder.Services.AddJwtTokenConfiguration(builder.Configuration);
builder.Services.AddSwaggerWithBearer();

builder.Services.AddScoped<JwtServices>();

builder.Services.AddDbContext<AppDbContext>(config =>
{
    var connectionString = builder.Configuration.GetConnectionString("ConnectionPostgres");
    config.UseNpgsql(connectionString);
});

builder.Services.AddCustomPolicyRoles();

var app = builder.Build();

/*"ConnectionStrings": {
    //host - docker dontainerni nomi boladi
    "db": "Server=api_db;Port=5432;Database=apidb;User Id=postgres;Password=postgres;"
}*/

// Auto update database

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    if (db != null)
    {
        db.Database.Migrate();
    }
}



app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
