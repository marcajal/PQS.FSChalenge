using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PQS.FSChalenge2.Models
{
    public partial class PQSFSChalengedbContext : DbContext
    {
        public PQSFSChalengedbContext()
        {
        }

        public PQSFSChalengedbContext(DbContextOptions<PQSFSChalengedbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<OrdersItems> OrdersItems { get; set; }
        public virtual DbSet<VOrdersInfo> VOrdersInfo { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK_ORDER");

                entity.ToTable("ORDERS");

                entity.HasIndex(e => e.Status)
                    .HasName("IX_ORDER_Status");

                entity.Property(e => e.AuthDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.OrderDescription)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<OrdersItems>(entity =>
            {
                entity.HasKey(e => e.OrderItemId)
                    .HasName("PK_ORDER_ITEMS")
                    .IsClustered(false);

                entity.ToTable("ORDERS_ITEMS");

                entity.HasIndex(e => e.OrderId)
                    .HasName("IX_ORDER_ITEMS_OrderId")
                    .IsClustered();

                entity.Property(e => e.ItemDescription)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.UnitPrice).HasColumnType("numeric(32, 2)");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrdersItems)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ORDER_ITEMS_ORDERS");
            });

            modelBuilder.Entity<VOrdersInfo>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vORDERS_INFO");

                entity.Property(e => e.AuthDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.OrderDescription)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.UnitPrice).HasColumnType("numeric(38, 2)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
