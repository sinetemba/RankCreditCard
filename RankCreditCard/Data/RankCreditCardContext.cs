using Microsoft.EntityFrameworkCore;
using RankCreditCard.Interfaces;
using RankCreditCard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RankCreditCard.Data
{
    public class RankCreditCardContext : DbContext, IRankCreditCardContext
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
