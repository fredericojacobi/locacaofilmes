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
    public async Task<IActionResult> GetOverdueClientsAsync() => Ok(await _service.RentalReport.OverdueClientsAsync());
    
    [HttpGet("Cliente/MaisAlugou/{posicao}")]
    public async Task<IActionResult> GetHighestMoviesRentedClientAsync([FromRoute] int posicao) => Ok(await _service.RentalReport.HighestMoviesRentedClientAsync(posicao));
    
    [HttpGet("Filmes/NuncaAlugados")]
    public async Task<IActionResult> GetNeverRentedMoviesAsync() => Ok(await _service.RentalReport.NeverRentedMoviesAsync());

    [HttpGet("Filmes/MaisAlugados/{quantidade}")]
    public async Task<IActionResult> GetMostRentedMoviesLastYearAsync([FromRoute] int quantidade) => Ok(await _service.RentalReport.MostRentedMoviesLastYearAsync(quantidade));
    
    [HttpGet("Filmes/MenosAlugados/{quantidade}")]
    public async Task<IActionResult> GetLessRentedMoviesLastWeekAsync([FromRoute] int quantidade) => Ok(await _service.RentalReport.LessRentedMoviesLastWeekAsync(quantidade));
}