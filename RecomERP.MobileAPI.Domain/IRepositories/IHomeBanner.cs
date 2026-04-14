using RecomERP.MobileAPI.Domain.Models.RecomERP;

namespace RecomERP.MobileAPI.Domain.IRepositories
{
    public interface IHomeBannerRepository
    {
        Task<IEnumerable<HomeBanner>> GetAllBannersAsync();
        Task<HomeBanner?> GetBannerByIDAsync(int id);
    }
}