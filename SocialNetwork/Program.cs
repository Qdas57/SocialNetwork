using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NLog.Web;
using SocialNetwork.Core;
using SocialNetwork.Data;
using SocialNetwork.Filters;
using SocialNetwork.Services.Repositories;
using SocialNetwork.Services.Services;
using System.Reflection;


//TODO:
//1. Везде добавить логи + 
//2. UserEntity < - > UserOutput  < - > ProfileOutput - мапперы ( или методы расширения или автомаппер)

var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

try
{
    logger.Debug("Инициализация приложения...");
    
    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddControllers();

    builder.Services.AddEndpointsApiExplorer();

    builder.Services.AddSwaggerGen(c =>
    {
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
        {
            Name = "Bearer",
            Type = SecuritySchemeType.Http,
            Scheme = "bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "JWT Authorization header using the Bearer scheme.",
        });

        c.SwaggerDoc("v1", new OpenApiInfo { Title = "SocialNetwok", Version = "v1" });

        c.OperationFilter<AuthResponsesOperationFilter>();

        var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
    });
        
    builder.Services.AddTransient<UserRepository>();
    builder.Services.AddTransient<CommonService>();
    builder.Services.AddTransient<UserService>();
    builder.Services.AddTransient<RefreshTokenRepository>();
    builder.Services.AddTransient<ProfileService>();

    builder.Services.AddDbContext<UserContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SocialNetwork")));

    var tokenValidationParams = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = AccessTokenOptions.ISSUER,
        ValidateAudience = true,
        ValidAudience = AccessTokenOptions.AUDIENCE,
        ValidateLifetime = true,
        IssuerSigningKey = AccessTokenOptions.GetSymmetricSecurityKey(),
        ValidateIssuerSigningKey = true,
        ClockSkew = TimeSpan.Zero
    };

    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.SaveToken = true;
                        options.RequireHttpsMetadata = false;
                        options.TokenValidationParameters = tokenValidationParams;
                    });

    builder.Host.UseNLog();

    var app = builder.Build();

    // Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI();

    app.MapControllers();

    app.UseAuthentication();
    app.UseAuthorization();

    app.Run();
}
catch (Exception)
{
    logger.Error("Закрытие программы");
}
finally
{
    NLog.LogManager.Shutdown();
}
