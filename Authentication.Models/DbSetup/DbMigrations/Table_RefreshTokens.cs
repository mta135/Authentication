using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Models.DbSetup.DbMigrations
{
    [Migration(11)]
    public class Table_RefreshTokens : Migration
    {
        public override void Down()
        {
            Delete.Table("RefreshToken");
        }

        public override void Up()
        {
            Create.Table("RefreshToken")
              .WithColumn("UserId").AsInt32().Nullable()
              .WithColumn("TokenId").AsString().Nullable()
              .WithColumn("RefreshToken").AsString(int.MaxValue).Nullable()
              .WithColumn("IsActive").AsBoolean().Nullable();

            Create.ForeignKey("FK_RefreshToken_Users")
                .FromTable("RefreshToken").ForeignColumn("UserId").ToTable("RegisteredUser").PrimaryColumn("Id").OnDelete(System.Data.Rule.Cascade);

            Create.Index("IX_RefreshToken_Id").OnTable("RefreshToken")
                .OnColumn("UserId").Ascending().WithOptions().NonClustered();
        }
    }
}
