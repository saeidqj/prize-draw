﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PrizeDraw.Data.Models;

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
            builder.UseSqlServer(connectionString: @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PrizeDraw;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connectionString: @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PrizeDraw;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        public DbSet<Person> Persons { get; set; }

    }
}