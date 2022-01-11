using Doosy.Domain.Requests;
using Doosy.Framework.Domain;

namespace Doosy.Domain.Interfaces.Services.CommandServices
{
    public interface IPersonCommandService: ICommandServiceBase<PersonRequest>
    {
    }
}
