using System.Linq;
using System.Threading.Tasks;
using ISRPO.Fourth.Domain.Models;

namespace ISRPO.Fourth.Domain.Repositories.Base
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        public Task<TEntity> Create(TEntity entity);

        public IQueryable<TEntity> Read();

        public Task<TEntity> Update(TEntity entity);

        public Task<bool> Delete(TEntity entity);
    }
}