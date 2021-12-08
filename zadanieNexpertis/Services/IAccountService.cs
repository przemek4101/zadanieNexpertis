using System.Threading.Tasks;
using zadanieNexpertis.ModelsDto;

namespace zadanieNexpertis.Services
{
    public interface IAccountService
    {
        public Task<string> GenerateJwtAsync(LoginDto dto);
    }
}
