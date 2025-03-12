namespace FinanceApi.Infra.Persistence
{
    using FinanceApi.Domain.Accounts;
    using FinanceApi.Domain.Categories;
    using FinanceApi.Domain.CreditCards;
    using FinanceApi.Domain.DebtInstallments;
    using FinanceApi.Domain.Debts;
    using FinanceApi.Domain.GroupCategory;
    using FinanceApi.Domain.PaymentMethod;
    using FinanceApi.Domain.Transactions;
    using FinanceApi.Domain.Users;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;

    public class AppDbContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }

        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<GroupCategoryEntity> Group_Category { get; set; }

        public DbSet<AccountEntity> Account { get; set; }
        public DbSet<CreditCardEntity> CreditCard { get; set; }

        public DbSet<DebtsEntity> Debts { get; set; }
        public DbSet<DebtInstallmentsEntity> DebtInstallments { get; set; }

        public DbSet<TransactionsEntity> Transactions { get; set; }
        public DbSet<PaymentMethodEntity> PaymentMethod { get; set; }

        private IConfiguration _configuration;

        public AppDbContext(IConfiguration configuration,DbContextOptions<AppDbContext> options) : base(options)         {
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

            modelBuilder.Entity<DebtInstallmentsEntity>()
                .HasOne(di => di.Debt)
                .WithMany(d => d.DebtInstallments)
                .HasForeignKey(di => di.DebtId);

            modelBuilder.Entity<DebtsEntity>()
                .HasOne(d => d.User)
                .WithMany()
                .HasForeignKey(d => d.UserId);

            modelBuilder.Entity<DebtsEntity>()
                .HasOne(d => d.Account)
                .WithMany()
                .HasForeignKey(d => d.AccountId);

            modelBuilder.Entity<DebtsEntity>()
                .HasOne(d => d.CreditCard)
                .WithMany()
                .HasForeignKey(d => d.CreditCardId);

            modelBuilder.Entity<DebtsEntity>()
                .HasOne(d => d.Category)
                .WithMany()
                .HasForeignKey(d => d.CategoryId);
            modelBuilder.Entity<TransactionsEntity>()
               .HasOne(t => t.User)
               .WithMany()
               .HasForeignKey(t => t.UserId);

            modelBuilder.Entity<TransactionsEntity>()
                .HasOne(t => t.Account)
                .WithMany()
                .HasForeignKey(t => t.AccountId);

            modelBuilder.Entity<TransactionsEntity>()
                .HasOne(t => t.CreditCard)
                .WithMany()
                .HasForeignKey(t => t.CreditCardId);

            modelBuilder.Entity<TransactionsEntity>()
                .HasOne(t => t.Debt)
                .WithMany()
                .HasForeignKey(t => t.DebtId);

            modelBuilder.Entity<TransactionsEntity>()
                .HasOne(t => t.DebtInstallment)
                .WithMany()
                .HasForeignKey(t => t.InstallmentId);

            modelBuilder.Entity<TransactionsEntity>()
                .HasOne(t => t.Category)
                .WithMany()
                .HasForeignKey(t => t.CategoryId);

            modelBuilder.Entity<TransactionsEntity>()
                .HasOne(t => t.PaymentMethod)
                .WithMany()
                .HasForeignKey(t => t.PaymentMethodId);

            modelBuilder.Entity<PaymentMethodEntity>()
                .ToTable("PaymentMethod");
            base.OnModelCreating(modelBuilder);
        }
    }
}
