using Doosy.Domain.Interfaces.Services;
using Doosy.Domain.Interfaces.Services.CommandServices;
using Doosy.Domain.Interfaces.Services.QueryServices;
using Doosy.Domain.Requests;
using Doosy.Domain.Requests.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Doosy.API.Controllers
{
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        IPersonCommandService commandService;
        IPersonExportService exportService;
        IPersonQueryService queryService;

        public PersonController(IPersonCommandService commandService, IPersonExportService exportService, IPersonQueryService queryService)
        {
            this.commandService = commandService;
            this.exportService = exportService;
            this.queryService = queryService;
        }

        [HttpGet("get-by-id/{id}")]
        public IActionResult GetById(int id)
        {
            var response = queryService.GetById(id);
            return Ok(response);
        }

        [HttpPost("filter")]
        public IActionResult Filter([FromBody]PersonFilter filter)
        {
            var response = queryService.Filter(filter);
            return Ok(response);
        }

        [HttpPut("put")]
        public IActionResult Update([FromBody]PersonRequest request)
        {
            var response = commandService.Update(request);
            return Ok(response);
        }

        [HttpPost("post")]
        public IActionResult Post([FromBody]PersonRequest request)
        {
            var response = commandService.Create(request);
            return Ok(response);
        }

        [HttpPost("export")]
        public IActionResult Export([FromBody]PersonFilter filter)
        {
            var response=exportService.Export(filter);
            return Ok(response);
        }
    }
}
