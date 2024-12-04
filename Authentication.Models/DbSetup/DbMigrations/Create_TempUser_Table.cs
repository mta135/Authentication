using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Models.DbSetup.DbMigrations
{
    [Migration(8)]
    public class Create_TempUser_Table : Migration
    {
        public override void Down()
        {
            Delete.Table("TempUser");
        }

        public override void Up()
        {
            Create.Table("TempUser")
               .WithColumn("Id").AsInt32().PrimaryKey().NotNullable().Identity()
               .WithColumn("Name").AsString(50).Nullable()
               .WithColumn("UserId").AsInt32().Nullable()

               .WithColumn("Password").AsString(50).Nullable()
               .WithColumn("Email").AsString(50).Nullable()
               .WithColumn("Phone").AsString(50).Nullable();

            Create.ForeignKey("FK_TempUser_Users")
                .FromTable("TempUser").ForeignColumn("UserId").ToTable("User").PrimaryColumn("Id").OnDelete(System.Data.Rule.Cascade);

            Create.Index("IX_TempUser_Id").OnTable("TempUser")
                .OnColumn("Id").Ascending().WithOptions().NonClustered();

        }
    }
}
