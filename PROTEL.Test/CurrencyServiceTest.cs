using PROTEL.Service1.Interfaces;
using PROTEL.Service1.Services;
using System;
using Xunit;

namespace PROTEL.Test
{
    public class CurrencyServiceTest
    {
        private readonly ICurrencyService service;

        public CurrencyServiceTest()
        {
            service = new CurrencyService();
        }

        [Fact]
        public async void Get_Today()
        {
            var result = await service.GetToday();
            Assert.True(result.Length > 0);
        }

        [Fact]
        public async void Get_Currencies_By_Date()
        {
            var result = await service.GetByDate(new DateTime(2020, 9, 8));
            Assert.True(result.Length > 0);
        }

    }
}
