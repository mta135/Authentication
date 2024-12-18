using System;
using System.Collections.Generic;
using Authentication.Models.DbConnection;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Api;

public partial class FlowersStoreDbContext : DbContext
{
    public FlowersStoreDbContext()
    {
    }

    public FlowersStoreDbContext(DbContextOptions<FlowersStoreDbContext> options) : base(options)

    {
    }

    public virtual DbSet<OtpManager> OtpManagers { get; set; }

    public virtual DbSet<RefreshToken> RefreshTokens { get; set; }

    public virtual DbSet<RegisteredUser> RegisteredUsers { get; set; }

    public virtual DbSet<TempUser> TempUsers { get; set; }



    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseSqlServer(FlowerStoreConnectionSettings.Connection);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       

        modelBuilder.Entity<RegisteredUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_User");

            entity.ToTable("RegisteredUser");

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Role).HasMaxLength(50);
            entity.Property(e => e.UserName).HasMaxLength(250);
        });

       

       
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
