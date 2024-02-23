using BL.Students.Api.Errors;
using BL.Students.Application.Students;
using BL.Students.Infrastructure.Data;
using BL.Students.Infrastructure.Students;
using Microsoft.OpenApi.Models;

namespace BL.Students.Api.Configurations;

public static class ConfigExtensions
{

    public static WebApplication ConfigServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        //builder.Services.AddSwaggerGen();

        builder.Services.AddSwaggerGen(option =>
        {
            option.SwaggerDoc("v1", new OpenApiInfo { Title = "Students API", Version = "v1" });
            option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter a valid token",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "Bearer"
            });
            option.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type=ReferenceType.SecurityScheme,
                            Id="Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });

        builder.Services.AddAuthentication("Bearer").AddIdentityServerAuthentication("Bearer", options =>
        {
            options.ApiName = "myApi";
            options.Authority = "https://localhost:7237";
        });

        //var mongoDbSettings = builder.Configuration
        //    .GetSection(nameof(MongoDbSettings))
        //.Get<MongoDbSettings>();

        builder.Services.AddOptions();
        builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection(nameof(MongoDbSettings)));

        builder.Services.AddSingleton<IMongoDbContext, MongoDbContext>();
        builder.Services.AddTransient<IStudentService, StudentService>();
        builder.Services.AddTransient<IStudentRepository, StudentRepository>();

        builder.Services.AddControllers(options =>
        {
            options.Filters.Add<HttpResponseExceptionFilter>();
        });

        return builder.Build();
    }

    public static void StartApplication(this WebApplication app)
    {
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        //if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/error");
        }

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
