using ATMApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ATMApp.Contexts
{
    public class ATMContext : DbContext
    {
        public ATMContext(DbContextOptions<ATMContext> options) : base(options)
        {
        }

        public DbSet<Card> Cards { get; set; }
        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Card>().HasKey(c => c.CardId);

            modelBuilder.Entity<Card>().HasIndex(c => c.CardNumber).IsUnique();
            modelBuilder.Entity<Account>().HasKey(a => a.AccountId);
            #region Relations
            modelBuilder.Entity<Card>()
                .HasOne(c => c.Account)
                .WithMany(a => a.Cards)
                .HasForeignKey(c => c.AccountId);
            #endregion

            #region seed
            modelBuilder.Entity<Account>().HasData(
                               new Account
                               {
                                   AccountId = 1,
                                   AccountNumber = "123456789",
                                   AccountHolderName = "John Doe",
                                   Balance = 10000
                               },
                                new Account
                                {
                                    AccountId = 2,
                                    AccountNumber = "987654321",
                                    AccountHolderName = "Jane Doe",
                                    Balance = 5000
                                },
                                new Account
                                {
                                    AccountId = 3,
                                    AccountNumber = "123456789",
                                    AccountHolderName = "John Doe",
                                    Balance = 10000
                                });
            #endregion
        }
    }
}
