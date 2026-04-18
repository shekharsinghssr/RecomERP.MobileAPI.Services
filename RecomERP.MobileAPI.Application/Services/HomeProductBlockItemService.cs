using AutoMapper;
using RecomERP.MobileAPI.Application.DTOs;
using RecomERP.MobileAPI.Application.IServices;
using RecomERP.MobileAPI.Domain.IRepositories;

namespace RecomERP.MobileAPI.Application.Services
{
    public class HomeProductBlockItemService : IHomeProductBlockItemService
    {
        private readonly IHomeProductBlockItemRepository _homeProductBlockItemRepository;
        private readonly IMapper _mapper;

        public HomeProductBlockItemService(IHomeProductBlockItemRepository homeProductBlockItemRepository, IMapper mapper)
        {
            _homeProductBlockItemRepository = homeProductBlockItemRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<HomeProductBlockItemDto>> GetAllHomeProductBlockItemsAsync()
        {
            var items = await _homeProductBlockItemRepository.GetAllHomeProductBlockItemsAsync();
            return _mapper.Map<IEnumerable<HomeProductBlockItemDto>>(items);
        }

        //public async Task<HomeProductBlockItemDto?> GetHomeProductBlockItemByIDAsync(int id)
        //{
        //    var item = await _homeProductBlockItemRepository.GetHomeProductBlockItemByIDAsync(id);
        //    return item == null ? null : _mapper.Map<HomeProductBlockItemDto>(item);
        //}
        public async Task<IEnumerable<HomeProductBlockItemDto>> GetItemsByProductBlockIdAsync(int productBlockId)
        {
            var items = await _homeProductBlockItemRepository.GetItemsByProductBlockIdAsync(productBlockId);
            return _mapper.Map<IEnumerable<HomeProductBlockItemDto>>(items);
        }

    }
}