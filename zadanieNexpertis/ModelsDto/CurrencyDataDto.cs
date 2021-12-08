using System.Collections.Generic;

namespace zadanieNexpertis.ModelsDto
{
    public class CurrencyDataDto
    {
        public string Currency { get; set; }
        public string Code { get; set; }
        public ICollection<Rate> Rates { get; set; }

        public class Rate
        {
            public float Mid { get; set; }
        }
    }
}
