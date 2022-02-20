using CreditCardValidator;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using RankCreditCard.Interfaces;
using RankCreditCard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RankCreditCard.Validators
{
    public class CreditCardInfoValidator : AbstractValidator<CreditCard>
    {
        private readonly IRankCreditCardContext _context;
        public CreditCardInfoValidator(IRankCreditCardContext context)
        {
            _context = context;

            RuleFor(x => x.CardHolderName).NotEmpty();
            RuleFor(x => x.CardNumber).CustomAsync(IsCardNumberValid).NotEmpty();
            RuleFor(x => x.CCVNumber).NotEmpty();
            RuleFor(x => x.ExpiryYear).NotEmpty();
            RuleFor(x => x.ExpiryMonth).InclusiveBetween(1, 12).NotEmpty();
        }

        private async Task IsCardNumberValid(string creditCardNumber, ValidationContext<CreditCard> creditCardContext, CancellationToken cancellationToken)
        {

            var creditCardExist = await _context.CreditCards.FirstOrDefaultAsync(c => c.CardNumber == creditCardNumber);
            
            if (creditCardExist != null)
            {
                creditCardContext.AddFailure("CardNumber", "The credit card number provided is already exist please provide a new number");
            }

            var cc = new CreditCardDetector(creditCardNumber);
            var isValid = cc.IsValid();
            if (!isValid)
            {
                creditCardContext.AddFailure("CardNumber", "The credit card number provided is not valid");
            }
                       
        }

       
    }
}
