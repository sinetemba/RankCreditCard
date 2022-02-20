using Core.Interfaces;
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
    public class CreditCardInfoValidator : AbstractValidator<CreditCardViewModel>
    {
        private readonly ICreditCardRepository _creditCardRepository;
        public CreditCardInfoValidator(ICreditCardRepository creditCardRepository)
        {
            _creditCardRepository = creditCardRepository;

            RuleFor(x => x.CardHolderName).NotEmpty().WithMessage("The name on the card");
            RuleFor(x => x.CardNumber).CustomAsync(IsCardNumberValid).NotEmpty();
            RuleFor(x => x.CCVNumber).NotEmpty().WithMessage("Please enter ccv pin");
            RuleFor(x => x.ExpiryYear).InclusiveBetween(2022, 2027).NotEmpty().WithMessage("Please select Expiry year");
            RuleFor(x => x.ExpiryMonth).InclusiveBetween(1, 12).NotEmpty().WithMessage("Please select Expiry month");
        }

        private async Task IsCardNumberValid(string creditCardNumber, ValidationContext<CreditCardViewModel> creditCardContext, CancellationToken cancellationToken)
        {

            //var creditCardExist = await _context.CreditCards.FirstOrDefaultAsync(c => c.CardNumber == creditCardNumber);

            var creditCardExist = await _creditCardRepository.CheckIfAccountNumberExist(creditCardNumber);

            if (creditCardExist)
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
