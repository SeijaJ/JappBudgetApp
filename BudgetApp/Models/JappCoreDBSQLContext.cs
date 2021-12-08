﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BudgetApp.Models
{
    public partial class JappCoreDBSQLContext : DbContext
    {
        public JappCoreDBSQLContext()
        {
        }

        public JappCoreDBSQLContext(DbContextOptions<JappCoreDBSQLContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Expense> Expenses { get; set; }
        public virtual DbSet<Payee> Payees { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=JappCoreDBSQL;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Finnish_Swedish_CI_AS");

            modelBuilder.Entity<Expense>(entity =>
            {
                entity.ToTable("Expense");

                entity.Property(e => e.ExpenseId)
                    .HasColumnName("Expense_id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.ExpenseAmount)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Expense_Amount");

                entity.Property(e => e.ExpenseMonth).HasColumnName("Expense_Month");

                entity.Property(e => e.ExpenseYear).HasColumnName("Expense_Year");

                entity.Property(e => e.PayeeId).HasColumnName("Payee_id");

                entity.Property(e => e.UserId).HasColumnName("User_id");

                entity.HasOne(d => d.Payee)
                    .WithMany(p => p.Expenses)
                    .HasForeignKey(d => d.PayeeId)
                    .HasConstraintName("FK__Expense__Payee_i__03F0984C");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Expenses)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Expense__User_id__04E4BC85");
            });

            modelBuilder.Entity<Payee>(entity =>
            {
                entity.ToTable("Payee");

                entity.Property(e => e.PayeeId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.PayeeName)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId)
                    .HasColumnName("User_id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.UserFirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("User_FirstName");

                entity.Property(e => e.UserLastName)
                    .HasMaxLength(50)
                    .HasColumnName("User_LastName");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
