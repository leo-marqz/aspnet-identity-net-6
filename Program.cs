using ASPNetIdentity.Data;
using ASPNetIdentity.Models;
using ASPNetIdentity.Utilities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        //======================================
        //SERVICES
        //======================================
        builder.Services.AddDbContext<ApplicationDBContext>(otp => otp.UseSqlServer(builder.Configuration.GetConnectionString("SQLServerString")));
        builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<ApplicationDBContext>().AddDefaultTokenProviders();
        builder.Services.AddAuthentication();
        builder.Services.AddRouting(options=>options.LowercaseUrls= true);
        builder.Services.AddAutoMapper(typeof(Program));
        builder.Services.ConfigureApplicationCookie(opt=>{
            opt.LoginPath = new Microsoft.AspNetCore.Http.PathString("/accounts/signin");
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