using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RankCreditCard.Helpers
{
    public static class StringHelper
    {
        public static string RemoveWhiteSpaces(this string input)
        {
            input = input.Replace(" ", String.Empty);
            return input;
        }
    }
}
