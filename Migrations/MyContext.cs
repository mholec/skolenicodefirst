﻿using System.Data.Entity;

namespace TheMigrations
{
    public class MyContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }

        public MyContext()
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
