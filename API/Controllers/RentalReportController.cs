using Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RentalReportController : ControllerBase
{
    private readonly IServiceWrapper _service;

    public RentalReportController(IServiceWrapper service) => _service = service;

    [HttpGet("Cliente/Atraso")]
    public async Task<IActionResult> GetOverdueClientsAsync() => Ok(await _service.RentalReport.OverdueClients());
    
    [HttpGet("Cliente/MaisAlugou/{posicao}")]
    public async Task<IActionResult> GetHighestMoviesRentedClientAsync([FromRoute] int posicao) => Ok();
    
    [HttpGet("Filmes/NuncaAlugados")]
    public async Task<IActionResult> GetNeverRentedMoviesAsync() => Ok();

    [HttpGet("Filmes/MaisAlugados/{quantidade}")]
    public async Task<IActionResult> GetMostRentedMoviesLastYearAsync([FromRoute] int quantidade) => Ok();
    
    [HttpGet("Filmes/MenosAlugados/{quantidade}")]
    public async Task<IActionResult> GetLessRentedMoviesLastWeekAsync([FromRoute] int quantidade) => Ok();
}