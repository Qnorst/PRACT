using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Cafe.App
{
    public partial class CafeContext : DbContext
    {
        public CafeContext()
        {
        }

        public CafeContext(DbContextOptions<CafeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Dish> Dishes { get; set; } = null!;
        public virtual DbSet<DishOrder> DishOrders { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=Cafe;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dish>(entity =>
            {
                entity.ToTable("Dish");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.Time).HasColumnType("decimal(4, 2)");

                entity.Property(e => e.Title).HasMaxLength(20);
            });

            modelBuilder.Entity<DishOrder>(entity =>
            {
                entity.ToTable("Dish_Order");

                entity.Property(e => e.DishId).HasColumnName("Dish_Id");

                entity.Property(e => e.OrderId).HasColumnName("Order_Id");

                entity.HasOne(d => d.Dish)
                    .WithMany(p => p.DishOrders)
                    .HasForeignKey(d => d.DishId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Dish_Order_Dish");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.DishOrders)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Dish_Order_Orders");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.FlunkyId).HasColumnName("Flunky_Id");

                entity.Property(e => e.WaiterId).HasColumnName("Waiter_Id");

                entity.HasOne(d => d.Flunky)
                    .WithMany(p => p.OrderFlunkies)
                    .HasForeignKey(d => d.FlunkyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Users");

                entity.HasOne(d => d.Waiter)
                    .WithMany(p => p.OrderWaiters)
                    .HasForeignKey(d => d.WaiterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Users1");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.FirstName).HasMaxLength(20);

                entity.Property(e => e.LastName).HasMaxLength(20);

                entity.Property(e => e.Login).HasMaxLength(20);

                entity.Property(e => e.Password).HasMaxLength(20);

                entity.Property(e => e.SecondName).HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
