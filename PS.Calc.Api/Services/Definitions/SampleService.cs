using AutoMapper;
using PS.Calc.Api.Auth;
using PS.Calc.Api.Services.Interfaces;
using PS.Calc.Data;
using PS.Calc.Data.DbModels;

namespace PS.Calc.Api.Services.Definitions
{
    public class SampleService : ServiceBase, ISampleService
    {
        public SampleService(IRepository repository, ILogger<SampleService> logger, IConfiguration config, IMapper mapper) : base(repository, logger, config, mapper)
        {
        }
        public async Task<List<IdentityVM>> GetUsers()
        {
            List<IdentityVM> users = new List<IdentityVM>();
            var empList = await Repository.GetAllAsync<Employee>();
            Mapper.Map(empList, users);
            return users;
        }
    }
}
