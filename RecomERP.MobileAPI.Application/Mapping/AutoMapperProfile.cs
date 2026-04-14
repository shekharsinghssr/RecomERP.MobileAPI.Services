using AutoMapper;
using RecomERP.MobileAPI.Application.DTOs;
using RecomERP.MobileAPI.Domain.Models;
using RecomERP.MobileAPI.Domain.Models.RecomERP;
namespace RecomERP.MobileAPI.Application.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<SampleDto, SampleModel>().ReverseMap();
            CreateMap<HomeBanner, HomeBannerDto>().ReverseMap();
            CreateMap<ThumbBanner, ThumbBannerDto>().ReverseMap();
            CreateMap<HomeProductBlock, HomeProductBlockDto>().ReverseMap();
            CreateMap<HomeProductBlockItem, HomeProductBlockItemDto>().ReverseMap();

        }
    }
}
