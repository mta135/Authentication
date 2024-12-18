using FluentMigrator;
using FluentMigrator.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Migrations.Migrations
{
    [Migration(202412180958)]    
    
    public class _202412180958_OtpManagerTabel : Migration
    {
        public override void Down()
        {
            Delete.Table("OtpManager");
        }

        public override void Up()
        {
            Create.Table("OtpManager")
                 .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity(1, 1)

                 .WithColumn("UserId").AsInt32().Nullable()
                 .WithColumn("OtpText").AsString(50).Nullable()

                 .WithColumn("OtpType").AsString(50).Nullable()
                 .WithColumn("ExpirationDate").AsDateTime2().Nullable()
                 .WithColumn("CreateddateDate").AsDateTime2().Nullable();

            Create.ForeignKey("FK_OtpManager_RegisteredUser")
               .FromTable("OtpManager").ForeignColumn("UserId")
               .ToTable("RegisteredUser").PrimaryColumn("Id").OnDelete(System.Data.Rule.Cascade);

        }
    }
}


