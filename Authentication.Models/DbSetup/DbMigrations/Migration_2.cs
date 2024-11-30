using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Models.DbSetup.DbMigrations
{
    [Migration(2)]
    public class Migration_2 : Migration
    {
        public override void Down()
        {
            Delete.Column("UserName").FromTable("User");
        }

        public override void Up()
        {
            Alter.Table("User").AddColumn("UserName").AsString(250).Nullable();
        }
    }
}
