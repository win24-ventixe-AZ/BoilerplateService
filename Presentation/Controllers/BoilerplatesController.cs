using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;
using Presentation.Service;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoilerplatesController(IBoilerplateService boilerplateService) : ControllerBase
    {
        private readonly IBoilerplateService _boilerplateService = boilerplateService;

        [HttpGet("{type}")]
        public async Task<IActionResult> Get(string type)
        {
            var boilerplate = await _boilerplateService.GetBoilerplateByTypeAsync(type);
            return boilerplate.Success && boilerplate.Result != null 
                ? Ok(boilerplate.Result)
                : NotFound(boilerplate.Error ?? "Boilerplate Text not found.");
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var boilerplates = await _boilerplateService.GetAllBoilerplatesAsync();
            return boilerplates.Success && boilerplates.Result != null
                ? Ok(boilerplates.Result)
                : NotFound(boilerplates.Error ?? "No boilerplates found.");
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBoilerplateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _boilerplateService.CreateBoilerplateAsync(request);
            return result.Success ? Ok(result) : StatusCode(500, result!.Error);
        }

    }
}
