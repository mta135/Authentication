using FluentMigrator;
using FluentMigrator.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Models.DbSetup.DbMigrations
{
    [Migration(202412180959)]
    public class _202412180959_TempUserTable : Migration
    {
        public override void Down()
        {
            Delete.Table("TempUser");
        }

        public override void Up()
        {
            Create.Table("TempUser")
               .WithColumn("Id").AsInt32().PrimaryKey().NotNullable().Identity(1, 1)
               .WithColumn("Name").AsString(50).Nullable()
               .WithColumn("UserId").AsInt32().Nullable()

               .WithColumn("Password").AsString(50).Nullable()
               .WithColumn("Email").AsString(50).Nullable()
               .WithColumn("Phone").AsString(50).Nullable();

            Create.ForeignKey("FK_TempUser_Users")
                .FromTable("TempUser").ForeignColumn("UserId").ToTable("RegisteredUser").PrimaryColumn("Id").OnDelete(System.Data.Rule.Cascade);

            Create.Index("IX_TempUser_Id").OnTable("TempUser")
                .OnColumn("Id").Ascending().WithOptions().NonClustered();

        }
    }
}
