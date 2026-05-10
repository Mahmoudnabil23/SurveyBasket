using SurveyBasket.Repositories.Implementations;
using SurveyBasket.Services.Implementations;

namespace SurveyBasket;

public static class DependencyInjection
{
    public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddOpenApi();
        services.AddSwaggerGen();
        services
            .AddApplicationDbContext(configuration)
            .AddMapsterConf()
            .AddFluentValidation()
            .AddMyServices()
            .AddMyRepositories();





        return services;
    }

    public static IServiceCollection AddMapsterConf(this IServiceCollection services)
    {
        TypeAdapterConfig config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());
        services.AddSingleton<IMapper>(new Mapper(config));

        return services;
    }

    public static IServiceCollection AddFluentValidation(this IServiceCollection services)
    {
        services
           .AddFluentValidationAutoValidation()
           .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }

    public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        String connectionString = configuration.GetConnectionString("DefaultConnection") ??
          throw new InvalidOperationException("Connection String 'DefaultConnection' not found");
        services.AddDbContext<ApplicationDbContext>(options =>
      {
          options.UseSqlServer(connectionString);
      });
        return services;
    }

    public static IServiceCollection AddMyServices(this IServiceCollection services)
    {
        services.AddScoped<IPollService, PollService>();
        return services;
    }
    public static IServiceCollection AddMyRepositories(this IServiceCollection services)
    {
        services.AddScoped<IPollRepository, PollRepository>();
        return services;

    }


}
