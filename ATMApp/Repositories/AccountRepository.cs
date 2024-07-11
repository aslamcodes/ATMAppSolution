using ATMApp.Interfaces;
using ATMApp.Models;

namespace ATMApp.Repositories
{
    public class AccountRepository : IRepository<int, Account>
    {
        public Task<Account> Add(Account item)
        {
            throw new NotImplementedException();
        }

        public Task<Account> Delete(int key)
        {
            throw new NotImplementedException();
        }

        public Task<Account> Get(int key)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Account>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<Account> Update(Account item)
        {
            throw new NotImplementedException();
        }
    }
}
