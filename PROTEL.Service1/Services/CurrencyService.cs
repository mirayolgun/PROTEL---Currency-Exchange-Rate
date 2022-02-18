using PROTEL.Service1.Interfaces;
using PROTELCase.Domain.Models;
using PROTELCase.Domain.Context;
using PROTELCase.Domain.Serializer;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PROTEL.Service1.Services
{
    public class CurrencyService : ICurrencyService
    {
        private string urlPattr = "https://www.tcmb.gov.tr/kurlar/{0}.xml";
        private readonly WebClient client;
        private readonly IXMLSerializer serializer;
        string [] s = { "USD", "EUR", "GBP", "CHF", "KWD", "SAR", "RUB" };
        public CurrencyService()
        {
            client = new WebClient
            {
                Encoding = Encoding.UTF8
            };
            serializer = new XMLSerializer();
        }

        public Task<CurrencyRate[]> GetToday()
        {
            var url = new Uri(string.Format(urlPattr, "today"));
            var data = client.DownloadString(url);
            var desiralizr = serializer.Deserializer<Tarih_Date>(data);
            var result = desiralizr.Currency.Select(Map.MapOne).ToArray();
            var rsf = result.Where(x => s.Any(y => y == x.Currency)).ToArray();

            using (var context = new PROTELLdbContext())
            {
                foreach (var item in rsf)
                {
                  item.Date = desiralizr.Tarih;
                
                  context.Set<CurrencyRate>().Add(item);
                  context.SaveChanges();
               }
            }

            rsf.ToArray().OrderByDescending(i => i.Rate);
            return Task.FromResult(rsf);
        }

        public Task<CurrencyRate[]> GetByDate(DateTime date)
        {
            var day = date.Day > 0 && date.Day < 10 ? $"0{date.Day}" : date.Day.ToString();
            var month = date.Month > 0 && date.Month < 10 ? $"0{date.Month}" : date.Month.ToString();
            var url = new Uri(string.Format(urlPattr, $"{date.Year}{month}/{day}{month}{date.Year}"));
            var data = client.DownloadString(url);
            var desiralizr = serializer.Deserializer<Tarih_Date>(data);
            var result = desiralizr.Currency.Select(Map.MapOne).ToArray();
            var rsf = result.Where(x => s.Any(y => y == x.Currency)).ToArray();

            return Task.FromResult(rsf.ToArray());

        }
    }
}
