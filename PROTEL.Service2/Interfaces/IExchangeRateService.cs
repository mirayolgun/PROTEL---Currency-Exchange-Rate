using PROTELCase.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PROTEL.Service2.Interfaces
{
   public interface IExchangeRateService
   {
        public string GetComparativeDate(string date);
        public IEnumerable<CurrencyRateItem> GetExchangeRateChanges();
    }
}
