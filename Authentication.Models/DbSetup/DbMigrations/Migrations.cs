using Authentication.Models.DbSetup.DbMigrations;

namespace Auth.Models.DbSetup.DataBaseMigrations
{
    public class Migrations
    {
        public Migrations()
        {
            _ = new Migration_1();
            _ = new Migration_2();
        }
    }
}
