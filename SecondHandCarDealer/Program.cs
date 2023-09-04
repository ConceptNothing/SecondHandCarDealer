using DataAccessLayer;
using DataAccessLayer.Implementations;
using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Service.Implementations;
using Service.Interfaces;
using System.Reflection;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddDbContext<CarDealerDbContext>(options => 
                                                    options.UseSqlServer(builder.Configuration.GetConnectionString("CarDealer")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ICarRepository, CarRepository>();
builder.Services.AddTransient<ICarsService, CarsService>();
builder.Services.AddTransient<ICustomersService, CustomersService>();
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
builder.Services.AddTransient<ISalesRepository, SalesRepository>();
builder.Services.AddTransient<ISalesService, SalesService>();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "SecondHandCar API",
        Version = "v1",
    });

    //TO:DO, FIND ANOTHER WAY TO STORE THE XML 
    var xmlFile = @"C:\Users\pusca\source\repos\SecondHandCarDealer\Domain\bin\Debug\net7.0\Domain.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});
builder.Services.AddControllers();
builder.Services.Configure<RouteOptions>(x => x.LowercaseUrls = true);
var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
