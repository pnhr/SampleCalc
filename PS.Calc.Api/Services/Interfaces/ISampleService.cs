using PS.Calc.Api.Auth;

namespace PS.Calc.Api.Services.Interfaces
{
    public interface ISampleService
    {
        Task<List<IdentityVM>> GetUsers();
    }
}
