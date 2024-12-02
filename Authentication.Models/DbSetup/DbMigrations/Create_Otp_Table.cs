using FluentMigrator;

namespace Authentication.Models.DbSetup.DbMigrations
{
    [Migration(3)]
    public class Create_Otp_Table : Migration
    {
        public override void Down()
        {
            Delete.Table("OtpManager");
        }

        public override void Up()
        {
            Create.Table("OtpManager")
                 .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()

                 .WithColumn("UserId").AsInt32().Nullable()
                 .WithColumn("OtpText").AsString(50).Nullable()

                 .WithColumn("OtpType").AsString(50).Nullable()
                 .WithColumn("ExpirationDate").AsDateTime2().Nullable()
                 .WithColumn("CreateddateDate").AsDateTime2().Nullable();

            Create.ForeignKey("FK_OtpManager_Users")
                .FromTable("OtpManager").ForeignColumn("UserId")
                .ToTable("User").PrimaryColumn("Id");

        }
    }
}
