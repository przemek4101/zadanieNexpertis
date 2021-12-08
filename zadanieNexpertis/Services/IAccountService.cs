using zadanieNexpertis.ModelsDto;

namespace zadanieNexpertis.Services
{
    public interface IAccountService
    {
        public string GenerateJwt(LoginDto dto);
    }
}
