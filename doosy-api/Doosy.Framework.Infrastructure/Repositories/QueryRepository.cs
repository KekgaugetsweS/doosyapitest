using System.Collections.Generic;
using System.Linq;
using Doosy.Framework.Domain;
using Microsoft.EntityFrameworkCore;

namespace Doosy.Infrastructure.Repositories
{
    public abstract class QueryRepository<T, F> : IQueryRepository<T, F> where T : Entity where F : FilterRequest
    {
        protected DbContext context;

        public QueryRepository(DbContext context)
        {
            this.context = context;
        }

        public IEnumerable<T> Filter(F filter)
        {
            var results = FilterData(filter);

            results = SpecifyInclude(results);

            return results;
        }

        protected abstract IQueryable<T> FilterData(F filter);

        public T GetById(object id)
        {
            var results = GetByIdQuery(id);

            results = SpecifyInclude(results);

            return results.FirstOrDefault();
        }

        protected abstract IQueryable<T> GetByIdQuery(object id);

        public T GetByIdPlain(object id)
        {
            var item = context.Set<T>().Find(id);
            return item;
        }

        protected virtual IQueryable<T> SpecifyInclude(IQueryable<T> query)
        {
            return query;
        }
    }
}
