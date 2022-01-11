using Doosy.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Doosy.Infrastructure.DatabaseContexts
{
    public class APIDataContext:DbContext
    {
        public APIDataContext(DbContextOptions<APIDataContext> options) :base(options)
        {
        }

        public DbSet<Person> Person { get; set; }

    }
}
