using System;
using System.Collections.Generic;
using Doosy.Framework.Domain;
using Microsoft.Extensions.Logging;

namespace Doosy.Framework.Domain
{
    public abstract class QueryServiceBase<Res, F, Ent> : ServiceBase, IQueryServiceBase<Res, F, Ent> where Res : class where F : FilterRequest where Ent : Entity
    {

        protected IQueryRepository<Ent, F> queryRepository;

        public QueryServiceBase(ILogger<QueryServiceBase<Res, F, Ent>> logger, IQueryRepository<Ent, F> queryRepository) :base(logger)
        {
            this.queryRepository = queryRepository;
        }

        public PagedDataResponce<Res> Filter(F filter)
        {
            var response = new PagedDataResponce<Res>();

            try
            {
                var filterResults = queryRepository.Filter(filter);


                var trimmed = TrimFilterResults(filterResults);

                response = trimmed.Paginate(filter.Page);

                response.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                //logger.LogInformation(ex, "Error occured when filtering data. ");
               LogError(response, ex, "Error occured when filtering data.");
            }
            return response;
        }

        protected abstract List<Res> TrimFilterResults(IEnumerable<Ent> filterResults);

        public ObjectResponse<Res> GetById(object id)
        {
            var response = new ObjectResponse<Res>();

            try
            {
                var filterResults = queryRepository.GetById(id);
                var trimmed = GetByIdTrim(filterResults);

                response.Data = trimmed;
                response.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                 LogError(response, ex, "Error occured reading data."); 
            }
            return response;
        }

        protected abstract Res GetByIdTrim(Ent filterResults);
    }
}
