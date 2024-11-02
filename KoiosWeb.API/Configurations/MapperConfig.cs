using AutoMapper;
using KoiosWeb.API.Data;
using KoiosWeb.API.Models;

namespace KoiosWeb.API.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<ComputerHardware, ComputerHardwareDto>().ReverseMap();
            CreateMap<HardwareSpec, HardwareSpecDto>().ReverseMap();
            CreateMap<HardwareType, HardwareTypeDto>().ReverseMap();
            CreateMap<Offer, OfferDto>().ReverseMap();
        }
    }
}

