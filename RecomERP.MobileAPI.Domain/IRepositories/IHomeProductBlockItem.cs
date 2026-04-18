using RecomERP.MobileAPI.Domain.Models.RecomERP;

namespace RecomERP.MobileAPI.Domain.IRepositories
{
    public interface IHomeProductBlockItemRepository
    {
        Task<IEnumerable<HomeProductBlockItem>> GetAllHomeProductBlockItemsAsync();
     //   Task<HomeProductBlockItem?> GetHomeProductBlockItemByIDAsync(int id);
        Task<IEnumerable<HomeProductBlockItem>> GetItemsByProductBlockIdAsync(int productBlockId);
    }
}