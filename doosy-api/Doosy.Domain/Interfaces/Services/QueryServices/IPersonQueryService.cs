using Doosy.Domain.Requests.Filters;
using Doosy.Domain.Responses;
using Doosy.Framework.Domain;

namespace Doosy.Domain.Interfaces.Services.QueryServices
{
    public interface IPersonQueryService: IQueryServiceBase<PersonListPageResponse, PersonFilter, Doosy.Domain.Entities.Person>
    {
    }
}
