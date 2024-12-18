using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Migrations.Migrations
{
    [Migration(202412181312)]
    public class _202412181312_MenuRolesPermisionTables : Migration
    {
        public override void Down()
        {
            Delete.ForeignKey("FK_Permission_RegisteredUserRole").OnTable("Permission");

            Delete.ForeignKey("FK_Permission_Menu").OnTable("Permission");

            Delete.Table("RegisteredUserRole");

            Delete.Table("Permission");

            Delete.Table("Menu");
        }

        public override void Up()
        {
            Create.Table("RegisteredUserRole")
               .WithColumn("Id").AsInt32().PrimaryKey().Identity()
               .WithColumn("RoleId").AsInt32().Nullable()
               .WithColumn("Name").AsString(50).Nullable();

            Create.Table("Permission")
               .WithColumn("Id").AsInt32().PrimaryKey().Identity()

               .WithColumn("RoleId").AsInt32().Nullable()
               .WithColumn("MenuId").AsInt32().Nullable();

            Create.Table("Menu")
              .WithColumn("Id").AsInt32().PrimaryKey().Identity()
              .WithColumn("Name").AsString(50).Nullable()
              .WithColumn("LinkName").AsString(50).Nullable();

            Create.ForeignKey("FK_Permission_RegisteredUserRole").FromTable("Permission").ForeignColumn("RoleId")
               .ToTable("RegisteredUserRole").PrimaryColumn("Id").OnDelete(System.Data.Rule.Cascade);

            Create.ForeignKey("FK_Permission_Menu").FromTable("Permission").ForeignColumn("MenuId")
            .ToTable("Menu").PrimaryColumn("Id").OnDelete(System.Data.Rule.Cascade);


        }
    }
}
