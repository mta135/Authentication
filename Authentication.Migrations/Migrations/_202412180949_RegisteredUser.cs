using FluentMigrator;
using FluentMigrator.SqlServer;
using System.Data;

namespace Auth.Models.DbSetup.DataBaseMigrations
{

    [Migration(202412180949)]
    public class _202412180949_RegisteredUser : Migration
    {
        public override void Down()
        {
            Delete.Table("RegisteredUser");
        }

        public override void Up()
        {
            Create.Table("RegisteredUser")
                .WithColumn("Id").AsInt32().NotNullable().Identity(1, 1).PrimaryKey()

                .WithColumn("Name").AsString(50).Nullable()
                .WithColumn("UserName").AsString(250).Nullable()

                .WithColumn("Password").AsString(50).Nullable()
                .WithColumn("Email").AsString(50).Nullable()
                .WithColumn("Role").AsString(50).Nullable()

                .WithColumn("IsActive").AsBoolean().Nullable().WithDefaultValue(true)
                .WithColumn("IsConfirmed").AsBoolean().Nullable();
        }
    }
}
