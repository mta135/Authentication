using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Models.DbSetup.DbMigrations
{
    [Migration(5)]
    public class Drop_ForignKey : Migration
    {
        public override void Down()
        {
            
        }

        public override void Up()
        {
            Delete.ForeignKey("FK_OtpManager_Users").OnTable("OtpManager");
        }
    }
}
