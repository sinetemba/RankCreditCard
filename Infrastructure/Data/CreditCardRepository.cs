using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class CreditCardRepository : ICreditCardRepository
    {
        private readonly RankCreditCardContext _dbContext;

        public CreditCardRepository(RankCreditCardContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddNewCreditCard(CreditCard creditCard)
        {
            _dbContext.CreditCards.Add(creditCard);
            _dbContext.SaveChanges();
        }

        public async Task<bool> CheckIfAccountNumberExist(string accountNumber)
        {
            var account = await _dbContext.CreditCards.FirstOrDefaultAsync(x => x.CardNumber == accountNumber);

            if (account != null) return true;

            return false;
        }

        public async Task<CreditCard> GetCreditCardByIdAsync(int id)
        {
            return await _dbContext.CreditCards.FindAsync(id);
        }

        public async Task<List<CreditCard>> GetCreditCardsAsync()
        {
            return await _dbContext.CreditCards.ToListAsync();
        }

        public void RemoveCreditCard(CreditCard creditCard)
        {
            _dbContext.CreditCards.Remove(creditCard);
            _dbContext.SaveChanges();
        }
    }
}
