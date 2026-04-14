using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RecomERP.MobileAPI.Application.IServices.DataServices;
using RecomERP.MobileAPI.Domain.IRepositories;
using RecomERP.MobileAPI.Domain.Models.RecomERP;

namespace RecomERP.MobileAPI.Infrastructure.Repositories
{
    public class ThumbBannerRepository : BaseRepository, IThumbBannerRepository
    {
        public ThumbBannerRepository(IDataServiceContext context) : base(context) { }

        public async Task<IEnumerable<ThumbBanner>> GetAllThumbBannersAsync()
        {
            try
            {
                return await _recomERPDb.ThumbBanners
                    .Where(x => x.Active == true && x.IsDeleted == false)
                    .OrderBy(x => x.DisplayOrder)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching ThumbBanner list");
                return Enumerable.Empty<ThumbBanner>();
            }
        }

        public async Task<ThumbBanner?> GetThumbBannerByIDAsync(int id)
        {
            try
            {
                return await _recomERPDb.ThumbBanners
                    .FirstOrDefaultAsync(x => x.ID == id && x.Active == true && x.IsDeleted == false);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching ThumbBanner with ID {ID}", id);
                return null;
            }
        }
    }
}