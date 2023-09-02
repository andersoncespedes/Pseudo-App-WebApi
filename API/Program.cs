using Persistencia.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using API.Extensions;
using AspNetCoreRateLimit;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApiContext>(optionsBuilder => {
    string ? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
}) ;
builder.Services.AppServicePolicy();
builder.Services.ConfigureRateLimit();
builder.Services.AddControllers();
builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());
builder.Services.AddAplicationService();
builder.Services.ConfigureJson();
builder.Services.ConfigureApiVersioning();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseIpRateLimiting();
app.UseAuthorization();

app.MapControllers();
app.UseCors("CorsPolicy");

app.Run();
