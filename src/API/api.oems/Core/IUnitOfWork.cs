using System.Threading.Tasks;

namespace api.oems.Core
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
