using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SocialNetwork.Core;
using SocialNetwork.Data;
using SocialNetwork.Services.Repositories;
using SocialNetwork.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//AddSingleton AddScoped AddTransient ??
builder.Services.AddTransient<UserRepository>();
builder.Services.AddTransient<CommonService>();
builder.Services.AddTransient<UserService>();
builder.Services.AddTransient<RefreshTokenRepository>();

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

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.UseAuthentication();
app.UseAuthorization();

app.Run();
