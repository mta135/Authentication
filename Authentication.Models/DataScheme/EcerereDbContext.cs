using System;
using System.Collections.Generic;
using Auth.Models.DbSetup.DbSetupConnection;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Api;

public partial class EcerereDbContext : DbContext
{
    public EcerereDbContext()
    {
    }

    public EcerereDbContext(DbContextOptions<EcerereDbContext> options) : base(options)
    {
    }

    public virtual DbSet<Address>? Addresses { get; set; }

    public virtual DbSet<Appointment>? Appointments { get; set; }

    public virtual DbSet<MsignRequest>? MsignRequests { get; set; }

    public virtual DbSet<MsignRequestDocument>? MsignRequestDocuments { get; set; }

    public virtual DbSet<User>? Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(ConnectionString.Connection);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Address");

            entity.Property(e => e.City).HasMaxLength(300);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.State).HasMaxLength(100);
            entity.Property(e => e.Street).HasMaxLength(500);
            entity.Property(e => e.Zip).HasMaxLength(100);
        });

        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.ToTable("Appointment");

            entity.Property(e => e.AudienceSubject).HasMaxLength(250);
            entity.Property(e => e.BirthDate).HasMaxLength(20);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Idnp)
                .HasMaxLength(13)
                .HasColumnName("IDNP");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.OrarId).HasMaxLength(250);
            entity.Property(e => e.PcerereId)
                .HasMaxLength(256)
                .HasColumnName("PCerereId");
            entity.Property(e => e.Phone).HasMaxLength(100);
            entity.Property(e => e.RegisterDate).HasMaxLength(50);
            entity.Property(e => e.ServiceId).HasMaxLength(5);
            entity.Property(e => e.ServiceName).HasMaxLength(256);
            entity.Property(e => e.ServiceTypeId).HasMaxLength(5);
            entity.Property(e => e.ServiceTypeName).HasMaxLength(100);
            entity.Property(e => e.Surname).HasMaxLength(100);
        });

        modelBuilder.Entity<MsignRequest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_SignedDocument");

            entity.ToTable("MSignRequests");

            entity.Property(e => e.MsignRequestDocumentId).HasColumnName("MSignRequestDocumentId");
            entity.Property(e => e.MsingRequestId).HasMaxLength(256);
            entity.Property(e => e.SingerIdnp).HasMaxLength(13);

            entity.HasOne(d => d.MsignRequestDocument).WithMany(p => p.MsignRequests)
                .HasForeignKey(d => d.MsignRequestDocumentId)
                .HasConstraintName("FK_SignedDocument_DocumentType");
        });

        modelBuilder.Entity<MsignRequestDocument>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_DocumentType");

            entity.ToTable("MSignRequestDocuments");

            entity.HasOne(d => d.Appointment).WithMany(p => p.MsignRequestDocuments)
                .HasForeignKey(d => d.AppointmentId)
                .HasConstraintName("FK_MSignRequestDocuments_Appointment");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Role).HasMaxLength(50);
            entity.Property(e => e.UserName).HasMaxLength(250);
        });



        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
