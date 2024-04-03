using Coleta_Colchao.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Routing.Patterns;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Coleta_Colchao
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<BancoContext>
             (options => options.UseMySql(
                 "server=novolab.c82dqw5tullb.sa-east-1.rds.amazonaws.com;user id=Sistemas;password=#7847awsE2024;database=labdados",
                 Microsoft.EntityFrameworkCore.ServerVersion.Parse("13.2.0-mysql")));
            builder.Services.AddDbContext<ColchaoContext>
             (options => options.UseMySql(
                 "server=novolab.c82dqw5tullb.sa-east-1.rds.amazonaws.com;user id=Sistemas;password=#7847awsE2024;database=colchao",
                 Microsoft.EntityFrameworkCore.ServerVersion.Parse("13.2.0-mysql")));

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //passando de ponto para virgula no sistema, forma padrao.
            var cultureInfo = new CultureInfo("pt-BR");
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            builder.Services.AddControllersWithViews()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
                options.JsonSerializerOptions.WriteIndented = true;

            });
            //termina aqui.

            builder.Services.AddAuthentication(
               CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option =>
               {
                   option.LoginPath = "/Acess/Login";
                   option.ExpireTimeSpan = TimeSpan.FromMinutes(60);
               });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Acess}/{action=Login}/{id?}");

            app.Run();
        }
    }
}