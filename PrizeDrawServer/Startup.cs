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
using MySql.Data.EntityFrameworkCore;
using System.Reflection;

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
            var dataserver = Configuration.GetValue<string>("DataServer");
            string cnstr;
            if (dataserver == "SqlServer")
            {
                cnstr = Configuration.GetConnectionString("SqlServerConnection");
            }
            else
            {
                cnstr = Configuration.GetConnectionString("SqliteConnection");
            }
       //     var c = 
            var connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PrizeDraw;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            
#region mysql
        var Host= "sql12.freesqldatabase.com";
        var Database_name= "sql12358245";
        var Database_user="sql12358245";
        var Database_password="cbZVdGXYCk";
        var Port_number= "3306";
         connectionString = "SERVER=" + Host + ";" + "DATABASE=" +
         Database_name + ";" + "UID=" + Database_user + ";" + "PASSWORD=" + Database_password + ";";
            #endregion

            var folder =System.IO.Path.GetDirectoryName( System.Reflection.Assembly.GetExecutingAssembly().Location);
            var sqlitecnstr = "Filename=" + System.IO.Path.Combine(folder, "pzdrw.db");
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();
            /*services.AddSingleton<PZDataContext>((p) => {
                //miandoab_prize
                //@,Egx=y6EZ2v
                DbContextOptionsBuilder<PZDataContext> builder = new DbContextOptionsBuilder<PZDataContext>();
                //builder.UseSqlServer(connectionString);
                // builder.UseMySQL(connectionString);
                //  builder.UseSqlServer(@"(.\MSSQLSERVER2012;Initial Catalog=admin_miandoab;User ID=admin_miandoab;Password=q49Ob&5;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                builder.UseSqlite(sqlitecnstr,x=>x.MigrationsAssembly("PrizeDrawServer"));
                return new PZDataContext(builder.Options);

            });*/
            services.AddDbContext<PZDataContext>(x => {
                //x.UseSqlite(sqlitecnstr, x => x.MigrationsAssembly("PrizeDrawServer"));
                //  x.UseSqlServer(@"Data Source=.\MSSQLSERVER2012;Initial Catalog=admin_miandoab;User ID=admin_miandoab;Password=q49Ob&5;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False", t=>t.MigrationsAssembly("PrizeDrawServer"));
                if (cnstr == "SqlServer")
                    x.UseSqlServer(cnstr, t => t.MigrationsAssembly("PrizeDrawServer"));
                else 
                    x.UseSqlite(cnstr,t=> t.MigrationsAssembly("PrizeDrawServer"));

            }, ServiceLifetime.Singleton);
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
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, PZDataContext dbctx)
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

            dbctx.Database.Migrate();
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
