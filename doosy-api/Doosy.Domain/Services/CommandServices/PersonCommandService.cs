using System;
using Doosy.Domain.Constants;
using Doosy.Domain.Enum;
using Doosy.Domain.Interfaces.Services.CommandServices;
using Doosy.Domain.Requests;
using Doosy.Domain.Requests.Filters;
using Doosy.Framework.Domain;
using Microsoft.Extensions.Logging;

namespace Doosy.Domain.Services.Person
{
    public class PersonCommandService : CommandServiceBase<PersonRequest, Doosy.Domain.Entities.Person, PersonFilter>, IPersonCommandService
    {

        public PersonCommandService(ICommandRepository<Entities.Person> commandRepository,
            IQueryRepository<Entities.Person, PersonFilter> queryRepository,
            IValidatorBase<PersonRequest> validator,
            ILogger<PersonCommandService> logger) : base(commandRepository, queryRepository, validator, logger)
        {
        }

        public override string EntityName => EntityNames.PersonEntity;

        protected override void AfterCreation(PersonRequest request, Entities.Person entity)
        {
         
        }

        protected override void AfterUpdate(PersonRequest request, Entities.Person entity)
        {
            // nothing to do here
        }

        protected override Entities.Person BeforeCreation(PersonRequest request)
        {
            return Entities.Person.Create( request.Id, request.Firstname,request.Surname,(Gender)request.Gender,request.UserId);
        }

        protected override Entities.Person BeforeUpdate(PersonRequest request)
        {

            var person=this.queryRepository.GetByIdPlain(request.Id);
            person.UpdateFirstName(request.Firstname);
            person.UpdateSurname(request.Surname);
            person.UpdateGender((Gender)request.Gender);

            return person;

        }
    }
}
