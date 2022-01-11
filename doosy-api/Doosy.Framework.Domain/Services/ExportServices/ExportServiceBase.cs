using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace Doosy.Framework.Domain
{
    public abstract class ExportServiceBase<F, Res, Ent> : ServiceBase, IExportServiceBase<F, Res, Ent> where F : FilterRequest where Res : class where Ent : Entity
    {
        IQueryRepository<Ent, F> queryRepository;
        IExcelExporter excelExporter;

        public ExportServiceBase(IQueryRepository<Ent, F> queryRepository,
        IExcelExporter excelExporter, ILogger<ExportServiceBase<F, Res, Ent>> logger) : base(logger)
        {
            this.queryRepository = queryRepository;
            this.excelExporter = excelExporter;
        }

        public ExportResponse Export(F filter)
        {
            var response = new ExportResponse();
            try
            {
                var filterResults = queryRepository.Filter(filter);
                var trimmed = TrimFilterResults(filterResults);
                response.Url = excelExporter.Export("Export", trimmed);
                response.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                LogError(response, ex, $"Error occured when Exporting data.");
            }
            return response;
        }

        protected abstract List<Res> TrimFilterResults(IEnumerable<Ent> filterResults);

    }
}
