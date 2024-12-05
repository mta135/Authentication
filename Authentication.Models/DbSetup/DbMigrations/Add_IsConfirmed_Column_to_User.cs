using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Models.DbSetup.DbMigrations
{
    [Migration(9)]
    public class Add_IsConfirmed_Column_to_User : Migration
    {
        public override void Down()
        {
            Delete.Column("IsConfirmed").FromTable("User");
        }

        public override void Up()
        {
            Alter.Table("User").AddColumn("IsConfirmed").AsBoolean().Nullable();
        }
    }
}
