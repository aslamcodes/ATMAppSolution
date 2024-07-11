using ATMApp.Interfaces;
using ATMApp.Models;

namespace ATMApp.Repositories
{
    public class CardRepository : IRepository<int, Card>
    {
        public Task<Card> Add(Card item)
        {
            throw new NotImplementedException();
        }

        public Task<Card> Delete(int key)
        {
            throw new NotImplementedException();
        }

        public Task<Card> Get(int key)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Card>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<Card> Update(Card item)
        {
            throw new NotImplementedException();
        }
    }
}
