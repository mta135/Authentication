using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Migrations.Migrations
{
    [Migration(202412201028)]
    public class _202412201028_RegisterUserAddingColumnNrCont : Migration
    {
        public override void Down()
        {
            Delete.Column("NrCont").FromTable("RegisteredUser").InSchema("dbo");
        }

        public override void Up()
        {
            Alter.Table("RegisteredUser").AddColumn("NrCont").AsString(5).Nullable();
        }
    }
}
