using System;
using System.Collections.Generic;
using Doosy.Domain.Constants;
using Doosy.Domain.Interfaces.Services.QueryServices;
using Doosy.Domain.Requests;
using Doosy.Domain.Requests.Filters;
using Doosy.Domain.Responses;
using Doosy.Framework.Domain;
using Microsoft.Extensions.Logging;

namespace Doosy.Domain.Services.Person
{
    public class PersonQueryService : QueryServiceBase<PersonListPageResponse, PersonFilter, Entities.Person>, IPersonQueryService
    {
        public PersonQueryService(ILogger<QueryServiceBase<PersonListPageResponse, PersonFilter, Entities.Person>> logger, IQueryRepository<Entities.Person, PersonFilter> queryRepository) : base(logger, queryRepository)
        {
        }

        public override string EntityName => EntityNames.PersonEntity;

        protected override PersonListPageResponse GetByIdTrim(Entities.Person filterResults)
        {
            return new PersonListPageResponse { Firstname = filterResults.Firstname, Id = filterResults.Id, Surname = filterResults.Surname };
        }

        protected override List<PersonListPageResponse> TrimFilterResults(IEnumerable<Entities.Person> filterResults)
        {
            var results = new List<PersonListPageResponse>();
            foreach (var item in filterResults)
                results.Add(new PersonListPageResponse { Firstname = item.Firstname, Id = item.Id, Surname = item.Surname });

            return results;
        }
    }
}
