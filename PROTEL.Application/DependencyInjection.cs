using Microsoft.Extensions.DependencyInjection;
using PROTEL.Service1.Interfaces;
using PROTEL.Service1.Services;
using PROTEL.Service2.Interfaces;
using PROTEL.Service2.Services;
using PROTELCase.Domain.Serializer;
using System;
using System.Collections.Generic;
using System.Text;

namespace PROTEL.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddScoped<ICurrencyService, CurrencyService>();
            services.AddScoped<IDateChangeService, DateChangeService>();
            services.AddScoped<IDateValidationService, DateValidationService>();
            services.AddScoped<IExchangeRateApplication, ExchangeRateApplication>();
            services.AddScoped<ICurrencyServiceApplication, CurrencyServiceApplication>();
            services.AddScoped<IExchangeRateService, ExchangeRateChangeService>();

            services.AddScoped<IXMLSerializer, XMLSerializer>();

            return services;
        }
    }
}
