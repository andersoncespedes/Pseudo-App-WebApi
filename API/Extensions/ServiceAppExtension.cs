using Aplication.Repository;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Aplication.UnitOfWork;
namespace API.Extensions;

public static class ServiceAppExtension
{
    public static void AppServicePolicy(this IServiceCollection services){
        services.AddCors(e => {
            e.AddPolicy("CorsPolicy", f => {
                f.AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin();
            });
        });
    }
    public static void AddAplicationService(this IServiceCollection services){
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        
    }
    public static void ConfigureJson(this IServiceCollection services){
        services.AddControllersWithViews()
        .AddNewtonsoftJson(options =>
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
    );
    }
    
}
