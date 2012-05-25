using System.Data.Entity;

namespace MyGojo.Data.EF
{
    public class MyGojoContextInitializer : DropCreateDatabaseIfModelChanges<MyGojoContext>
    {
        protected override void Seed(MyGojoContext context)
        {
            // Add Sample Data to seed database on each drop/create cycle
            //

            //var user1ID = Guid.NewGuid();
            //var user2ID = Guid.NewGuid();

            base.Seed(context);
        }
    }
}
