using RecomERP.MobileAPI.Domain.IRepositories;
namespace RecomERP.MobileAPI.Infrastructure.Repositories
{
    public class BaseRepositories : ISampleRepository
    {
        public string GetValue(int id) => $"Value{id}";
    }
}
