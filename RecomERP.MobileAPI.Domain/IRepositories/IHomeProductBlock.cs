using RecomERP.MobileAPI.Domain.Models.RecomERP;

namespace RecomERP.MobileAPI.Domain.IRepositories
{
    public interface IHomeProductBlockRepository
    {
        Task<IEnumerable<HomeProductBlock>> GetAllHomeProductBlocksAsync();
        Task<HomeProductBlock?> GetHomeProductBlockByIDAsync(int id);
    }
}