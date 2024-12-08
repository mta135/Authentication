using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Models.DbSetup.DbMigrations
{
    [Migration(10)]
    public class RenameTableUserToRegisteredUser : Migration
    {
        public override void Down()
        {
            Rename.Table("RegisteredUser").To("User");
        }

        public override void Up()
        {
            Rename.Table("User").To("RegisteredUser");
        }
    }
}
