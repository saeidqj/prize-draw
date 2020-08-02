using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PrizeDrawServer.Data;
using PrizeDraw.Data.DataLayer;
using Microsoft.EntityFrameworkCore;
using PrizeDraw.Data.Services;

namespace PrizeDrawServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();
            services.AddSingleton<PZDataContext>((p) => {
                //miandoab_prize
                //@,Egx=y6EZ2v
                DbContextOptionsBuilder<PZDataContext> builder = new DbContextOptionsBuilder<PZDataContext>();
                builder.UseSqlServer(connectionString: @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PrizeDraw;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                return new PZDataContext(builder.Options);

            });
            services.AddScoped<IPrizeCodeService>(p => {
                var dbc = p.GetService<PZDataContext>();
                return new PrizeCodeService(dbc);
            });
            services.AddScoped<IPersonService>((p) => {
                var dbc = p.GetService<PZDataContext>();
                return new PersonService(dbc, p.GetService<IPrizeCodeService>());
            });
            services.AddScoped<PersonFactory>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
