using CreditCardValidator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Helpers
{
   public static class CreditCardValidatorExtension
    {
        public static CardIssuer GetCreditCardBrand(this string cardNumber)
        {
            return new CreditCardDetector(cardNumber).Brand;
        }

        public static string GetCreditCardProviderName(this string cardNumber)
        {
            return new CreditCardDetector(cardNumber).Brand.ToString();
        }

        public static string GetCreditCardBrandName(this string cardNumber)
        {
            return new CreditCardDetector(cardNumber).BrandName;
        }

        public static bool IsValidCrediCard(this string cardNumber)
        {
            return new CreditCardDetector(cardNumber).IsValid();
        }

        public static bool IsValidCreditCardBrand(this string cardNumber, params CardIssuer[] issuers)
        {
            return new CreditCardDetector(cardNumber).IsValid(issuers);
        }
    }
}
