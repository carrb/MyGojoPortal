﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using MyGojo.Data.Model;

namespace MyGojo.Data.EF
{
    public class MyGojoContext : DbContext, IDbContext
    {

        // Use IoC to inject connection string?
        //public MyGojoContext(string connectionStringName) : base(connectionStringName) {}
        public MyGojoContext(IDatabaseInitializer<MyGojoContext> dbInit)
            : base("MyGojo")
        {
            Database.SetInitializer(dbInit);
        }



        public IDbSet<SiteInfo> Sites { get; set; }




        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
