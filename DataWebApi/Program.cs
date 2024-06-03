using CatalogService.Api.Extensions;
using Consul;
using DataWebApi;
using EventBus.Base.Abstraction;
using EventBus.Base;
using EventBus.Factory;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;
using System.Configuration;
using System.Globalization;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSingleton<IEventBus>(sp =>
{
    EventBusConfig config = new()
    {
        ConnectionRetryCount = 5,
        EventNameSuffix = "IntegrationEvent",
        SubscriberClientAppName = "BasketService",
        EventBusType = EventBusType.RabbitMQ,
        Connection = new ConnectionFactory()
        {
            HostName = "localhost"
            //HostName = "localhost",
            //Port = 15672,
            //UserName = "guest",
            //Password = "guest",
            //VirtualHost="/"
        }

        //Connection = new ConnectionFactory()
        //{
        //    //HostName = "c_rabbitmq"
        //    HostName = "http://localhost:15672"
        //}
    };

    return EventBusFactory.Create(config, sp);
});


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200") // Angular uygulamanýzýn URL'si
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[]
    {
                    new CultureInfo("tr"),
                    new CultureInfo("en-US"),

                };
    options.DefaultRequestCulture = new RequestCulture(culture: "tr", uiCulture: "tr");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});


var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
var connectionString = $"Data Source={dbHost};Initial Catalog={dbName}; User ID=sa; Password={dbPassword};TrustServerCertificate=true ";
builder.Services.AddDbContext<TestCenterDbContext>(opt => opt.UseSqlServer(connectionString));



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureConsul(builder.Configuration);


var app = builder.Build();
IHostApplicationLifetime lifetime= app.Services.GetRequiredService<IHostApplicationLifetime>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseCors("AllowSpecificOrigin");
app.MapControllers();

app.Run();
app.RegisterWithConsul(lifetime);