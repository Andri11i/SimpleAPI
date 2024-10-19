using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()   
               .AllowAnyMethod()   
               .AllowAnyHeader(); 
    });
});


builder.Services.AddControllers();

var app = builder.Build();


app.UseCors("AllowAll");

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers(); 
});


app.Run();
