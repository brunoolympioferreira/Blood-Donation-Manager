using BloodDonation.API.Filters;
using BloodDonation.Application;
using BloodDonation.Infra;
using Serilog;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddControllers().AddJsonOptions(x =>
{
    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddMvc(options => options.Filters.Add(typeof(ExceptionsFilter)));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddInfraModule();
builder.Services.AddApplicationModule();

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
