using AutoMapper;
using PokojeCore.Dtos;
using PokojeCore.Models;
namespace PokojeCore.Mappings
{
    public class ReservationProfile : Profile
    {
        public ReservationProfile() {
            CreateMap<Reservation, ReservationResponse>();
            CreateMap<ReservationRequest, Reservation>();
        }
    }
}
