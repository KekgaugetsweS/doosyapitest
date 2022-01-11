using Doosy.Domain.Entities;
using Doosy.Domain.Interfaces.Services;
using Doosy.Domain.Interfaces.Services.CommandServices;
using Doosy.Domain.Interfaces.Services.QueryServices;
using Doosy.Domain.Requests;
using Doosy.Domain.Requests.Filters;
using Doosy.Domain.Responses;
using Doosy.Domain.Services.ExportServices;
using Doosy.Domain.Services.Person;
using Doosy.Domain.Validators;
using Doosy.Framework.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Doosy.Domain.Extensions
{
    public static class DomainServiceExtension
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            services.AddCommandServices();
            services.AddQueryServices();
            services.AddExportServices();
            services.AddValidators();

            return services;
        }

        static IServiceCollection AddCommandServices(this IServiceCollection services)
        {
            services.AddTransient<IPersonCommandService, PersonCommandService>();
            return services;
        }

        static IServiceCollection AddQueryServices(this IServiceCollection services)
        {
            services.AddTransient<IPersonQueryService, PersonQueryService>();
            return services;
        }

        static IServiceCollection AddExportServices(this IServiceCollection services)
        {
            services.AddTransient<IPersonExportService, PersonExportService>();
            return services;
        }

        static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddTransient<IValidatorBase<PersonRequest>, PersonValidator>();

            return services;
        }
    }
}
