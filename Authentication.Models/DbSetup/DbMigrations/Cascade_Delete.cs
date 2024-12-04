using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Models.DbSetup.DbMigrations
{
    [Migration(6)]
    public class Cascade_Delete : Migration
    {
        public override void Down()
        {
            Delete.ForeignKey("FK_OtpManager_Users").OnTable("OtpManager");
        }

        public override void Up()
        {
            if (!Schema.Table("OtpManager").Constraint("FK_OtpManager_Users").Exists())
            {
                Create.ForeignKey("FK_OtpManager_Users")
                    .FromTable("OtpManager").ForeignColumn("UserId")
                    .ToTable("User").PrimaryColumn("Id")
                    .OnDeleteOrUpdate(System.Data.Rule.Cascade); // Set cascade on delete
            }


        }
    }
}
