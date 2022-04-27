using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Pract
{
    public partial class gr604_midseContext : DbContext
    {
        public gr604_midseContext()
        {
        }

        public gr604_midseContext(DbContextOptions<gr604_midseContext> options)
            : base(options)
        {
        }

        
        
        public virtual DbSet<LotsOf> LotsOf { get; set; } = null!;
        public virtual DbSet<Order> Order { get; set; } = null!;
        
       
        public virtual DbSet<Product> Product { get; set; } = null!;
    
        public virtual DbSet<StatusCooker> StatusCooker { get; set; } = null!;
        public virtual DbSet<StatusWaiter> StatusWaiter { get; set; } = null!;
        public virtual DbSet<User> User { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=mssql;Initial Catalog=gr604_midse;Trusted_Connection=True;");
                optionsBuilder.UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           

           

            modelBuilder.Entity<LotsOf>(entity =>
            {
                entity.ToTable("LotsOf");

                entity.Property(e => e.LotsOfId).HasColumnName("LotsOfID");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.LotsOfs)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LotsOf_Order");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.LotsOfs)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LotsOf_Product");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.Data).HasColumnType("datetime");

                entity.Property(e => e.LotsOfId).HasColumnName("LotsOfID");

                entity.Property(e => e.Payment).HasColumnType("money");

                entity.Property(e => e.StatusCookerId).HasColumnName("StatusCookerID");

                entity.Property(e => e.StatusWaiterId).HasColumnName("StatusWaiterID");

                entity.Property(e => e.WorkerId).HasColumnName("WorkerID");

                entity.HasOne(d => d.StatusCooker)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StatusCookerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_StatusCooker");

                entity.HasOne(d => d.StatusWaiter)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StatusWaiterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_StatusWaiter");

                entity.HasOne(d => d.Worker)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.WorkerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_WorkerPract");
            });

           

            

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Pay).HasColumnType("money");

                entity.Property(e => e.Time).HasColumnType("time(6)");
            });

            

            modelBuilder.Entity<StatusWaiter>(entity =>
            {
                entity.ToTable("StatusWaiter");

                entity.Property(e => e.StatusWaiterId).HasColumnName("StatusWaiterID");

                entity.Property(e => e.StatusPaymentOrder).HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.WorkerId)
                    .HasName("PK_Worker");

                entity.ToTable("User");

                entity.Property(e => e.WorkerId).HasColumnName("WorkerID");

                entity.Property(e => e.Login).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Position).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
