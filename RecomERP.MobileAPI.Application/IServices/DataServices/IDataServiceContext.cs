using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace RecomERP.MobileAPI.Application.IServices.DataServices
{
    public interface IDataServiceContext
    {
        ILogger<T> GetLogger<T>();
        ISqlDataService SqlDataService { get; }
        IMapper Mapper { get; }
        TDbContext GetDbContext<TDbContext>() where TDbContext : DbContext;
        TRepository GetRepository<TRepository>() where TRepository : class;
    }
}
