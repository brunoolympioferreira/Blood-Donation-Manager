using BloodDonation.Infra;
using Pomelo.EntityFrameworkCore.MySql.Internal;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfraModule();

builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
{
    Log.Logger = new LoggerConfiguration()
        .MinimumLevel.Warning()
        .WriteTo.MySQL(Environment.GetEnvironmentVariable("CS_MYSQL_LOCALHOST_BLOOD_DONATION"))
        .CreateLogger();
}).UseSerilog();

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
