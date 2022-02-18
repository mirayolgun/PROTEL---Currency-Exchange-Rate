using PROTEL.Application;
using PROTEL.Service2.Interfaces;
using PROTEL.Service2.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;


namespace PROTEL.Test
{
    public class ExchangeRateTest
    {
        private readonly IExchangeRateApplication exchangeRateApplication;
        private readonly IExchangeRateService _exchangeRateService;
        public ExchangeRateTest(IExchangeRateService exchangeRateService)
        {
            exchangeRateApplication = new ExchangeRateApplication(_exchangeRateService);
        }

        [Fact]
        public async void Get_ExchangeRate() 
        {
            var result = await exchangeRateApplication.GetExchangeRatesAsync();
            Assert.True(result != null);

        }
    }
}
