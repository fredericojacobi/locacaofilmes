using Contracts.Services;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MovieController : ControllerBase
{
    private readonly IServiceWrapper _service;

    public MovieController(IServiceWrapper service) => _service = service;

    [HttpGet("Consultar")]
    public async Task<IActionResult> GetAsync([FromQuery] string? title) => Ok(await _service.Movie.GetAsync(title));

    [HttpGet("Consultar/{id}")]
    public async Task<IActionResult> GetAsync([FromRoute] Guid id) => Ok(await _service.Movie.GetByIdAsync(id));

    [HttpPost("Cadastrar")]
    public async Task<IActionResult> PostAsync([FromBody] PostMovieDto postMovieDto) => Ok(await _service.Movie.PostAsync(postMovieDto));

    [HttpPut("Atualizar")]
    public async Task<IActionResult> PutAsync([FromBody] MovieDto movieDto) => Ok(await _service.Movie.PutAsync(movieDto));

    [HttpDelete("Excluir/{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id) => Ok(await _service.Movie.DeleteAsync(id));
}