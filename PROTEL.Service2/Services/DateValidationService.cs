using PROTEL.Service2.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PROTEL.Service2.Services
{
   public class DateValidationService : IDateValidationService
    {
        private readonly DateTime _minDate = new DateTime(2019, 6, 25);
        private readonly DateTime _maxDate = new DateTime(2022, 01, 02);

        public bool IsValid(string date)
        {
            var dateTime = Convert.ToDateTime(date);

            return dateTime < _maxDate && dateTime > _minDate;
        }

    }
}
