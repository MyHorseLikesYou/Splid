using System.Threading.Tasks;

namespace MyApp.Core.Contracts
{
    public interface IUnitOfWork
    {
        Task SaveChanges();
    }
}
