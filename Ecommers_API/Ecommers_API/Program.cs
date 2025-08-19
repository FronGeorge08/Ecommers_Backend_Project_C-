using EccomersAPI.Database.Database;
using EccomersAPI.Db.DatabaseDomain;
using EccomersAPI.Repositories.Cart;
using EccomersAPI.Repositories.ProductRepository;
using EccomersAPI.Repositories.UserRepository;
using Ecommers_API;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

internal class Program
{
    private static Assembly[] assemblies;
    public static Assembly[] RegisterServices()
    {
        var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies()
            .Where(assembly => assembly.GetName().Name.Contains("Ecommers_API") ||


                               assembly.GetName().Name.Contains("BusinessLogics"))
            .ToList();

        var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        var allAssemblyFiles = Directory.GetFiles(assemblyPath, "*.dll");

        foreach (var assemblyFile in allAssemblyFiles)
        {
            var assemblyName = Path.GetFileNameWithoutExtension(assemblyFile);

            if (!loadedAssemblies.Any(a => a.GetName().Name.Equals(assemblyName, StringComparison.OrdinalIgnoreCase)))
            {
                if (assemblyName.Contains("Ecommers_API") || assemblyName.Contains("BusinessLogics"))
        {
                    try
                    {
                        var assembly = Assembly.LoadFrom(assemblyFile);
                        loadedAssemblies.Add(assembly);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Could not load assembly {assemblyFile}: {ex.Message}");
                    }
                }
            }
        }

        return loadedAssemblies.ToArray();
    }

    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        assemblies=RegisterServices();
        DatabaseSettings settings = builder.Configuration.GetSection("DatabaseSettings").Get<DatabaseSettings>();
        builder.Services.AddSingleton(settings);
        builder.Services.AddSingleton<Database>();
        builder.Services.AddSingleton<ProductRepository>();
        builder.Services.AddSingleton<UserRepository>();
        builder.Services.AddSingleton<CartRepository>();
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assemblies));
        builder.Services.AddValidatorsFromAssemblies(assemblies);
        builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        
        var app = builder.Build();
        app.UseMiddleware<GlobalExceptionMiddleware>();
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
    }
}