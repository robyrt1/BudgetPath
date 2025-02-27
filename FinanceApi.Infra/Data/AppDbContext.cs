﻿using FinanceApi.Domain.Accounts;
using FinanceApi.Domain.Categories;
using FinanceApi.Domain.CreditCards;
using FinanceApi.Domain.GroupCategory;
using FinanceApi.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FinanceApi.Infra.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }

        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<GroupCategoryEntity> Group_Category { get; set; }
        
        public DbSet<AccountEntity> Account { get; set; }
        public DbSet<CreditCardEntity> CreditCard { get; set; }

        private IConfiguration _configuration;

        public AppDbContext(IConfiguration configuration,DbContextOptions<AppDbContext> options) : base(options) {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var typeDatabase = "AZURE_SQL_CONNECTIONSTRING";
            var conectionString = _configuration.GetConnectionString(typeDatabase);
            options.UseSqlServer(conectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>()
                .Property(user=> user.EmailLower)
                .HasComputedColumnSql("LOWER(Email)");

            modelBuilder.Entity<CategoryEntity>()
                .HasOne(c => c.Group)
                .WithMany()
                .HasForeignKey(c => c.GroupId);

            modelBuilder.Entity<CategoryEntity>()
                .HasMany(c => c.SubCategories)
                .WithOne()
                .HasForeignKey(c => c.ParentId);

            modelBuilder.Entity<GroupCategoryEntity>()
                .ToTable("Group_Category");

            modelBuilder.Entity<AccountEntity>()
                .Property(a => a.Balance)
                .HasPrecision(18, 4);

            modelBuilder.Entity<AccountEntity>()
                .HasOne(a => a.User)
                .WithMany()
                .HasForeignKey(a => a.UserId);


            modelBuilder.Entity<CreditCardEntity>()
                .ToTable("CreditCard");

            modelBuilder.Entity<CreditCardEntity>()
                .HasOne(cc => cc.Account)
                .WithMany()
                .HasForeignKey(cc => cc.AccountId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
