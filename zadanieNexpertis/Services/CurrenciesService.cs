using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using zadanieNexpertis.Entities;
using zadanieNexpertis.Exceptions;
using zadanieNexpertis.ModelsDto;
using zadanieNexpertis.ModelsResult;

namespace zadanieNexpertis.Services
{
    public class CurrenciesService : ICurrenciesService 
    {
        private readonly NexpertisAppDbContext _dbContext;
        public CurrenciesService(NexpertisAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CurrencyDataResult> GetDataCurrenciesAsync(string currency)
        {
            if(await _dbContext.Set<CurrencyData>().AnyAsync(x => (x.Currency == currency || x.Code == currency) 
            && x.UpdatedAt.Year == DateTime.Today.Year && x.UpdatedAt.DayOfYear == DateTime.Today.DayOfYear))
            {
                var  currencyData = await _dbContext.Set<CurrencyData>().FirstAsync(x => (x.Currency == currency || x.Code == currency) 
                && x.UpdatedAt.Year == DateTime.Today.Year && x.UpdatedAt.DayOfYear == DateTime.Today.DayOfYear);
                var currencyDataResult = new CurrencyDataResult(currencyData);
                return currencyDataResult;
                
            }
            else
            {
                var client = new RestClient("http://api.nbp.pl/");
                var requestCurrency = new RestRequest($"api/exchangerates/rates/a/{currency}/{DateTime.Today.ToString("yyyy-MM-dd")}/?format=json", Method.GET);
                var clientResponse = await client.ExecuteAsync(requestCurrency);
                if(clientResponse.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new NotFoundException("404 NotFound");
                }
                if (clientResponse.StatusCode == HttpStatusCode.BadRequest)
                {
                    throw new BadRequestException("400 BadRequest");
                }
                var responseCurrency = JsonConvert.DeserializeObject<CurrencyDataDto>(clientResponse.Content);

                var currencyData = await _dbContext.Set<CurrencyData>().FirstOrDefaultAsync(x => x.Currency == currency);

                if (currencyData == null)
                {
                    currencyData = new CurrencyData(responseCurrency);
                    await _dbContext.AddAsync(currencyData);
                }

                currencyData.Update(responseCurrency.Rates.First().Mid);
                await _dbContext.SaveChangesAsync();
                var currencyDataResult = new CurrencyDataResult(currencyData);
                
                return currencyDataResult;
            }
        }
    }
}
