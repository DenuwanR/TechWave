using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ECOMSYSTEM.DataAccess.EntityModel
{
    public partial class ECOM_WebContext : DbContext
    {
        public ECOM_WebContext()
        {
        }

        public ECOM_WebContext(DbContextOptions<ECOM_WebContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblItemCart> TblItemCarts { get; set; } = null!;
        public virtual DbSet<TblOrder> TblOrders { get; set; } = null!;
        public virtual DbSet<TblProduct> TblProducts { get; set; } = null!;
        public virtual DbSet<TblQuotation> TblQuotations { get; set; } = null!;
        public virtual DbSet<TblUserRegistration> TblUserRegistrations { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-VFCVBRF\\SQLEXPRESS;Initial Catalog=ECOM_Web;User ID=sa;Password=pamoda");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblItemCart>(entity =>
            {
                entity.HasKey(e => e.ItemId)
                    .HasName("PK__TblItemC__727E838B2B1B1A80");

                entity.ToTable("TblItemCart");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ItemDescription).HasMaxLength(300);

                entity.Property(e => e.ItemName).HasMaxLength(50);

                entity.Property(e => e.ItemQty).HasColumnName("ItemQTY");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.TblItemCarts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TblItemCa__Produ__3D5E1FD2");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblItemCarts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TblItemCa__UserI__3E52440B");
            });

            modelBuilder.Entity<TblOrder>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__TblOrder__C3905BCFB2BD556E");

                entity.ToTable("TblOrder");

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Mobile).HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.OrderStatus).HasMaxLength(50);

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.TblOrders)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TblOrder__ItemId__3F466844");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblOrders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TblOrder__UserId__403A8C7D");
            });

            modelBuilder.Entity<TblProduct>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK__TblProdu__B40CC6CD86C7D51F");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(350);

                entity.Property(e => e.ImageName).HasMaxLength(50);

                entity.Property(e => e.ProductName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblQuotation>(entity =>
            {
                entity.HasKey(e => e.QuotationId)
                    .HasName("PK__TblQuota__E19752939F21CC1F");

                entity.ToTable("TblQuotation");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.TblQuotations)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TblQuotat__ItemI__4BAC3F29");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.TblQuotationSuppliers)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK__TblQuotat__Suppl__4AB81AF0");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblQuotationUsers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__TblQuotat__UserI__49C3F6B7");
            });

            modelBuilder.Entity<TblUserRegistration>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__TblUserR__1788CC4CA1EA5220");

                entity.ToTable("TblUserRegistration");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNo)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
