using HorasExtras.Api.Filters;
using HorasExtras.Infrastructure.Context;
using HorasExtras.Infrastructure.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Net;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
var servicios = builder.Services;

string[] origins = config.GetSection("Cors:UrlOrigins").Get<System.Collections.Generic.IEnumerable<string>>().ToArray();
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builderx => builderx.WithOrigins(origins)
                            .AllowAnyHeader()
                            .WithMethods("GET", "POST", "PUT", "DELETE")
                            .AllowCredentials());
});

builder.Services.AddControllers(opts =>
{
    opts.Filters.Add(typeof(AppExceptionFilterAttribute));
});

servicios.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = config["Jwt:Issuer"],
        ValidAudience = config["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]))    
    };
});

var appAsemblyLocation = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
var mappingConfigApplication = Assembly.GetExecutingAssembly().GetReferencedAssemblies().Where(assembly => assembly.Name.Equals("HorasExtras.Application")).First();

// Add services to the container.
servicios.AddAutoMapper(Assembly.LoadFrom($"{appAsemblyLocation}\\{mappingConfigApplication.Name}.dll"));
servicios.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.Load("HorasExtras.Application")));
servicios.InyectarBaseDeDatos(config);
servicios.InyectarServicios();
servicios.InyectarRepositorio();
servicios.AgregarConfiguraciones(config);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
    dbContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.Services.SeedDataBase();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
