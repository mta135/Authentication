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

    public FlowersStoreDbContext(DbContextOptions<FlowersStoreDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<OtpManager> OtpManagers { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<RefreshToken> RefreshTokens { get; set; }

    public virtual DbSet<RegisteredUser> RegisteredUsers { get; set; }

    public virtual DbSet<RegisteredUserRole> RegisteredUserRoles { get; set; }

    public virtual DbSet<TempUser> TempUsers { get; set; }

    public virtual DbSet<VersionInfo> VersionInfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseSqlServer(FlowerStoreConnectionSettings.Connection);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Menu>(entity =>
        {
            entity.ToTable("Menu");

            entity.Property(e => e.LinkName).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<OtpManager>(entity =>
        {
            entity.ToTable("OtpManager");

            entity.Property(e => e.OtpText).HasMaxLength(50);
            entity.Property(e => e.OtpType).HasMaxLength(50);

            entity.HasOne(d => d.User).WithMany(p => p.OtpManagers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_OtpManager_RegisteredUser");
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.ToTable("Permission");

            entity.HasOne(d => d.Menu).WithMany(p => p.Permissions)
                .HasForeignKey(d => d.MenuId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Permission_Menu");

            entity.HasOne(d => d.Role).WithMany(p => p.Permissions)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Permission_RegisteredUserRole");
        });

        modelBuilder.Entity<RefreshToken>(entity =>
        {
            entity.ToTable("RefreshToken");

            entity.HasIndex(e => e.UserId, "IX_RefreshToken_Id");

            entity.Property(e => e.TokenId).HasMaxLength(50);

            entity.HasOne(d => d.User).WithMany(p => p.RefreshTokens)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_RefreshToken_RegisteredUser");
        });

        modelBuilder.Entity<RegisteredUser>(entity =>
        {
            entity.ToTable("RegisteredUser");

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Role).HasMaxLength(50);
            entity.Property(e => e.UserName).HasMaxLength(250);
        });

        modelBuilder.Entity<RegisteredUserRole>(entity =>
        {
            entity.ToTable("RegisteredUserRole");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<TempUser>(entity =>
        {
            entity.ToTable("TempUser");

            entity.HasIndex(e => e.Id, "IX_TempUser_Id");

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(50);

            entity.HasOne(d => d.User).WithMany(p => p.TempUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_TempUser_Users");
        });

        modelBuilder.Entity<VersionInfo>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("VersionInfo");

            entity.HasIndex(e => e.Version, "UC_Version")
                .IsUnique()
                .IsClustered();

            entity.Property(e => e.AppliedOn).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(1024);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
