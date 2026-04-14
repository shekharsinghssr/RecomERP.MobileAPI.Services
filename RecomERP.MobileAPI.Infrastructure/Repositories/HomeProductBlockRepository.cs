using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RecomERP.MobileAPI.Application.IServices.DataServices;
using RecomERP.MobileAPI.Domain.IRepositories;
using RecomERP.MobileAPI.Domain.Models.RecomERP;

namespace RecomERP.MobileAPI.Infrastructure.Repositories
{
    public class HomeProductBlockRepository : BaseRepository, IHomeProductBlockRepository
    {
        public HomeProductBlockRepository(IDataServiceContext context) : base(context) { }

        public async Task<IEnumerable<HomeProductBlock>> GetAllHomeProductBlocksAsync()
        {
            try
            {
                return await _recomERPDb.HomeProductBlocks
                    .Where(x => x.IsActive == true)
                    .OrderBy(x => x.DisplayOrder)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching HomeProductBlock list");
                return Enumerable.Empty<HomeProductBlock>();
            }
        }

        public async Task<HomeProductBlock?> GetHomeProductBlockByIDAsync(int id)
        {
            try
            {
                return await _recomERPDb.HomeProductBlocks
                    .FirstOrDefaultAsync(x => x.ProductBlockId == id && x.IsActive == true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching HomeProductBlock with ID {ID}", id);
                return null;
            }
        }
    }
}