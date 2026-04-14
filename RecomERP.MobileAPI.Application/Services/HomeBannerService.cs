using AutoMapper;
using RecomERP.MobileAPI.Application.DTOs;
using RecomERP.MobileAPI.Application.IServices;
using RecomERP.MobileAPI.Domain.IRepositories;

namespace RecomERP.MobileAPI.Application.Services
{
    public class HomeBannerService : IHomeBannerService
    {
        private readonly IHomeBannerRepository _homeBannerRepository;
        private readonly IMapper _mapper;

        public HomeBannerService(IHomeBannerRepository homeBannerRepository, IMapper mapper)
        {
            _homeBannerRepository = homeBannerRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<HomeBannerDto>> GetAllBannersAsync()
        {
            var banners = await _homeBannerRepository.GetAllBannersAsync();
            return _mapper.Map<IEnumerable<HomeBannerDto>>(banners);
        }

        public async Task<HomeBannerDto?> GetBannerByIDAsync(int id)
        {
            var banner = await _homeBannerRepository.GetBannerByIDAsync(id);
            return banner == null ? null : _mapper.Map<HomeBannerDto>(banner);
        }
    }
}