using Contracts.Services;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RentalController : ControllerBase
{
    private readonly IServiceWrapper _service;

    public RentalController(IServiceWrapper service) => _service = service;

    [HttpGet("Consultar")]
    public async Task<IActionResult> GetAsync() => Ok(await _service.Rental.GetAsync());

    [HttpGet("Consultar/{id}")]
    public async Task<IActionResult> GetAsync([FromRoute] Guid id) => Ok(await _service.Rental.GetAsync(id));

    [HttpGet("new")]
    public async Task<IActionResult> GetNewPageAsync() => Ok(await _service.Rental.GetNewPageAsync());

    [HttpPost("Cadastrar")]
    public async Task<IActionResult> PostAsync([FromBody] PostRentalDto postRentalDto) => Ok(await _service.Rental.PostAsync(postRentalDto));

    [HttpPut("Atualizar")]
    public async Task<IActionResult> PutAsync([FromBody] PostRentalDto rentalDto) => Ok(await _service.Rental.PutAsync(rentalDto));

    [HttpDelete("Excluir/{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id) => Ok(await _service.Rental.DeleteAsync(id));
}