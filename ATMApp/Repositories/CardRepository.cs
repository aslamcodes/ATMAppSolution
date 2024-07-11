using ATMApp.Contexts;
using ATMApp.Exceptions.Card;
using ATMApp.Interfaces;
using ATMApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ATMApp.Repositories
{
    public class CardRepository : IRepository<int, Card>
    {
        private readonly ATMContext _context;
        public CardRepository(ATMContext context)
        {
            _context = context;
        }
        public async Task<Card> Add(Card item)
        {
            try
            {
                var card = _context.Cards.Add(item);
                await _context.SaveChangesAsync();
                return card.Entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Card> Delete(int key)
        {
            try
            {
                var card = _context.Cards.Find(key) ?? throw new CardNotFound();

                _context.Cards.Remove(card);

                await _context.SaveChangesAsync();

                return card;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<Card> Get(int key)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Card>> Get()
        {
            try
            {
                var cards = await _context.Cards.ToListAsync();

                return cards;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Card> Update(Card item)
        {
            try
            {
                var card = _context.Cards.Update(item);

                await _context.SaveChangesAsync();

                return card.Entity;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
