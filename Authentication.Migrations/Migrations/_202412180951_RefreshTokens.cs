using FluentMigrator;
using FluentMigrator.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Models.DbSetup.DbMigrations
{
    [Migration(202412180951)]
    public class _202412180951_RefreshTokens : Migration
    {
        public override void Down()
        {
            Delete.Table("RefreshToken");
        }

        public override void Up()
        {
            Create.Table("RefreshToken")

                .WithColumn("Id").AsInt32().Identity(1, 1).PrimaryKey().NotNullable()
                .WithColumn("UserId").AsInt32().Nullable()
                .WithColumn("TokenId").AsString(50).Nullable()

                .WithColumn("RefreshedToken").AsString(int.MaxValue).Nullable()    
                .WithColumn("IsActive").AsBoolean().Nullable();

            Create.ForeignKey("FK_RefreshToken_RegisteredUser")
                .FromTable("RefreshToken").ForeignColumn("UserId").ToTable("RegisteredUser").PrimaryColumn("Id").OnDelete(System.Data.Rule.Cascade);

            Create.Index("IX_RefreshToken_Id").OnTable("RefreshToken")
                .OnColumn("UserId").Ascending().WithOptions().NonClustered();
        }
    }
}
