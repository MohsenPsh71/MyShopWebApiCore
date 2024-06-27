using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SampleWebApiCore.Models;

public partial class MyShopDbContext : DbContext
{
    public MyShopDbContext()
    {
    }

    public MyShopDbContext(DbContextOptions<MyShopDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Products> Products { get; set; }

    public virtual DbSet<SalesPersons> SalesPersons { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.Property(e => e.Adress).IsFixedLength();
            entity.Property(e => e.City).IsFixedLength();
            entity.Property(e => e.Email).IsFixedLength();
            entity.Property(e => e.FirstName).IsFixedLength();
            entity.Property(e => e.LastName).IsFixedLength();
            entity.Property(e => e.Phone).IsFixedLength();
            entity.Property(e => e.State).IsFixedLength();
            entity.Property(e => e.ZipCode).IsFixedLength();
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.Property(e => e.Status).IsFixedLength();

            entity.HasOne(d => d.Costomer).WithMany(p => p.Orders).HasConstraintName("FK_Orders_Customer");

            entity.HasOne(d => d.SalesPersonNavigation).WithMany(p => p.Orders).HasConstraintName("FK_Orders_SalesPersons");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems).HasConstraintName("FK_OrderItems_Orders");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderItems).HasConstraintName("FK_OrderItems_Products");
        });

        modelBuilder.Entity<Products>(entity =>
        {
            entity.Property(e => e.ProductName).IsFixedLength();
            entity.Property(e => e.Status).IsFixedLength();
            entity.Property(e => e.Varienty).IsFixedLength();
        });

        modelBuilder.Entity<SalesPersons>(entity =>
        {
            entity.HasKey(e => e.SalesPersonId).HasName("PK_SalesPerson");

            entity.Property(e => e.Address).IsFixedLength();
            entity.Property(e => e.City).IsFixedLength();
            entity.Property(e => e.Email).IsFixedLength();
            entity.Property(e => e.FirstName).IsFixedLength();
            entity.Property(e => e.LastName).IsFixedLength();
            entity.Property(e => e.Phone).IsFixedLength();
            entity.Property(e => e.State).IsFixedLength();
            entity.Property(e => e.ZipeCode).IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
