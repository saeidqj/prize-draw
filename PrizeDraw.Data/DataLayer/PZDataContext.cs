using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PrizeDraw.Data.Models;
using MySql.Data.EntityFrameworkCore;

namespace PrizeDraw.Data.DataLayer
{
    public class PZDataContext : DbContext
    {
       /* public PZDataContext(string connectionString) : base(new DbContextOptions {   })
        {
            
        }*/
       public PZDataContext(DbContextOptions ops) : base(ops)
        {

        }
        public PZDataContext() : base()
        {
            DbContextOptionsBuilder<PZDataContext> builder = new DbContextOptionsBuilder<PZDataContext>();
            //builder.UseSqlServer(connectionString: @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PrizeDraw;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            //var connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PrizeDraw;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            //  builder.UseSqlServer(@"(.\MSSQLSERVER2012;Initial Catalog=admin_miandoab;User ID=admin_miandoab;Password=q49Ob&5;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            builder.UseSqlite("Filename=TestDatabase.db"); 

            #region mysql
            var Host= "sql12.freesqldatabase.com";
            var Database_name= "sql12358245";
            var Database_user="sql12358245";
            var Database_password="cbZVdGXYCk";
            var Port_number= "3306";
            //connectionString = "SERVER=" + Host + ";" + "DATABASE=" +
             //   Database_name + ";" + "UID=" + Database_user + ";" + "PASSWORD=" + Database_password + ";";
        #endregion
           // builder.UseMySQL(connectionString);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // DbContextOptionsBuilder<PZDataContext> builder = new DbContextOptionsBuilder<PZDataContext>();
            //builder.UseSqlServer(connectionString: @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PrizeDraw;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            var connectionString = "";// @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PrizeDraw;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            

            #region maybe must deleted
            
            #region mysql
            
            var Host = "sql12.freesqldatabase.com";
            var Database_name = "sql12358245";
            var Database_user = "sql12358245";
            var Database_password = "cbZVdGXYCk";
            var Port_number = "3306";
            connectionString = "SERVER=" + Host + ";" + "DATABASE=" +
                Database_name + ";" + "UID=" + Database_user + ";" + "PASSWORD=" + Database_password + ";";
            #endregion
            //  optionsBuilder.UseMySQL(connectionString);

            /* optionsBuilder.UseSqlServer(@"(.\MSSQLSERVER2012;Initial Catalog=admin_miandoab;User ID=admin_miandoab;Password=q49Ob&5;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");*/
            var folder = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var sqlitecnstr = "Filename ="+ System.IO.Path.Combine(folder, "pzdrw.db");
            //optionsBuilder.UseSqlite(sqlitecnstr, x => x.MigrationsAssembly("PrizeDrawServer"));
            
            #endregion


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           /* var sql1 = @"CREATE TABLE IF NOT EXISTS [dbo].[__EFMigrationsHistory] (
                    [MigrationId]    NVARCHAR (150) NOT NULL,
                    [ProductVersion] NVARCHAR (32)  NOT NULL,
                    CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED ([MigrationId] ASC)
                );
                ";
            var sql2 = @"CREATE TABLE IF NOT EXISTS [dbo].[Persons] (
                    [Id]        INT            IDENTITY (4315, 1) NOT NULL,
                    [Name]      NVARCHAR (MAX) NULL,
                    [Family]    NVARCHAR (MAX) NULL,
                    [Phone]     NVARCHAR (MAX) NULL,
                    [InstaId]   NVARCHAR (MAX) NULL,
                    [PrizeCode] NVARCHAR (MAX) NULL,
                    CONSTRAINT [PK_Persons] PRIMARY KEY CLUSTERED ([Id] ASC)
                );";
            this.Database.ExecuteSqlCommand(new RawSqlString(sql1));
            this.Database.ExecuteSqlCommand(new RawSqlString(sql2));
            base.OnModelCreating(modelBuilder);*/
        }
        public DbSet<Person> Persons { get; set; }

    }
}
