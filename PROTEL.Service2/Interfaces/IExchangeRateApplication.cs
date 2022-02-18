using PROTELCase.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PROTEL.Service2.Interfaces
{
    public interface IExchangeRateApplication
    {
        public Task<IEnumerable<CurrencyRateItem>> GetExchangeRatesAsync();
    }
}
