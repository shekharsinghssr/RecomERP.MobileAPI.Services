using RecomERP.MobileAPI.Application.DTOs;

namespace RecomERP.MobileAPI.Application.IServices
{
    public interface IHomeProductBlockItemService
    {
        Task<IEnumerable<HomeProductBlockItemDto>> GetAllHomeProductBlockItemsAsync();
        Task<HomeProductBlockItemDto?> GetHomeProductBlockItemByIDAsync(int id);
    }
}