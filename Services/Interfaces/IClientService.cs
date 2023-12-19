using JourneyCoordinatorAPI.DTOs;

namespace JourneyCoordinatorAPI.Repository.Interfaces
{
    public interface IClientService
    {
        Task<List<ClientDTO>> GetClientsAsync();
        Task DeleteClientAsync(int idClient);
        Task<ClientDTO> CreateClientAsync(AssignClientDTO clientDTO);
    }
}
