using BL.IdentityServer;
using BL.IdentityServer.Models;

var builder = WebApplication.CreateBuilder(args);

// Identity In-Memory Config
//builder.Services.AddIdentityServer()
//    .AddInMemoryClients(IdentityConfiguration.Clients)
//    .AddInMemoryIdentityResources(IdentityConfiguration.IdentityResources)
//    .AddInMemoryApiResources(IdentityConfiguration.ApiResources)
//    .AddInMemoryApiScopes(IdentityConfiguration.ApiScopes)
//    .AddTestUsers(IdentityConfiguration.TestUsers)
//    .AddDeveloperSigningCredential();

var mongoDbSettings = builder.Configuration.GetSection(nameof(MongoDbSettings)).Get<MongoDbSettings>();

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
    .AddMongoDbStores<ApplicationUser, ApplicationRole, Guid> (
        mongoDbSettings.ConnectionString, 
        mongoDbSettings.Name
        );

var identityServerSettings = builder.Configuration.GetSection(nameof(IdentityServerSettings)).Get<IdentityServerSettings>();

var idServer = builder.Services.AddIdentityServer(options =>
        {
            options.Events.RaiseErrorEvents = true;
            options.Events.RaiseFailureEvents = true;
            options.Events.RaiseErrorEvents = true;
        })
    .AddAspNetIdentity<ApplicationUser>()
    .AddInMemoryApiScopes(identityServerSettings.ApiScopes)
    .AddInMemoryApiResources(identityServerSettings.ApiResources)
    .AddInMemoryClients(identityServerSettings.Clients)
    .AddInMemoryIdentityResources(IdentityServerSettings.IdentityResources);

if (builder.Environment.IsDevelopment())
    idServer.AddDeveloperSigningCredential();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.UseIdentityServer();

app.Run();
