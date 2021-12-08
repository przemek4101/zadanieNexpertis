using System;
using System.Threading.Tasks;
using zadanieNexpertis.Entities;
using zadanieNexpertis.ModelsResult;

namespace zadanieNexpertis.Services
{
    public interface ICurrenciesService
    {
        public Task<CurrencyDataResult> GetDataCurrenciesAsync(string currency);
    }
}
