namespace Doosy.Framework.Domain
{
    public interface IQueryServiceBase<Res, F, Ent> where Res : class where F : FilterRequest where Ent : Entity
    {
        ObjectResponse<Res> GetById(object id);

        PagedDataResponce<Res> Filter(F filter);
    }
}
