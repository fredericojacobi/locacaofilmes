using AutoMapper;
using Contracts.Repositories;
using Contracts.Services;
using Entities.MapProfiles;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using Services;

namespace Extensions;

public static class ServiceExtensions
{
    public static void Configure(this IServiceCollection services, Settings settings)
    {
        services.ConfigureDbContext(settings);
        services.ConfigureWrappers();
        services.ConfigureMappers();
    }
    
    public static void ConfigureDbContext(this IServiceCollection services, Settings settings)
    {
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 28));
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseMySql(settings.DbString, serverVersion);
            options.EnableSensitiveDataLogging();
        });
    }
    
    public static void ConfigureWrappers(this IServiceCollection services)
    {
        services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        services.AddScoped<IServiceWrapper, ServiceWrapper>();
    }

    public static void ConfigureMappers(this IServiceCollection services)
    {
        var mapperConfig = new MapperConfiguration(conf =>
        {
            conf.AddProfile(new ClientProfile());
            conf.AddProfile(new RentalProfile());
            conf.AddProfile(new MovieProfile());
        });
        services.AddSingleton(mapperConfig.CreateMapper());
    }
}