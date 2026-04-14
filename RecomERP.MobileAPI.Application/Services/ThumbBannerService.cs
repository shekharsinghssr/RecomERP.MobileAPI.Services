using AutoMapper;
using RecomERP.MobileAPI.Application.DTOs;
using RecomERP.MobileAPI.Application.IServices;
using RecomERP.MobileAPI.Domain.IRepositories;

namespace RecomERP.MobileAPI.Application.Services
{
    public class ThumbBannerService : IThumbBannerService
    {
        private readonly IThumbBannerRepository _thumbBannerRepository;
        private readonly IMapper _mapper;

        public ThumbBannerService(IThumbBannerRepository thumbBannerRepository, IMapper mapper)
        {
            _thumbBannerRepository = thumbBannerRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ThumbBannerDto>> GetAllThumbBannersAsync()
        {
            var banners = await _thumbBannerRepository.GetAllThumbBannersAsync();
            return _mapper.Map<IEnumerable<ThumbBannerDto>>(banners);
        }

        public async Task<ThumbBannerDto?> GetThumbBannerByIDAsync(int id)
        {
            var banner = await _thumbBannerRepository.GetThumbBannerByIDAsync(id);
            return banner == null ? null : _mapper.Map<ThumbBannerDto>(banner);
        }
    }
}