using System;
using Doosy.Domain.Requests;
using Doosy.Domain.Requests.Filters;
using Doosy.Framework.Domain;

namespace Doosy.Domain.Interfaces.Services
{
    public interface IPersonExportService : IExportServiceBase<PersonFilter, PersonRequest, Entities.Person>
    {
    }
}
