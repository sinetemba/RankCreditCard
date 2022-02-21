using Core.Interfaces;
using CreditCardValidator;
using FluentValidation;
using Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RankCreditCard.Helpers;
using RankCreditCard.Interfaces;
using RankCreditCard.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RankCreditCard.Validators
{
    public class CreditCardInfoValidator : AbstractValidator<CreditCardViewModel>
    {
        private readonly ICreditCardRepository _creditCardRepository;      
        public CreditCardInfoValidator(ICreditCardRepository creditCardRepository, IConfiguration configuration)
        {
            _creditCardRepository = creditCardRepository;           

            RuleFor(x => x.CardHolderName).NotEmpty().WithMessage("Please provide the name on the card.");
            RuleFor(x => x.CardNumber).CustomAsync(IsCardNumberValid).NotEmpty().DependentRules(() =>
            {
                RuleFor(x => x.CardNumber).Custom(IsProviderAllowed);             
            });
            RuleFor(x => x.CCVNumber).NotEmpty().WithMessage("Please provide ccv pin").InclusiveBetween(100, 9999).WithMessage("Please provide a valid ccv number");
            RuleFor(x => x.ExpiryYear).InclusiveBetween(2022, 2027).WithMessage("Please select Expiry year").NotEmpty();
            RuleFor(x => x.ExpiryMonth).InclusiveBetween(1, 12).WithMessage("Please select Expiry month").NotEmpty();
           
        }

        private async Task IsCardNumberValid(string creditCardNumber, ValidationContext<CreditCardViewModel> creditCardContext, CancellationToken cancellationToken)
        {      

            var creditCardExist = await _creditCardRepository.CheckIfAccountNumberExist(creditCardNumber.RemoveWhiteSpaces().Encrypt());

            if (creditCardExist)
            {
                creditCardContext.AddFailure("CardNumber", "The credit card number provided is already exist please provide a new number");
            }

            var isValid = creditCardNumber.IsValidCrediCard();
            if (!isValid)
            {
                creditCardContext.AddFailure("CardNumber", "The credit card number provided is not valid");
            }                       
        }

        private void IsProviderAllowed(string cardNumber, ValidationContext<CreditCardViewModel> creditCardContext)
        {

            var provider = cardNumber.RemoveWhiteSpaces().GetCreditCardProviderName();

            IConfigurationRoot _config = new ConfigurationBuilder()
              .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
              .AddJsonFile("appsettings.json", false)
              .Build();

            List<string> allowedProviders = _config.GetSection("AllowedCards:Providers").Get<List<string>>();
            if (!allowedProviders.Contains(provider))
            {
                creditCardContext.AddFailure($"The provider: {provider}, is not configured to be captured. only {string.Join(", ", allowedProviders)} can be captured");
            }
        }



    }
}
