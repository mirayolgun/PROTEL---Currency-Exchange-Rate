using PROTEL.Service2.Interfaces;
using PROTELCase.Domain.Context;
using PROTELCase.Domain.Models;
using PROTELCase.Domain.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace PROTEL.Service2.Services
{
     public class ExchangeRateChangeService : IExchangeRateService
     {

        private string urlPattr = "https://www.tcmb.gov.tr/kurlar/{0}.xml";
        private readonly WebClient client;
        private readonly IXMLSerializer serializer;
        string curCode = "USD";

        private readonly IDateValidationService _dateValidationService;
        private const int PreviousDay = -1;
        private readonly IDateChangeService _dateChangeService;

        public ExchangeRateChangeService(IDateValidationService dateValidationService, IDateChangeService dateChangeService)
        {
            _dateChangeService = dateChangeService;
            _dateValidationService = dateValidationService;

            client = new WebClient
            {
                Encoding = Encoding.UTF8
            };
            serializer = new XMLSerializer();
        }

        public string GetComparativeDate(string date)
        {
            if (!_dateValidationService.IsValid(date)) return null;

            return _dateChangeService.GetComparativeDateTime(date, PreviousDay);
        }

        public IEnumerable<CurrencyRateItem> GetExchangeRateChanges()
        {
            //examp date
            string date = "2021.09.10";
            var reslt = GetComparativeDate(date);
            if (reslt == null)
                throw new Exception("Hatalı Tarih girdiniz");

            var items = new List<CurrencyRateItem>();

            var url = new Uri(string.Format(urlPattr, "2021" +"09" + "/" + "10" + "09" + "2021"));
            var data = client.DownloadString(url);
            var desiralizr = serializer.Deserializer<Tarih_Date>(data);
            var result = desiralizr.Currency.Select(Map.MapThree).ToArray();
            //var rsf = result.Where(x => x.Currency == curCode).ToArray();

            foreach (var item in result)
            {
                if (item.Currency == curCode && item.Currency != null)
                {
                    using (var context = new PROTELLdbContext())
                    {
                        items.Add(new CurrencyRateItem()
                        {
                            Currency = item.Currency,
                            Date = desiralizr.Tarih,
                            Rate = item.Rate
                         });
                        context.Set<CurrencyRateItem>().Add(item);
                        context.SaveChanges();
                    }

                }

            }
            return items.OrderByDescending(i => i.Rate);
        }
    }
}
