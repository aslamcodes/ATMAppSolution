using ATMApp.Contexts;
using ATMApp.Exceptions.Account;
using ATMApp.Interfaces;
using ATMApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ATMApp.Repositories
{
    public class AccountRepository : IRepository<int, Account>
    {

        public readonly ATMContext _context;
        public AccountRepository(ATMContext context)
        {
            _context = context;
        }
        public async Task<Account> Add(Account item)
        {
            try
            {
                var account = _context.Accounts.Add(item);
                await _context.SaveChangesAsync();
                return account.Entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Account> Delete(int key)
        {
            try
            {
                var account = _context.Accounts.Find(key) ?? throw new AccountNotFound();

                _context.Accounts.Remove(account);

                await _context.SaveChangesAsync();

                return account;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Account> Get(int key)
        {
            try
            {
                var account = await _context.Accounts.FindAsync(key) ?? throw new AccountNotFound();

                return account;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Account>> Get()
        {
            try
            {
                var accounts = await _context.Accounts.ToListAsync();

                return accounts;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Account> Update(Account item)
        {
            try
            {
                var account = _context.Accounts.Update(item);

                await _context.SaveChangesAsync();

                return account.Entity;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
