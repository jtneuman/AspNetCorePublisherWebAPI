using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublisherWebAPI.Services
{
    public interface IGenericEFRepository
    {
        IEnumerable<TEntity> Get<TEntity>() where TEntity : class;
        TEntity Get<TEntity>(int id, bool includeRelatedEntities = false) where TEntity : class;
    }
}
