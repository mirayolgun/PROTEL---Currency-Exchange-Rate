using PROTEL.Service1.Interfaces;
using PROTELCase.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PROTEL.Application
{
   public class CurrencyServiceApplication : ICurrencyServiceApplication
    {
        private readonly ICurrencyService _currencyService;

        public CurrencyServiceApplication(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        public async Task<CurrencyRate[]> CurrencyServiceAsync()
        {

            return await _currencyService.GetToday();

        }
    }
}
