using System;
using System.Linq;
using zadanieNexpertis.ModelsDto;
using zadanieNexpertis.ModelsResult;

namespace zadanieNexpertis.Entities
{
    public class CurrencyData
    {
        public int Id { get; set; }
        public string Currency { get; set; }
        public string Code { get; set; }
        public float Mid { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
       

        public void Update(float mid)
        {
            Mid = mid;
            UpdatedAt = DateTime.UtcNow;
        }

        public CurrencyData()
        {

        }

        public CurrencyData(CurrencyDataDto dto)
        {
            Currency = dto.Currency;
            Code = dto.Code;
            Mid = dto.Rates.First().Mid;
        }
    }
}
