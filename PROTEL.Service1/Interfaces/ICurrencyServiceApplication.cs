using PROTELCase.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PROTEL.Service1.Interfaces
{
   public interface ICurrencyServiceApplication
    {

        Task<CurrencyRate[]> CurrencyServiceAsync();

    }
}
