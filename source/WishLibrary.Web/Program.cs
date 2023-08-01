using AspNetCoreHero.ToastNotification.Extensions;
using Microsoft.AspNetCore.Builder;
using System.Diagnostics;
using WishLibrary.Web.Configuration;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        //Injeção de Dependência
        DependencyInjection.AddServices(builder.Services);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            //app.UseExceptionHandler("~/Views/Home/Index");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();
        app.UseAuthorization();

        //Configure notification
        app.UseNotyf();

        //Configuração de rotas
        RouteConfiguration.AddRoute(app);

        app.Run();
    }
}
