using JourneyCoordinatorAPI.DTOs;
using JourneyCoordinatorAPI.Models;
using JourneyCoordinatorAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JourneyCoordinatorAPI.Services.Implementation
{
    public class TripService : ITripService
    {
        private readonly JuorneyCoordinatorApiContext _context;

        public TripService(JuorneyCoordinatorApiContext context) 
        {
            _context = context;
        }

        public async Task<IEnumerable<TripDTO>> GetAllTripsAsync()
        {
            var trips = await _context.Trips
                .Include(t => t.IdCountries) 
                .Include(t => t.ClientTrips) 
                    .ThenInclude(ct => ct.IdClientNavigation)
                .OrderByDescending(t => t.DateTo)
                .ToListAsync();

            var tripDTOs = trips.Select(t => new TripDTO
            {
                Name = t.Name,
                Description = t.Description,
                DateFrom = t.DateFrom,
                DateTo = t.DateTo,
                MaxPeople = t.MaxPeople,
                Countries = t.IdCountries.Select(c => new CountryDTO { Name = c.Name }).ToList(),
                Clients = t.ClientTrips.Select(ct => new ClientDTO
                {
                    FirstName = ct.IdClientNavigation.FirstName,
                    LastName = ct.IdClientNavigation.LastName
                }).ToList()
            }).ToList();

            return tripDTOs;
        }

        public async Task<TripDTO> GetTripByIdAsync(int idTrip)
        {
            var trip = await _context.Trips
                .Include(t => t.IdCountries)
                .Include(t => t.ClientTrips).ThenInclude(ct => ct.IdClientNavigation)
                .FirstOrDefaultAsync(t => t.IdTrip == idTrip);

            if (trip == null) return null;

            return new TripDTO
            {
                Name = trip.Name,
                Description = trip.Description,
                DateFrom = trip.DateFrom,
                DateTo = trip.DateTo,
                MaxPeople = trip.MaxPeople,
                Countries = trip.IdCountries.Select(c => new CountryDTO { Name = c.Name }).ToList(),
                Clients = trip.ClientTrips.Select(ct => new ClientDTO
                {
                    FirstName = ct.IdClientNavigation.FirstName,
                    LastName = ct.IdClientNavigation.LastName
                }).ToList()
            };
        }

        public async Task<TripDTO> AssignClientToTripAsync(int idTrip, AssignClientDTO clientDTO)
        {
            var trip = await _context.Trips
                .Include(t => t.IdCountries)
                .Include(t => t.ClientTrips).ThenInclude(ct => ct.IdClientNavigation)
                .FirstOrDefaultAsync(t => t.IdTrip == idTrip);

            if (trip == null)
            {
                throw new KeyNotFoundException("Trip not found.");
            }

            var client = await _context.Clients.FirstOrDefaultAsync(c => c.Pesel == clientDTO.Pesel);
            if (client == null)
            {
                client = new Client
                {
                    FirstName = clientDTO.FirstName,
                    LastName = clientDTO.LastName,
                    Email = clientDTO.Email,
                    Telephone = clientDTO.Telephone,
                    Pesel = clientDTO.Pesel
                };
                _context.Clients.Add(client);
                await _context.SaveChangesAsync();
            }

            var isAlreadyAssigned = await _context.ClientTrips.AnyAsync(ct => ct.IdClient == client.IdClient && ct.IdTrip == idTrip);
            if (isAlreadyAssigned)
            {
                throw new InvalidOperationException("Client is already assigned to this trip.");
            }

            var clientTrip = new ClientTrip
            {
                IdClient = client.IdClient,
                IdTrip = idTrip,
                RegisteredAt = DateTime.UtcNow, 
                PaymentDate = clientDTO.PaymentDate
            };
            _context.ClientTrips.Add(clientTrip);
            await _context.SaveChangesAsync();

            trip = await _context.Trips
                .Include(t => t.IdCountries)
                .Include(t => t.ClientTrips).ThenInclude(ct => ct.IdClientNavigation)
                .FirstOrDefaultAsync(t => t.IdTrip == idTrip);

            return new TripDTO
            {
                Name = trip.Name,
                Description = trip.Description,
                DateFrom = trip.DateFrom,
                DateTo = trip.DateTo,
                MaxPeople = trip.MaxPeople,
                Countries = trip.IdCountries.Select(c => new CountryDTO { Name = c.Name }).ToList(),
                Clients = trip.ClientTrips.Select(ct => new ClientDTO
                {
                    FirstName = ct.IdClientNavigation.FirstName,
                    LastName = ct.IdClientNavigation.LastName
                }).ToList()
            };
        }

    }
}
