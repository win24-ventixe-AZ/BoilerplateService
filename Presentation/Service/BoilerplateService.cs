using Presentation.Data.Entities;
using Presentation.Data.Repositories;
using Presentation.Models;

namespace Presentation.Service;

public class BoilerplateService(IBoilerplateRepository boilerplateRepository) : IBoilerplateService
{
    private readonly IBoilerplateRepository _boilerplateRepository = boilerplateRepository;

    public async Task<BoilerplateResult> CreateBoilerplateAsync(CreateBoilerplateRequest request)
    {
        var boilerplateEntity = new BoilerplateEntity
        {
            BoilerplateType = request.BoilerplateType!,
            BoilerplateContent = request.BoilerplateContent!,
            CreatedAt = DateTime.UtcNow
        };

        var result = await _boilerplateRepository.AddAsync(boilerplateEntity);
        return result.Success
                            ? new BoilerplateResult { Success = true }
                            : new BoilerplateResult { Success = false, Error = result.Error };
    }



    public async Task<BoilerplateResult<Boilerplate?>> GetBoilerplateByTypeAsync(string type) // Why would you ever get it by Id?
    {
        var result = await _boilerplateRepository.GetAsync(x => x.BoilerplateType == type);
        if (result.Success && result.Result != null)
        {
            var currentBoilerplate = new Boilerplate
            {
                Id = result.Result.Id,
                BoilerplateType = result.Result.BoilerplateType,
                BoilerplateContent = result.Result.BoilerplateContent,
                CreatedAt = result.Result.CreatedAt
            };

            return new BoilerplateResult<Boilerplate?>{ Success = true, Result = currentBoilerplate };
        }
        return new BoilerplateResult<Boilerplate?> { Success = false, Error = "Boilerplate text not found." };

    }


    public async Task<BoilerplateResult<IEnumerable<Boilerplate>>> GetAllBoilerplatesAsync()
    {
        var results = await _boilerplateRepository.GetAllAsync();
        var boilerplates = results.Result?.Select(x => new Boilerplate
        {
            Id = x.Id,
            BoilerplateType = x.BoilerplateType,
            BoilerplateContent = x.BoilerplateContent,
            CreatedAt = x.CreatedAt
        });

        return new BoilerplateResult<IEnumerable<Boilerplate>>{ Success = results.Success, Result = boilerplates };
    }

}
