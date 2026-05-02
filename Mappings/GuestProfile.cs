using AutoMapper;
using PokojeCore.Dtos;
using PokojeCore.Models;

namespace PokojeCore.Mappings
{
    public class GuestProfile : Profile
    {
        public GuestProfile()
        {
            CreateMap<Guest, GuestResponse>();
            CreateMap<GuestRequest, Guest>();
        }
    }
}
