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
            builder.UseMySQL(connectionString);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           // DbContextOptionsBuilder<PZDataContext> builder = new DbContextOptionsBuilder<PZDataContext>();
            //builder.UseSqlServer(connectionString: @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PrizeDraw;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            var connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PrizeDraw;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            #region mysql
            var Host = "sql12.freesqldatabase.com";
            var Database_name = "sql12358245";
            var Database_user = "sql12358245";
            var Database_password = "cbZVdGXYCk";
            var Port_number = "3306";
            connectionString = "SERVER=" + Host + ";" + "DATABASE=" +
                Database_name + ";" + "UID=" + Database_user + ";" + "PASSWORD=" + Database_password + ";";
            #endregion
            optionsBuilder.UseMySQL(connectionString);
        }
        public DbSet<Person> Persons { get; set; }

    }
}
