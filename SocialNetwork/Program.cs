using Microsoft.EntityFrameworkCore;
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

builder.Services.AddDbContext<UserContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SocialNetwork")));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
