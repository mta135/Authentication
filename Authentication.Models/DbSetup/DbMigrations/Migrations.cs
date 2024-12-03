using Authentication.Models.DbSetup.DbMigrations;

namespace Auth.Models.DbSetup.DataBaseMigrations
{
    public class Migrations
    {
        public Migrations()
        {
            _ = new Migration_1();
            _ = new Migration_2();

            _ = new Create_Otp_Table();
            _ = new Cascade_Delete();
            _ = new Drop_ForignKey();
            _ = new Cascada_Delete_OtpMangager_Table();

        }
    }
}
