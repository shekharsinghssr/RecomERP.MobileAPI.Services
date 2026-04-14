using RecomERP.MobileAPI.Application.DTOs;

namespace RecomERP.MobileAPI.Application.IServices
{
    public interface IHomeBannerService
    {
        Task<IEnumerable<HomeBannerDto>> GetAllBannersAsync();
        Task<HomeBannerDto?> GetBannerByIDAsync(int id);
    }
}