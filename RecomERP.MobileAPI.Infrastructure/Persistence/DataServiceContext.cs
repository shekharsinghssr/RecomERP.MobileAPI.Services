using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RecomERP.MobileAPI.Application.IServices.DataServices;

namespace RecomERP.MobileAPI.Infrastructure.Persistence
{
    public class DataServiceContext : IDataServiceContext
    {
        private readonly IServiceProvider _serviceProvider;
        public ISqlDataService SqlDataService { get; }
        public IMapper Mapper { get; }


        public DataServiceContext(
            ISqlDataService sqlDataService,
            IMapper mapper,
            IServiceProvider serviceProvider)
        {
            SqlDataService = sqlDataService ?? throw new ArgumentNullException(nameof(sqlDataService));
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _serviceProvider = serviceProvider;
        }

        public TDbContext GetDbContext<TDbContext>() where TDbContext : DbContext
        {
            return _serviceProvider.GetRequiredService<TDbContext>();
        }
        public TRepository GetRepository<TRepository>() where TRepository : class
        {
            return _serviceProvider.GetRequiredService<TRepository>();
        }
        public ILogger<T> GetLogger<T>()
        {
            return _serviceProvider.GetRequiredService<ILogger<T>>();
        }

    }
}
