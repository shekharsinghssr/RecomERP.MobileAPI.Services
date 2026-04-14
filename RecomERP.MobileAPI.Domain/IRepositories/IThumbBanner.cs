using RecomERP.MobileAPI.Domain.Models.RecomERP;

namespace RecomERP.MobileAPI.Domain.IRepositories
{
    public interface IThumbBannerRepository
    {
        Task<IEnumerable<ThumbBanner>> GetAllThumbBannersAsync();
        Task<ThumbBanner?> GetThumbBannerByIDAsync(int id);
    }
}