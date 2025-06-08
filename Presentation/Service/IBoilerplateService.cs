using Presentation.Models;

namespace Presentation.Service
{
    public interface IBoilerplateService
    {
        Task<BoilerplateResult> CreateBoilerplateAsync(CreateBoilerplateRequest request);
        Task<BoilerplateResult<IEnumerable<Boilerplate>>> GetAllBoilerplatesAsync();
        Task<BoilerplateResult<Boilerplate?>> GetBoilerplateByTypeAsync(string type);
    }
}