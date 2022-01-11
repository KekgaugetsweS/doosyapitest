namespace Doosy.Framework.Domain
{
    public interface ICommandServiceBase<Req> where Req : RequestBase
    {
        CreationResponse Create(Req request);

        ResponseBase Update(Req request);

        ResponseBase Delete(object request);
    }
}
