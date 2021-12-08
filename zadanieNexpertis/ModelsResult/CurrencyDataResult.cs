using System.Collections.Generic;
using zadanieNexpertis.Entities;
using zadanieNexpertis.ModelsDto;

namespace zadanieNexpertis.ModelsResult
{
    public class CurrencyDataResult
    {
            public string Currency { get; set; }
            public string Code { get; set; }
            public float Mid { get; set; }
            public CurrencyDataResult(CurrencyData currencyData)
            {
                Currency = currencyData.Currency;
                Code = currencyData.Code;
                Mid = currencyData.Mid;
            }
        }
    }

