using System.Collections.Generic;
using System.Linq;
using Doosy.Framework.Domain;
using Microsoft.AspNetCore.Mvc;


namespace Doosy.API.Controllers
{
    public class DoosyController : Controller
    {
        protected List<AttachmentRequest> GetFiles() 
        {
            var attachments = new List<AttachmentRequest>();
            if (Request.Form.Files.Any())
            {
                foreach (var file in Request.Form.Files)
                {
                    var fileStream = file.OpenReadStream();

                    var attachment = new AttachmentRequest
                    {
                        StreamData = fileStream,
                        AttachmentName = file.FileName,
                        MimeType = file.ContentType,
                    };
                    attachments.Add(attachment);
                }
            }
            return attachments;
        }
    }
}
