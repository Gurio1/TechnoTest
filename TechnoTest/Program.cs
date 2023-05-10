using TechnoTest.Infrastructure.Repositories;
using TechnoTest.Infrastructure.Repositories.Abstractions;
using TechnoTest.Services;
using TechnoTest.Services.Abstractions;
using TechnoTest.Services.Factory;
using TechnoTest.Services.Factory.Abstraction;
using TechnoTest.Validation;
using TechnoTest.Validation.Abstractions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCustomPostgreSql(builder.Configuration);

builder.Services.AddTransient(typeof(IServiceFactory<>), typeof(ServiceFactory<>));

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserGroupService, UserGroupService>();
builder.Services.AddScoped<IUserStateService, UserStateService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserGroupRepository, UserGroupRepository>();
builder.Services.AddScoped<IUserStateRepository, UserStateRepository>();

builder.Services.AddScoped<IUserValidator, UserValidator>();
builder.Services.AddScoped<IUserGroupValidator, UserGroupValidator>();
builder.Services.AddScoped<IUserStateValidator, UserStateValidator>();

builder.Services.AddMemoryCache();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();