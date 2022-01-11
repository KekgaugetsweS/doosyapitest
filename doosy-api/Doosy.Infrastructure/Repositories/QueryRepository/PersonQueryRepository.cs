using System;
using System.Linq;
using Doosy.Domain.Entities;
using Doosy.Domain.Requests.Filters;
using Doosy.Framework.Domain;
using Microsoft.EntityFrameworkCore;

namespace Doosy.Infrastructure.Repositories.QueryRepository
{
    public class PersonQueryRepository : QueryRepository<Person, PersonFilter>, IQueryRepository<Person, PersonFilter>
    {
        public PersonQueryRepository(DbContext context) : base(context)
        {
        }

        protected override IQueryable<Person> FilterData(PersonFilter filter)
        {
            if (!string.IsNullOrEmpty(filter.Firstname))
            {
                 return context.Set<Person>().Where(x => x.Firstname.Contains(filter.Firstname, StringComparison.InvariantCultureIgnoreCase));
            }
            else
            {
                return context.Set<Person>();
            }
        }

        protected override IQueryable<Person> GetByIdQuery(object id)
        {
            var itemId = id.ToString();
            var item = context.Set<Person>().Where(x=>x.Id==itemId);
            return item;
        }
    }
}
