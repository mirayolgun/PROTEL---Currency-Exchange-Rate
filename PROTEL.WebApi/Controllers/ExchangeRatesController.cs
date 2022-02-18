using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PROTEL.Service1.Interfaces;
using PROTEL.Service2.Interfaces;
using PROTELCase.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROTEL.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeRatesController : ControllerBase
    {
        private readonly IExchangeRateApplication _exchangeRateApplication;
        private readonly ICurrencyServiceApplication _currencyServiceApplication;

        public ExchangeRatesController(IExchangeRateApplication exchangeRateApplication, ICurrencyServiceApplication currencyServiceApplication)
        {
            _exchangeRateApplication = exchangeRateApplication;
            _currencyServiceApplication = currencyServiceApplication;
        }

        [HttpGet]
        [Route("GetService1")]
        public async Task<CurrencyRate[]> GetService1()
        {

            return await _currencyServiceApplication.CurrencyServiceAsync();
        }

        [HttpGet]
        [Route("GetService2")]
        public async Task<IEnumerable<CurrencyRateItem>> GetExchangeRatesAsync()
        {
            return await _exchangeRateApplication.GetExchangeRatesAsync();

        }
    }
}
