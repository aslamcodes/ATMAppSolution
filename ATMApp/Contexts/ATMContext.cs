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
        }
    }
}
