using System;
using System.Collections.Generic;
using Doosy.Domain.Constants;
using Doosy.Domain.Interfaces.Services;
using Doosy.Domain.Requests;
using Doosy.Domain.Requests.Filters;
using Doosy.Domain.Responses;
using Doosy.Framework.Domain;
using Microsoft.Extensions.Logging;

namespace Doosy.Domain.Services.ExportServices
{
    public class PersonExportService : ExportServiceBase<PersonFilter, PersonListPageResponse, Doosy.Domain.Entities.Person>, IPersonExportService
    {
        public PersonExportService(IQueryRepository<Entities.Person, PersonFilter> queryRepository, IExcelExporter excelExporter, ILogger<ExportServiceBase<PersonFilter, PersonListPageResponse, Entities.Person>> logger) : base(queryRepository, excelExporter, logger)
        {
        }

        public override string EntityName => EntityNames.PersonEntity;

        protected override List<PersonListPageResponse> TrimFilterResults(IEnumerable<Entities.Person> filterResults)
        {
            var results=new List<PersonListPageResponse>();
            foreach (var item in filterResults)
                results.Add(new PersonListPageResponse { Firstname=item.Firstname, Id=item.Id,Surname=item.Surname });

            return results;
        }
    }
}
