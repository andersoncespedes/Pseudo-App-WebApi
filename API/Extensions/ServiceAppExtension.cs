using Dominio.Interfaces;
using Aplication.UnitOfWork;
using AspNetCoreRateLimit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
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
    public static void ConfigureRateLimit(this IServiceCollection services){
        services.AddMemoryCache();
        services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
        services.AddInMemoryRateLimiting();
        services.Configure<IpRateLimitOptions>(options => {
            options.EnableEndpointRateLimiting = true;
            options.StackBlockedRequests = false;
            options.HttpStatusCode = 429;
            options.RealIpHeader = "X-Real-IP";
            options.GeneralRules = new List<RateLimitRule>(){
                new RateLimitRule {
                   Endpoint = "*",
                   Period = "10s",
                   Limit = 2 
                }
            };
        });
    }
    public static void ConfigureApiVersioning(this IServiceCollection services){
        services.AddApiVersioning( options => {
            options.DefaultApiVersion = new ApiVersion(1,0);
            options.AssumeDefaultVersionWhenUnspecified = true;
        });
    }
    
}
