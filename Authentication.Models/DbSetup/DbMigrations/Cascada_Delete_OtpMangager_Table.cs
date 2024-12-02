using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Models.DbSetup.DbMigrations
{
    [Migration(7)]
    public class Cascada_Delete_OtpMangager_Table : Migration
    {
        public override void Down()
        {
           
        }

        public override void Up()
        {
            Create.ForeignKey("FK_OtpManager_Users")
                .FromTable("OtpManager").ForeignColumn("UserId")
                .ToTable("User").PrimaryColumn("Id").OnDelete(System.Data.Rule.Cascade);

        }
    }
}
