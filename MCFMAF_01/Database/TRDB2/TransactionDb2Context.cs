using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MCFMAF_01.Database.TRDB2;

public partial class TransactionDb2Context : DbContext
{
    public TransactionDb2Context()
    {
    }

    public TransactionDb2Context(DbContextOptions<TransactionDb2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<MsStorageLocation> MsStorageLocations { get; set; }

    public virtual DbSet<TrBpkb> TrBpkbs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {

        }
    }
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
    //=> optionsBuilder.UseSqlServer("Server=LAPTOP-V2N5OE11\\SQLSERVER2016;Initial Catalog=TRANSACTION_DB2; User ID=sa;Password=mekanik12;Encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MsStorageLocation>(entity =>
        {
            entity.HasKey(e => e.LocationId);

            entity.ToTable("MS_STORAGE_LOCATION");

            entity.Property(e => e.LocationId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("LOCATION_ID");
            entity.Property(e => e.LocationName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LOCATION_NAME");
        });

        modelBuilder.Entity<TrBpkb>(entity =>
        {
            entity.HasKey(e => e.AgreementNumber);

            entity.ToTable("TR_BPKB");

            entity.Property(e => e.AgreementNumber)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("AGREEMENT_NUMBER");
            entity.Property(e => e.BpkbDate)
                .HasColumnType("datetime")
                .HasColumnName("BPKB_DATE");
            entity.Property(e => e.BpkbDateIn)
                .HasColumnType("datetime")
                .HasColumnName("BPKB_DATE_IN");
            entity.Property(e => e.BpkbNo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("BPKB_NO");
            entity.Property(e => e.BranchId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("BRANCH_ID");
            entity.Property(e => e.FakturDate)
                .HasColumnType("datetime")
                .HasColumnName("FAKTUR_DATE");
            entity.Property(e => e.FakturNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("FAKTUR_NO");
            entity.Property(e => e.LocationId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("LOCATION_ID");
            entity.Property(e => e.PoliceNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("POLICE_NO");

            entity.HasOne(d => d.Location).WithMany(p => p.TrBpkbs)
                .HasForeignKey(d => d.LocationId)
                .HasConstraintName("FK__TR_BPKB__BPKB_DA__25869641");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
