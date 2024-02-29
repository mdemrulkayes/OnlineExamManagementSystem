using System.ComponentModel.DataAnnotations;

namespace api.oems.Core.Models
{
    public class Currency
    {
        [Key] public int Id { get; set; }

        public string CurrencyName { get; set; }
    }
}
