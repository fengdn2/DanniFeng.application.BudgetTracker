using BudgetTracker.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetTracker.Infrastructure.Data
{
    public class BudgetTrackerDbContext:DbContext
    {

        public BudgetTrackerDbContext(DbContextOptions<BudgetTrackerDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(ConfigureUser);
            modelBuilder.Entity<Income>(ConfigureIncome);
            modelBuilder.Entity<Expenditure>(ConfigureExpenditure);
        }

        private void ConfigureUser(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(u => u.Id);
            builder.HasIndex(u => u.Email).IsUnique();
            builder.Property(u => u.Email).IsRequired().HasMaxLength(50);
            builder.Property(u => u.Password).IsRequired().HasMaxLength(10);
            builder.Property(u => u.Fullname).HasMaxLength(50);
            builder.Property(u => u.JoinedOn).HasDefaultValueSql("getdate()");
        }

        private void ConfigureIncome(EntityTypeBuilder<Income> builder)
        {
            builder.ToTable("Incomes");
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Amount).IsRequired().HasColumnType("money");
            builder.Property(i => i.Description).HasMaxLength(100);
            builder.Property(i => i.IncomeDate);
            builder.Property(i => i.Remarks).HasMaxLength(500);
        }

        private void ConfigureExpenditure(EntityTypeBuilder<Expenditure> builder)
        {
            builder.ToTable("Expenditures");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Amount).IsRequired().HasColumnType("money");
            builder.Property(e => e.Description).HasMaxLength(100);
            builder.Property(e => e.ExpDate);
            builder.Property(e => e.Remarks).HasMaxLength(500);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Expenditure> Expenditures { get; set; }
    }
}
