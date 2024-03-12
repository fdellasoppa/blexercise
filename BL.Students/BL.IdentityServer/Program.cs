using BL.IdentityServer;
using BL.IdentityServer.Domain.Users;
using BL.IdentityServer.Domain.Roles;
using Microsoft.OpenApi.Models;
using BL.IdentityServer.Application.Users;
using BL.IdentityServer.Infrastructure.Users;
using BL.IdentityServer.Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// TODO: Move to Dependency Injection extension class
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IUserRepository, UserRepository>();

// Identity In-Memory Config
//builder.Services.AddIdentityServer()
//    .AddInMemoryClients(IdentityConfiguration.Clients)
//    .AddInMemoryIdentityResources(IdentityConfiguration.IdentityResources)
//    .AddInMemoryApiResources(IdentityConfiguration.ApiResources)
//    .AddInMemoryApiScopes(IdentityConfiguration.ApiScopes)
//    .AddTestUsers(IdentityConfiguration.TestUsers)
//    .AddDeveloperSigningCredential();

var mongoDbSettings = builder.Configuration
    .GetSection(nameof(MongoDbSettings))
    .Get<MongoDbSettings>();

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
    .AddMongoDbStores<ApplicationUser, ApplicationRole, Guid> (
        mongoDbSettings?.ConnectionString, 
        mongoDbSettings?.Name
        );

var identityServerSettings = builder.Configuration
    .GetSection(nameof(IdentityServerSettings))
    .Get<IdentityServerSettings>();

var idServer = builder.Services.AddIdentityServer(options =>
        {
            options.Events.RaiseErrorEvents = true;
            options.Events.RaiseFailureEvents = true;
            options.Events.RaiseErrorEvents = true;
        })
    .AddAspNetIdentity<ApplicationUser>()
    .AddInMemoryApiScopes(identityServerSettings?.ApiScopes)
    .AddInMemoryApiResources(identityServerSettings?.ApiResources)
    .AddInMemoryClients(identityServerSettings?.Clients)
    .AddInMemoryIdentityResources(IdentityServerSettings.IdentityResources);

if (!builder.Environment.IsProduction())
{
    idServer.AddDeveloperSigningCredential();
    idServer.SeedData();
}

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

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

//builder.Services.AddAuthentication("Bearer")
//    .AddIdentityServerAuthentication("Bearer", options =>
//{
//    options.ApiName = "myApi";
//    options.Authority = "https://localhost:7237";
//});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = "https://localhost:7237";
        options.Audience = "myApi";
    });

var app = builder.Build();

app.UseIdentityServer();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
