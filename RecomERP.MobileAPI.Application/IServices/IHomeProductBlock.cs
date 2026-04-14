using RecomERP.MobileAPI.Application.DTOs;

namespace RecomERP.MobileAPI.Application.IServices
{
    public interface IHomeProductBlockService
    {
        Task<IEnumerable<HomeProductBlockDto>> GetAllHomeProductBlocksAsync();
        Task<HomeProductBlockDto?> GetHomeProductBlockByIDAsync(int id);
    }
}