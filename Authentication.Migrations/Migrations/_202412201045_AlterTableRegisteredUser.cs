using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Migrations.Migrations
{
    [Migration(202412201045)]
    public class _202412201045_AlterTableRegisteredUser : Migration
    {
        public override void Up()
        {
            Alter.Column("NrCont")
                .OnTable("RegisteredUser")
                .AsString(15); // Set the new length, e.g., 255 characters
        }

        public override void Down()
        {
            Alter.Column("NrCont")
                .OnTable("RegisteredUser")
                .AsString(5); // Revert to the original length, e.g., 100 characters
        }




    }
}
