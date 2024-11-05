
using AutoMapper;
using Koios.UI.Model;
using Koios.UI.Services.Base;

namespace Koios.UI.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<OfferDto, EditOfferModel>().ReverseMap();
            CreateMap<OfferItemDto, AddOfferItemModel>().ReverseMap();
        }
    }
}
