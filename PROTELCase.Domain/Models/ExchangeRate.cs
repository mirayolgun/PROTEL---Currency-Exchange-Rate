using System;
using System.Collections.Generic;
using System.Text;

namespace PROTELCase.Domain.Models
{
   public class ExchangeRate
   {
        public List<CurrencyRateItem> Items { get; set; } = new List<CurrencyRateItem>();
    }
}
