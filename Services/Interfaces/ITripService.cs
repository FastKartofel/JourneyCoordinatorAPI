using JourneyCoordinatorAPI.DTOs;

namespace JourneyCoordinatorAPI.Repository.Interfaces
{
    public interface ITripService
    {
        Task<IEnumerable<TripDTO>> GetAllTripsAsync();
        Task<TripDTO> GetTripByIdAsync(int idTrip);
        Task<TripDTO> AssignClientToTripAsync(int idTrip, AssignClientDTO clientDTO);
    }
}
