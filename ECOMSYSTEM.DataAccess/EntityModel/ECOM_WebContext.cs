using System;
using Microsoft.EntityFrameworkCore;
using ECOMSYSTEM.DataAccess.EntityModel;

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
        public virtual DbSet<TblUserRegistration> TblUserRegistrations { get; set; } = null!;
        public virtual DbSet<TblQuotation> TblQuotations { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-F81GNF66;Initial Catalog=ECOSYSTEMn;User ID=ecom;Password=1111;Encrypt=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblItemCart>(entity =>
            {
                entity.HasKey(e => e.ItemId)
                    .HasName("PK__tmp_ms_x__727E838B36C57308");

                entity.ToTable("TblItemCart");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.ItemDescription).HasMaxLength(300);
                entity.Property(e => e.ItemName).HasMaxLength(50);
                entity.Property(e => e.ItemQty).HasColumnName("ItemQTY");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.TblItemCarts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TblItemCa__Produ__5CD6CB2B");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblItemCarts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TblItemCa__UserI__4AB81AF0");
            });

            modelBuilder.Entity<TblOrder>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__TblOrder__C3905BCF4ABEA67D");

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
                    .HasConstraintName("FK__TblOrder__ItemId__4D94879B");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblOrders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TblOrder__UserId__4E88ABD4");
            });

            modelBuilder.Entity<TblProduct>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK__tmp_ms_x__B40CC6CD8808E9F9");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.Description).HasMaxLength(350);
                entity.Property(e => e.ImageName).HasMaxLength(50);
                entity.Property(e => e.ProductName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblUserRegistration>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__TblUserR__1788CC4CA80DDAD3");

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

            modelBuilder.Entity<TblQuotation>(entity =>
            {
                entity.HasKey(e => e.QuotationId)
                    .HasName("PK__TblQuota__2B1397A1D476A42B");

                entity.ToTable("TblQuotation");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.QuotationStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.TblQuotation)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TblQuota__ItemId__5CD6CB2B"); // Updated foreign key name

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.TblQuotationsAsSupplier)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TblQuota__Suppli__4AB81AF0");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
