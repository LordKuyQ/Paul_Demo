using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Modul_2.Models;

public partial class Database : DbContext
{
    public Database()
    {
    }

    public Database(DbContextOptions<Database> options)
        : base(options)
    {
    }

    public virtual DbSet<Adress> Adresses { get; set; }

    public virtual DbSet<CategoryProduct> CategoryProducts { get; set; }

    public virtual DbSet<FkOrderProduct> FkOrderProducts { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Producer> Producers { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Provider> Providers { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<TypeProduct> TypeProducts { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connect = "Server=UGLYBASTARD\\SQLEXPRESS;Database=paul;Trusted_Connection=True; TrustServerCertificate=True";
        string connect_vki = "Server=dbsrv\\ag2024;Database=NDA_paul_basa_06_11;Trusted_Connection=True; TrustServerCertificate=True";
        optionsBuilder.UseSqlServer(connect_vki);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Adress>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__adress$__3213E83FAF164941");

            entity.ToTable("adress$");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Adress1)
                .HasMaxLength(255)
                .HasColumnName("adress");
        });

        modelBuilder.Entity<CategoryProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__category__3213E83F7020613C");

            entity.ToTable("category_product$");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryProduct1)
                .HasMaxLength(255)
                .HasColumnName("category_product");
        });

        modelBuilder.Entity<FkOrderProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FK_order__3213E83FC0FFCE04");

            entity.ToTable("FK_order_product$");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Count).HasColumnName("count");
            entity.Property(e => e.IdOrder).HasColumnName("id_order");
            entity.Property(e => e.IdProduct).HasColumnName("id_product");

            entity.HasOne(d => d.IdOrderNavigation).WithMany(p => p.FkOrderProducts)
                .HasForeignKey(d => d.IdOrder)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FK_order_product$_order$1");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.FkOrderProducts)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FK_order_product$_product$");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__order$__3213E83F43F0DE04");

            entity.ToTable("order$");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.DateDelivery).HasColumnName("date_delivery");
            entity.Property(e => e.DateOrder).HasColumnName("date_order");
            entity.Property(e => e.IdAdress).HasColumnName("id_adress");
            entity.Property(e => e.IdClient).HasColumnName("id_client");
            entity.Property(e => e.IdStatus).HasColumnName("id_status");

            entity.HasOne(d => d.IdAdressNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdAdress)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_order$_adress$");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdClient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_order$_user$");

            entity.HasOne(d => d.IdStatusNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdStatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_order$_status$");
        });

        modelBuilder.Entity<Producer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__producer__3213E83F1B442B4C");

            entity.ToTable("producer$");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Producer1)
                .HasMaxLength(255)
                .HasColumnName("producer");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__product$__3213E83F92680819");

            entity.ToTable("product$");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Articul)
                .HasMaxLength(255)
                .HasColumnName("articul");
            entity.Property(e => e.Cost).HasColumnName("cost");
            entity.Property(e => e.CountOnStorage).HasColumnName("count_on_storage");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Discount).HasColumnName("discount");
            entity.Property(e => e.IdCategoryProduct).HasColumnName("id_category_product");
            entity.Property(e => e.IdProducer).HasColumnName("id_producer");
            entity.Property(e => e.IdProvider).HasColumnName("id_provider");
            entity.Property(e => e.IdTypeProduct).HasColumnName("id_type_product");
            entity.Property(e => e.Photo)
                .HasMaxLength(255)
                .HasColumnName("photo");
            entity.Property(e => e.UnitMeasure)
                .HasMaxLength(255)
                .HasColumnName("unit_measure");

            entity.HasOne(d => d.IdCategoryProductNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdCategoryProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_product$_category_product$");

            entity.HasOne(d => d.IdProducerNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdProducer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_product$_producer$");

            entity.HasOne(d => d.IdProviderNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdProvider)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_product$_provider$");

            entity.HasOne(d => d.IdTypeProductNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdTypeProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_product$_type_product$");
        });

        modelBuilder.Entity<Provider>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__provider__3213E83F8F0C1EF7");

            entity.ToTable("provider$");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Provider1)
                .HasMaxLength(255)
                .HasColumnName("provider");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__role$__3213E83F2D6A0503");

            entity.ToTable("role$");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Role1)
                .HasMaxLength(255)
                .HasColumnName("role");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__status$__3213E83FF270A9E9");

            entity.ToTable("status$");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Status1)
                .HasMaxLength(255)
                .HasColumnName("status");
        });

        modelBuilder.Entity<TypeProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__type_pro__3213E83F13F28200");

            entity.ToTable("type_product$");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.TypeProduct1)
                .HasMaxLength(255)
                .HasColumnName("type_product");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__user$__3213E83F4BD02D0D");

            entity.ToTable("user$");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Fio)
                .HasMaxLength(255)
                .HasColumnName("fio");
            entity.Property(e => e.IdRole).HasColumnName("id_role");
            entity.Property(e => e.Login)
                .HasMaxLength(255)
                .HasColumnName("login");
            entity.Property(e => e.Pass)
                .HasMaxLength(255)
                .HasColumnName("pass");

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdRole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_user$_role$");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
