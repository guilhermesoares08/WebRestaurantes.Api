using AutoMapper;
using WebRestaurantes.Domain;
using WebRestaurantes.WebAPI.Dtos;

namespace WebRestaurantes.WebAPI.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Restaurant, RestaurantDto>().ReverseMap();
                // .ForMember(dest => dest.Extensions, opt =>
                // {
                //     opt.MapFrom(src => src.Extensions.Select(x => x.DomainInfo).ToList())
                // });
            CreateMap<RestaurantAddress, RestaurantAddressDto>().ReverseMap();
            CreateMap<RestaurantExtension, RestaurantExtensionDto>().ReverseMap();
            // CreateMap<Domain.Domain, DomainDto>().ReverseMap();
            CreateMap<DomainValue, DomainValueDto>().ReverseMap();         
            CreateMap<Image, ImageDto>().ReverseMap();
            CreateMap<Table, TableDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserLoginDto>().ReverseMap();
        }
    }
}