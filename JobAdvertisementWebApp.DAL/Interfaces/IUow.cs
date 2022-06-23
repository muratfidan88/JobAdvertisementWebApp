using System.Threading.Tasks;

namespace JobAdvertisementWebApp.DAL.Interfaces
{
    public interface IUow
    {
        IRepository<T> GetRepository<T>() where T : class, new();
        Task SaveChangesAsync();
    }
}
