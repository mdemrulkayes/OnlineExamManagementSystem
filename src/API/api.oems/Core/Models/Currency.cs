using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.oems.Core.Models
{
    public class Currency
    {
        [Key] public int Id { get; set; }

        public string CurrencyName { get; set; }
    }
}
