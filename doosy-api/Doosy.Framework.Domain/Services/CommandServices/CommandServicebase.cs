

using System;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace Doosy.Framework.Domain
{
    public abstract class CommandServiceBase<Req,Ent,F>: ServiceBase,ICommandServiceBase<Req> where Req : RequestBase where Ent:Entity where F:FilterRequest
    {
        protected ICommandRepository<Ent> commandRepository;
        protected IQueryRepository<Ent,F> queryRepository;
        IValidatorBase<Req> validator;

        public CommandServiceBase(ICommandRepository<Ent> commandRepository,
        IQueryRepository<Ent, F> queryRepository,
        IValidatorBase<Req> validator,
        ILogger<CommandServiceBase<Req, Ent, F>> logger):base(logger)
        {
            this.commandRepository = commandRepository;
            this.queryRepository = queryRepository;
            this.validator = validator;
        }

        public CreationResponse Create(Req request)
        {
            var response = new CreationResponse();
            try
            {

                var validationresults = this.validator.Validate(request);
                if (!validationresults.Any())
                {
                    var itemToCreate = BeforeCreation(request);
                    commandRepository.Create(itemToCreate);
                    AfterCreation(request, itemToCreate);
                    response.IsSuccessful = true;
                }
                else
                {
                    response.IsSuccessful = false;
                    response.Messages = validationresults;
                }
            }
            catch (Exception ex)
            {
                logger.LogInformation(ex,"about to logg");
               //LogError(response, ex, $"Unknown Servere Error occured.");
            }

            return response;
        }
       

        public ResponseBase Delete(object id)
        {
            var response = new ResponseBase();

            try
            {
                var item = queryRepository.GetByIdPlain(id);
                if (item != null)
                {
                    item.Status = EntityStatus.Deleted;
                    commandRepository.Update(item);
                    response.IsSuccessful = true;
                }
                else
                {
                    response.IsSuccessful = false;
                    response.Messages.Add("Item not deleted.");
                }
            }
            catch (Exception ex)
            {
                LogError(response, ex, "Error occured when trying to delete.");
            }
            return response;
        }

        public ResponseBase Update(Req request)
        {
            var response = new ResponseBase();
            try
            {

                var validationresults = this.validator.Validate(request);
                if (!validationresults.Any())
                {
                    var person=queryRepository.GetByIdPlain(request.Id);

                    var itemToUpdate = BeforeUpdate(request);
                    commandRepository.Update(itemToUpdate);
                    AfterUpdate(request, itemToUpdate);
                    response.IsSuccessful = true;

                }
                else
                {
                    response.IsSuccessful = false;
                    response.Messages = validationresults;
                }
            }
            catch (Exception ex)
            {
                LogError(response, ex, $"Unknown Servere Error occured.");
            }

            return response;
        }

        protected abstract Ent BeforeCreation(Req request);

        protected abstract void AfterCreation(Req request, Ent entity);
        protected abstract Ent BeforeUpdate(Req request);

        protected abstract void AfterUpdate(Req request, Ent entity);
    }
}
