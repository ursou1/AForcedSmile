using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AForcedSmile.db
{
    public partial class ForcedSmileContext : DbContext
    {
        public ForcedSmileContext()
        {
        }

        public ForcedSmileContext(DbContextOptions<ForcedSmileContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<DeliveryNote> DeliveryNotes { get; set; }
        public virtual DbSet<DepartNote> DepartNotes { get; set; }
        public virtual DbSet<PartOfWarehouse> PartOfWarehouses { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductPartOfWarehouse> ProductPartOfWarehouses { get; set; }
        public virtual DbSet<ProductType> ProductTypes { get; set; }
        public virtual DbSet<Provider> Providers { get; set; }
        public virtual DbSet<SoftDelete> SoftDeletes { get; set; }
        public virtual DbSet<Unit> Units { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-5RQNSD1;Initial Catalog=ForcedSmile;Trusted_Connection=True; ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FatherName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telephone)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DeliveryNote>(entity =>
            {
                entity.ToTable("DeliveryNote");

                entity.Property(e => e.DeliveryDate).HasColumnType("datetime");

                entity.HasOne(d => d.Provider)
                    .WithMany(p => p.DeliveryNotes)
                    .HasForeignKey(d => d.ProviderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DeliveryNote_Provider1");
            });

            modelBuilder.Entity<DepartNote>(entity =>
            {
                entity.ToTable("DepartNote");

                entity.Property(e => e.DepartDate).HasColumnType("datetime");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.DepartNotes)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DepartNote_Client");
            });

            modelBuilder.Entity<PartOfWarehouse>(entity =>
            {
                entity.ToTable("PartOfWarehouse");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Image).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.DeliveryNote)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.DeliveryNoteId)
                    .HasConstraintName("FK_Product_DeliveryNote");

                entity.HasOne(d => d.DepartNote)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.DepartNoteId)
                    .HasConstraintName("FK_Product_DepartNote");

                entity.HasOne(d => d.ProductType)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductTypeId)
                    .HasConstraintName("FK_Product_ProductType");

                entity.HasOne(d => d.SoftDelete)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.SoftDeleteId)
                    .HasConstraintName("FK_Product_SoftDelete");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Unit");
            });

            modelBuilder.Entity<ProductPartOfWarehouse>(entity =>
            {
                entity.ToTable("ProductPartOfWarehouse");

                entity.HasOne(d => d.PartOfWarehouse)
                    .WithMany(p => p.ProductPartOfWarehouses)
                    .HasForeignKey(d => d.PartOfWarehouseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductPartOfWarehouse_PartOfWarehouse");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductPartOfWarehouses)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductPartOfWarehouse_Product");
            });

            modelBuilder.Entity<ProductType>(entity =>
            {
                entity.ToTable("ProductType");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Provider>(entity =>
            {
                entity.ToTable("Provider");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telephone)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SoftDelete>(entity =>
            {
                entity.ToTable("SoftDelete");

                entity.Property(e => e.DeleteDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.ToTable("Unit");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
