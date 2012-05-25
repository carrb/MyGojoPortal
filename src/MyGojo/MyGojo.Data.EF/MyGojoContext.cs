using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

using MyGojo.Data.Model;

namespace MyGojo.Data.EF
{
    public class MyGojoContext : DbContext, IDbContext
    {

        // Use IoC to inject connection string?
        //public MyGojoContext(string connectionStringName) : base(connectionStringName) {}
        // public MyGojoContext(IDatabaseInitializer<MyGojoContext> dbInit)
        public MyGojoContext()
            : base("MyGojo")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MyGojoContext>());
            //Database.SetInitializer(dbInit);
        }



        public IDbSet<SiteInfo> Sites { get; set; }
        public IDbSet<UserInfo> Users { get; set; }




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
