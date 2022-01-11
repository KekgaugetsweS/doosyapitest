using System;
using Microsoft.Extensions.Logging;

namespace Doosy.Framework.Domain
{
    public abstract class ServiceBase
    {
        protected ILogger<ServiceBase> logger;

        public ServiceBase(ILogger<ServiceBase> logger)
        {
            this.logger = logger;
        }

        public abstract string EntityName { get; }

        protected void LogError(ResponseBase result, Exception ex, string message)
        {
            result.IsSuccessful = false;
            result.Messages.Add(message);
            this.logger.LogError(ex, ex.Message+$"{EntityName}");
        }
    }
}
