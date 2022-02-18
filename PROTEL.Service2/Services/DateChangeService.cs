using PROTEL.Service2.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PROTEL.Service2.Services
{
    public class DateChangeService : IDateChangeService
    {
        public string GetComparativeDateTime(string date, int day)
        {
            var dateTime = Convert.ToDateTime(date);
            return $"{dateTime.AddDays(day):yyyy.MM.dd}";
        }

    }
}
