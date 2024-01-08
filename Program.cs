using System;
using ASPNetIdentity.Data;
using ASPNetIdentity.Models;
using ASPNetIdentity.Utilities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        //======================================
        //SERVICES
        //======================================
        builder.Services.AddDbContext<ApplicationDBContext>(otp => otp.UseSqlServer(builder.Configuration.GetConnectionString("SQLServerString")));
        
        //servicio de identity para la aplicacion
        builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<ApplicationDBContext>().AddDefaultTokenProviders();
        builder.Services.AddAuthentication();

        //mapea los endpoint en minusculas
        builder.Services.AddRouting(options=>options.LowercaseUrls= true);
        builder.Services.AddAutoMapper(typeof(Program));

        //configuracion para url de retorno
        builder.Services.ConfigureApplicationCookie(opt=>{
            //configuracion para url de retorno
            opt.LoginPath = new Microsoft.AspNetCore.Http.PathString("/accounts/signin");
            opt.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/accounts/denied");
        });

        //opciones de configuracion de identity
        builder.Services.Configure<IdentityOptions>(opt=>{
            opt.Password.RequiredLength = 4;
            opt.Password.RequireLowercase = true;
            opt.Password.RequireUppercase = true;
            opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            opt.Lockout.MaxFailedAccessAttempts = 3;
        });

        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        //======================================
        //MIDDLEWARES
        //======================================

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();
        app.UseAuthentication(); //added - identity
        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}