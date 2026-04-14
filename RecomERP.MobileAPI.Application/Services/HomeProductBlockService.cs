using AutoMapper;
using RecomERP.MobileAPI.Application.DTOs;
using RecomERP.MobileAPI.Application.IServices;
using RecomERP.MobileAPI.Domain.IRepositories;

namespace RecomERP.MobileAPI.Application.Services
{
    public class HomeProductBlockService : IHomeProductBlockService
    {
        private readonly IHomeProductBlockRepository _homeProductBlockRepository;
        private readonly IMapper _mapper;

        public HomeProductBlockService(IHomeProductBlockRepository homeProductBlockRepository, IMapper mapper)
        {
            _homeProductBlockRepository = homeProductBlockRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<HomeProductBlockDto>> GetAllHomeProductBlocksAsync()
        {
            var blocks = await _homeProductBlockRepository.GetAllHomeProductBlocksAsync();
            return _mapper.Map<IEnumerable<HomeProductBlockDto>>(blocks);
        }

        public async Task<HomeProductBlockDto?> GetHomeProductBlockByIDAsync(int id)
        {
            var block = await _homeProductBlockRepository.GetHomeProductBlockByIDAsync(id);
            return block == null ? null : _mapper.Map<HomeProductBlockDto>(block);
        }
    }
}