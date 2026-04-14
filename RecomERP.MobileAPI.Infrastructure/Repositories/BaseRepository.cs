using AutoMapper;
using Microsoft.Extensions.Logging;
using RecomERP.MobileAPI.Application.IServices.DataServices;
using RecomERP.MobileAPI.Infrastructure.Persistence;

namespace RecomERP.MobileAPI.Infrastructure.Repositories
{
    public class BaseRepository
    {
        protected readonly RecomERPContext _recomERPDb;
        protected readonly ILogger _logger;
        protected readonly ISqlDataService _sqlDataService;
        protected readonly IMapper _mapper;

        public BaseRepository(IDataServiceContext context)
        {
            _mapper = context?.Mapper
               ?? throw new ArgumentNullException(nameof(_mapper));
            _sqlDataService = context?.SqlDataService
                ?? throw new ArgumentNullException(nameof(_sqlDataService));
            _recomERPDb = context?.GetDbContext<RecomERPContext>()
              ?? throw new ArgumentNullException(nameof(_recomERPDb));
            _logger = context?.GetLogger<BaseRepository>()
                ?? throw new ArgumentNullException(nameof(_logger));
        }
    }
}