using JourneyCoordinatorAPI.DTOs;
using JourneyCoordinatorAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JourneyCoordinatorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetClients()
        {
            var clients = await _clientService.GetClientsAsync();
            return Ok(clients);
        }

        [HttpDelete("{idClient}")]
        public async Task<IActionResult> DeleteClient(int idClient)
        {
            await _clientService.DeleteClientAsync(idClient);
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> CreateClient([FromBody] AssignClientDTO clientDTO)
        {
            var createdClient = await _clientService.CreateClientAsync(clientDTO);
            return CreatedAtAction(nameof(GetClients), new { id = createdClient.FirstName }, createdClient);
        }
    }
}
