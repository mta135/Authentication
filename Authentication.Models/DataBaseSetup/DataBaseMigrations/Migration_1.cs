using FluentMigrator;
using System.Data;

namespace Auth.Models.DbSetup.DataBaseMigrations
{

    [Migration(1)]
    public class Migration_1 : Migration
    {
        public override void Down()
        {
            Delete.Table("User");

            Delete.PrimaryKey("PK_User").FromTable("User");
        }

        public override void Up()
        {
            Create.Table("User")
                .WithColumn("Id").AsInt32().NotNullable().Identity()
                .WithColumn("Name").AsString(50).Nullable()

                .WithColumn("Password").AsString(50).Nullable()
                .WithColumn("Email").AsString(50).Nullable()
                .WithColumn("Role").AsString(50).Nullable()

                .WithColumn("IsActive").AsBoolean().Nullable().WithDefaultValue(true);

            Create.PrimaryKey("PK_User")
                .OnTable("User")
                .Column("Id");

        }
    }
}
