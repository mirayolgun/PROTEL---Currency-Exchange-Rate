using System;
using System.Collections.Generic;
using System.Text;

namespace PROTELCase.Domain.Models
{
    public class CurrencyRateItem
    {
        public int Id { get; set; }
        public string Currency { get; set; }
        public string Date { get; set; }
        public decimal Rate { get; set; }
        public decimal Changes { get; set; }
    }
}
