using Api.Extensao;
using Infra.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

//SWAGGER
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Admin API",
        Description = "An API for administration purposes"
    });

});


// Injeção de Dependencia
builder.Services.AddDependencyInjection();



// Conexão banco
builder.Services.AddSingleton<SqlConnectionFactory>();

// Permissões api
builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
{
    policy.WithOrigins("http://localhost:4200");
    policy.AllowAnyHeader();
    policy.AllowAnyMethod();
    policy.AllowCredentials();
    policy.SetIsOriginAllowed(_ => true);
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Admin API v1");
        options.RoutePrefix = string.Empty; 
    });
}



app.UseCors();



app.UseAuthentication();  
app.UseAuthorization();

app.MapControllers();

app.Run();
