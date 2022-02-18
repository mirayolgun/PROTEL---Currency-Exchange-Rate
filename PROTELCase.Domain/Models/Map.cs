using System;
using System.Collections.Generic;
using System.Text;

namespace PROTELCase.Domain.Models
{
   public class Map
   {
        public static CurrencyRate MapOne(Tarih_DateCurrency x)
        {
            return new CurrencyRate
            {
                Currency = x.Kod,
                Rate = x.ForexBuying,
            };

        }

        public static CurrencyRate MapTwo(Tarih_Date y)
        {
            return new CurrencyRate
            {
                Date = y.Tarih
            };

        }

        public static CurrencyRateItem MapThree(Tarih_DateCurrency x)
        {
            return new CurrencyRateItem
            {
                Currency = x.Kod,
                Rate = x.ForexBuying,
            };

        }




    }
}
