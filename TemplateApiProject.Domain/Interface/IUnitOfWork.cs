using TemplateApiProject.Domain.Interface.Repository;
using System.Threading.Tasks;

namespace TemplateApiProject.Domain.Interface
{
    public interface IUnitOfWork
    {
        IRepository<T> Repository<T>() where T : class;
        Task<int> Complete();
        void Rollback();
    }
}
