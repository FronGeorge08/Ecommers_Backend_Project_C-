using EccomersAPI.BusinessLogics.Generic.CreateDocument;
using EccomersAPI.BusinessLogics.Generic.DeleteDocument;
using EccomersAPI.BusinessLogics.Generic.GetDocumentById;
using EccomersAPI.BusinessLogics.UsersBusiness.Factory;
using EccomersAPI.CommonDomain.Products;
using EccomersAPI.CommonDomain.Users;
using EccomersAPI.DataAbstraction;
using EccomersAPI.DataAbstraction.Database;
using EccomersAPI.DataAbstraction.Security;
using EccomersAPI.Database.Database;
using EccomersAPI.Db.DatabaseDomain;
using EccomersAPI.Repositories;
using EccomersAPI.Repositories.Cart;
using EccomersAPI.Repositories.ProductRepository;
using EccomersAPI.Repositories.UserRepository;
using EccomersAPI.Services;
using EccomersAPI.Services.Security;
using EcomersAPI.DataAbstraction;
using Ecommers_API;
using EcommersAPI.Domain.Cart;
using EcommersAPI.Domain.ProductDomain;
using EcommersAPI.Domain.UserDomain;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
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
        var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddCors(options =>
        {
            options.AddPolicy(name: MyAllowSpecificOrigins,
                              policy =>
                              {
                                  policy.AllowAnyHeader();
                                  policy.AllowAnyMethod();
                                  policy.AllowAnyHeader();
                                  policy.AllowAnyOrigin();
                              });
        });

        assemblies = RegisterServices();
        builder.Services.AddControllers();
        builder.Services.AddScoped(typeof(IGenericCrudRepository<>), typeof(GenericCrudRepository<>));
        builder.Services.AddScoped<IHashingService, HashingService>();
        builder.Services.AddScoped<IProductRepository, ProductRepository>();
        builder.Services.AddScoped<ICartRepository, CartRepository>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IContextProvider, ContextProvider>();
        builder.Services.AddScoped<IDatabase, Database>();
        builder.Services.AddScoped<UserModifierFactory>();
        builder.Services.AddTransient<IRequestHandler<CreateDocumentRequest<CreateUserDTO, User>, CreateDocumentResponse>, CreateDocumentHandler<CreateUserDTO, User>>();
        builder.Services.AddTransient<IRequestHandler<GetDocumentByIdRequest<GetUserByIdDTO, User>, GetDocumentByIdResponse<GetUserByIdDTO, User>>, GetDocumentByIdHandler<GetUserByIdDTO, User>>();
        builder.Services.AddTransient<IRequestHandler<CreateDocumentRequest<CreateProductDTO,Product>,CreateDocumentResponse>,CreateDocumentHandler<CreateProductDTO,Product >> ();
        builder.Services.AddTransient<IRequestHandler<DeleteDocumentRequest<User>, DeleteDocumentResponse>, DeleteDocumentHandler<User>>();
        builder.Services.AddTransient<IRequestHandler<GetDocumentByIdRequest<GetProductByIdDTO, Product>, GetDocumentByIdResponse<GetProductByIdDTO, Product>>, GetDocumentByIdHandler<GetProductByIdDTO, Product>>();
        builder.Services.AddAutoMapper(assemblies);
        builder.Services.AddScoped<IAuthSettings, AuthSettings>(sp =>
        {
            var config=sp.GetRequiredService<IConfiguration>();
            AuthSettings authSettings=new AuthSettings();   
            config.GetSection("AuthSettings").Bind(authSettings);
            return authSettings;
        });
        builder.Services.AddScoped<IAuthService, AuthService>();
        builder.Services.AddScoped<IEmailService, EmailService>();
        builder.Services.AddScoped<IDatabaseSettings,DatabaseSettings>(sp =>
        {
            var config = sp.GetRequiredService<IConfiguration>();
            DatabaseSettings databaseSettings=new DatabaseSettings();
            config.GetSection("DatabaseSettings").Bind(databaseSettings);
            return databaseSettings;
        });
        
        builder.Services.AddScoped<IEmailConfig, EmailConfig>(sp =>
        {
            var config=sp.GetRequiredService<IConfiguration>();
            EmailConfig emailConfig = new EmailConfig();
            config.GetSection("EmailConfig").Bind(emailConfig);
            return emailConfig;
        });
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        
        builder.Services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(assemblies);
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>));
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(RequestPostProcessorBehavior<,>));
        });
        builder.Services.Scan(scan => scan
        .FromAssemblies(assemblies)
        .AddClasses(classes => classes.AssignableTo(typeof(IRequestPreProcessor<>)))
    .   AsImplementedInterfaces()
        .WithTransientLifetime());
        builder.Services.AddValidatorsFromAssemblies(assemblies);
        
        
        var app = builder.Build();
        app.UseCors(MyAllowSpecificOrigins);
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