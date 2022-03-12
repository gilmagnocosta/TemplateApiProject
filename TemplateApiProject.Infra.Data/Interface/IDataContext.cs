using System.Threading;
using System.Threading.Tasks;

namespace TemplateApiProject.Application.Data.Interface
{
    public interface IDataContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
