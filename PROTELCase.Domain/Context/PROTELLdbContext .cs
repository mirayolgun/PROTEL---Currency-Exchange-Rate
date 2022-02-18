using Microsoft.EntityFrameworkCore;
using PROTELCase.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PROTELCase.Domain.Context
{
   public class PROTELLdbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.\\SQLEXPRESS; database=PROTELLdb; integrated security=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public DbSet<CurrencyRate> currencyRates { get; set; }

        public DbSet<CurrencyRateItem> currencyRateItems { get; set; }
    }
}
