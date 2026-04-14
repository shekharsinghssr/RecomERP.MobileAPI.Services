using RecomERP.MobileAPI.Application.DTOs;

namespace RecomERP.MobileAPI.Application.IServices
{
    public interface IThumbBannerService
    {
        Task<IEnumerable<ThumbBannerDto>> GetAllThumbBannersAsync();
        Task<ThumbBannerDto?> GetThumbBannerByIDAsync(int id);
    }
}