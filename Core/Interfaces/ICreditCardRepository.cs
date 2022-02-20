using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ICreditCardRepository
    {
        void AddNewCreditCard(CreditCard creditCard);
        Task<bool> CheckIfAccountNumberExist(string accountNumber);
        Task<CreditCard> GetCreditCardByIdAsync(int id);
        Task<List<CreditCard>> GetCreditCardsAsync();
        void RemoveCreditCard(CreditCard creditCard);

    }
}
