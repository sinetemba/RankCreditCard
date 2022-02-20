using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using RankCreditCard.Models;

namespace RankCreditCard.Interfaces
{
   public interface IRankCreditCardContext
    {
        DbSet<CreditCard> CreditCards { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
