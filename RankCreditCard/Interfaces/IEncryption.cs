using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RankCreditCard.Interfaces
{
   public interface IEncryption
    {
       string Encrypt(string plainText);
       string Dencrypt(string base64EncodedData);
    }
}
