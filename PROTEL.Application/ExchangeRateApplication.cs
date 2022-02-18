using PROTEL.Service2.Interfaces;
using PROTELCase.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PROTEL.Application
{
    public class ExchangeRateApplication : IExchangeRateApplication
    {
        private readonly IExchangeRateService _exchangeRateService;
        public ExchangeRateApplication(IExchangeRateService exchangeRateService)
        {
            _exchangeRateService = exchangeRateService;
        }

        public async Task<IEnumerable<CurrencyRateItem>> GetExchangeRatesAsync()
        {
            return _exchangeRateService.GetExchangeRateChanges();
        }

    }
}
