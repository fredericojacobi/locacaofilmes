using Contracts.Services;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientController : ControllerBase
{
    private readonly IServiceWrapper _service;

    public ClientController(IServiceWrapper service) => _service = service;

    [HttpGet("Consultar")]
    public async Task<IActionResult> GetAsync() => Ok(await _service.Client.Get());
    
    [HttpGet("Consultar/{id}")]
    public async Task<IActionResult> GetAsync([FromRoute] Guid id) => Ok(await _service.Client.Get(id));

    [HttpPost("Cadastrar")]
    public async Task<IActionResult> PostAsync([FromBody] PostClientDto postClientDto) => Ok(await _service.Client.Post(postClientDto));
    
    [HttpPut("Atualizar")]
    public async Task<IActionResult> PutAsync([FromBody] ClientDto clientDto) => Ok(await _service.Client.Put(clientDto));
    
    [HttpDelete("Excluir/{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id) => Ok(await _service.Client.Delete(id));
}