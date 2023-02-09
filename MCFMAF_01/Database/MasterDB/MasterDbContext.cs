using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MCFMAF_01.Database.MasterDB;

public partial class MasterDbContext : DbContext
{
    public MasterDbContext()
    {
    }

    public MasterDbContext(DbContextOptions<MasterDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MsUser> MsUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {

        }
    }
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
    //=> optionsBuilder.UseSqlServer("Server=LAPTOP-V2N5OE11\\SQLSERVER2016;Initial Catalog=MASTER_DB; User ID=sa;Password=mekanik12;Encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MsUser>(entity =>
        {
            entity.HasKey(e => e.Username);

            entity.ToTable("MS_USER");

            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("USERNAME");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PASSWORD");
            entity.Property(e => e.UserType)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("USER_TYPE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
