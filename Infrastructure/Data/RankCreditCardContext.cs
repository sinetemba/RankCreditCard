using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class RankCreditCardContext : DbContext
    {
        public RankCreditCardContext(DbContextOptions<RankCreditCardContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<CreditCard> CreditCards { get; set; }
    }
}
