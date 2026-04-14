using Microsoft.EntityFrameworkCore;
using RecomERP.MobileAPI.Application.IServices.DataServices;
using RecomERP.MobileAPI.Domain.IRepositories;
using RecomERP.MobileAPI.Domain.Models.RecomERP;
using Microsoft.Extensions.Logging;

namespace RecomERP.MobileAPI.Infrastructure.Repositories
{
    public class HomeBannerRepository : BaseRepository, IHomeBannerRepository
    {
        public HomeBannerRepository(IDataServiceContext context) : base(context) { }

        public async Task<IEnumerable<HomeBanner>> GetAllBannersAsync()
        {
            try
            {
                return await _recomERPDb.HomeBanners
                    .Where(x => x.IsActive == true && x.IsDeleted == false)
                    .OrderBy(x => x.DisplayOrder)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching HomeBanner list");
                return Enumerable.Empty<HomeBanner>();
            }
        }

        public async Task<HomeBanner?> GetBannerByIDAsync(int id)
        {
            try
            {
                return await _recomERPDb.HomeBanners
                    .FirstOrDefaultAsync(x => x.ID == id && x.IsActive == true && x.IsDeleted == false);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching HomeBanner with ID {ID}", id);
                return null;
            }
        }
    }
}