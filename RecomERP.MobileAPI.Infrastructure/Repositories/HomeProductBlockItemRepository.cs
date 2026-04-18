using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RecomERP.MobileAPI.Application.IServices.DataServices;
using RecomERP.MobileAPI.Domain.IRepositories;
using RecomERP.MobileAPI.Domain.Models.RecomERP;

namespace RecomERP.MobileAPI.Infrastructure.Repositories
{
    public class HomeProductBlockItemRepository : BaseRepository, IHomeProductBlockItemRepository
    {
        public HomeProductBlockItemRepository(IDataServiceContext context) : base(context) { }

        public async Task<IEnumerable<HomeProductBlockItem>> GetAllHomeProductBlockItemsAsync()
        {
            try
            {
                return await _recomERPDb.HomeProductBlockItems
                   
                    .OrderBy(x => x.DisplayOrder)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching HomeProductBlockItem list");
                return Enumerable.Empty<HomeProductBlockItem>();
            }
        }


        //public async Task<HomeProductBlockItem?> GetHomeProductBlockItemByIDAsync(int id)
        //{
        //    try
        //    {
        //        return await _recomERPDb.HomeProductBlockItems
        //            .FirstOrDefaultAsync(x => x.ProductBlockId == id && x.IsActive == true);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "Error fetching HomeProductBlockItem with ID {ID}", id);
        //        return null;
        //    }
        //}


        public async Task<IEnumerable<HomeProductBlockItem>> GetItemsByProductBlockIdAsync(int productBlockId)
        {
            try
            {
                return await _recomERPDb.HomeProductBlockItems
                    .Where(x => x.ProductBlockId == productBlockId)
                    .OrderBy(x => x.DisplayOrder)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching HomeProductBlockItems with ProductBlockId {ID}", productBlockId);
                return Enumerable.Empty<HomeProductBlockItem>();
            }
        }
    }
}