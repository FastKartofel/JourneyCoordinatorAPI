using JourneyCoordinatorAPI.DTOs;
using JourneyCoordinatorAPI.Models;
using JourneyCoordinatorAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JourneyCoordinatorAPI.Services.Implementation
{
    public class ClientService : IClientService
    {
        private readonly JuorneyCoordinatorApiContext _context;

        public ClientService(JuorneyCoordinatorApiContext context) 
        {
            _context = context;
        }

        public async Task<List<ClientDTO>> GetClientsAsync()
        {
            var clients = await _context.Clients.ToListAsync();
            return clients.Select(c => new ClientDTO
            {
                FirstName = c.FirstName,
                LastName = c.LastName,
            }).ToList();
        }


        //for some reason can't delete users that have been uplaoded before the scaffolding
        public async Task DeleteClientAsync(int idClient)
        {
            var client = await _context.Clients.FindAsync(idClient);
            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
        }

        public async Task<ClientDTO> CreateClientAsync(AssignClientDTO clientDTO)
        {
            var client = new Client
            {
                FirstName = clientDTO.FirstName,
                LastName = clientDTO.LastName,
                Email = clientDTO.Email,
                Telephone = clientDTO.Telephone,
                Pesel = clientDTO.Pesel
            };
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();

            return new ClientDTO
            {
                FirstName = client.FirstName,
                LastName = client.LastName
            };
        }
    }
}
