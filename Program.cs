using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SampleWebApiCore.Contracts;
using SampleWebApiCore.Models;
using SampleWebApiCore.Repositories;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MyShopDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectiion"));
});

//DI
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<ISalesPersonsRepository, SalesPersonsRepository>();

builder.Services.AddResponseCaching();
builder.Services.AddMemoryCache();

//JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "https://localhost:7287",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is my secret key Mohsen ApiFor@V@Hello"))
        };
    });


builder.Services.AddCors(options =>
{
    options.AddPolicy("EnableCors", builder =>
    {
        builder.AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()
            .Build();
    });


});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseResponseCaching();

app.UseHttpsRedirection();

app.UseCors("EnableCors");
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
