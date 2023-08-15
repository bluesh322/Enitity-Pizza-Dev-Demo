using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SchittkoSlices.Models
{
    public partial class SchittkoSlicesDBContext : DbContext
    {
        public SchittkoSlicesDBContext()
        {
        }

        public SchittkoSlicesDBContext(DbContextOptions<SchittkoSlicesDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<CustomerDrink> CustomerDrinks { get; set; } = null!;
        public virtual DbSet<CustomerOrder> CustomerOrders { get; set; } = null!;
        public virtual DbSet<CustomerOrderPreference> CustomerOrderPreferences { get; set; } = null!;
        public virtual DbSet<CustomerPizza> CustomerPizzas { get; set; } = null!;
        public virtual DbSet<Drink> Drinks { get; set; } = null!;
        public virtual DbSet<Pizza> Pizzas { get; set; } = null!;
        public virtual DbSet<Size> Sizes { get; set; } = null!;
        public virtual DbSet<Topping> Toppings { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Name=SchittkoSlicesDB");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(60)
                    .HasColumnName("address");

                entity.Property(e => e.Name)
                    .HasMaxLength(60)
                    .HasColumnName("name");

                entity.Property(e => e.Phone)
                    .HasMaxLength(14)
                    .HasColumnName("phone");
            });

            modelBuilder.Entity<CustomerDrink>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("customer_drinks");

                entity.Property(e => e.CustomerOrderId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("customer_order_id");

                entity.Property(e => e.Drink)
                    .HasMaxLength(20)
                    .HasColumnName("drink");

                entity.HasOne(d => d.CustomerOrder)
                    .WithMany()
                    .HasForeignKey(d => d.CustomerOrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("customer_drinks_customer_order_id_fkey");

                entity.HasOne(d => d.DrinkNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Drink)
                    .HasConstraintName("customer_drinks_drink_fkey");
            });

            modelBuilder.Entity<CustomerOrder>(entity =>
            {
                entity.ToTable("customer_order");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreditCardId).HasColumnName("credit_card_id");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.TotalPrice)
                    .HasColumnType("money")
                    .HasColumnName("total_price");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerOrders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("customer_order_customer_id_fkey");
            });

            modelBuilder.Entity<CustomerOrderPreference>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("customer_order_preference");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.CustomerOrderId).HasColumnName("customer_order_id");

                entity.HasOne(d => d.Customer)
                    .WithMany()
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("customer_order_preference_customer_id_fkey");

                entity.HasOne(d => d.CustomerOrder)
                    .WithMany()
                    .HasForeignKey(d => d.CustomerOrderId)
                    .HasConstraintName("customer_order_preference_customer_order_id_fkey");
            });

            modelBuilder.Entity<CustomerPizza>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("customer_pizzas");

                entity.Property(e => e.CustomerOrderId).HasColumnName("customer_order_id");

                entity.Property(e => e.PizzaId).HasColumnName("pizza_id");

                entity.HasOne(d => d.CustomerOrder)
                    .WithMany()
                    .HasForeignKey(d => d.CustomerOrderId)
                    .HasConstraintName("customer_pizzas_customer_order_id_fkey");

                entity.HasOne(d => d.Pizza)
                    .WithMany()
                    .HasForeignKey(d => d.PizzaId)
                    .HasConstraintName("customer_pizzas_pizza_id_fkey");
            });

            modelBuilder.Entity<Drink>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("drinks_pkey");

                entity.ToTable("drinks");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .HasColumnName("name");

                entity.Property(e => e.Price)
                    .HasColumnType("money")
                    .HasColumnName("price");
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.ToTable("pizzas");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Size)
                    .HasMaxLength(2)
                    .HasColumnName("size");

                entity.Property(e => e.Topping1)
                    .HasMaxLength(20)
                    .HasColumnName("topping_1");

                entity.Property(e => e.Topping2)
                    .HasMaxLength(20)
                    .HasColumnName("topping_2");

                entity.HasOne(d => d.SizeNavigation)
                    .WithMany(p => p.Pizzas)
                    .HasForeignKey(d => d.Size)
                    .HasConstraintName("pizzas_size_fkey");

                entity.HasOne(d => d.Topping1Navigation)
                    .WithMany(p => p.PizzaTopping1Navigation)
                    .HasForeignKey(d => d.Topping1)
                    .HasConstraintName("pizzas_topping_1_fkey");

                entity.HasOne(d => d.Topping2Navigation)
                    .WithMany(p => p.PizzaTopping2Navigation)
                    .HasForeignKey(d => d.Topping2)
                    .HasConstraintName("pizzas_topping_2_fkey");
            });

            modelBuilder.Entity<Size>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("sizes_pkey");

                entity.ToTable("sizes");

                entity.Property(e => e.Name)
                    .HasMaxLength(2)
                    .HasColumnName("name");

                entity.Property(e => e.Price)
                    .HasColumnType("money")
                    .HasColumnName("price");
            });

            modelBuilder.Entity<Topping>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("toppings_pkey");

                entity.ToTable("toppings");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
