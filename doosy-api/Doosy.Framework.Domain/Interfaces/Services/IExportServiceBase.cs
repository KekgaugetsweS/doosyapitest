
namespace Doosy.Framework.Domain
{
    public interface IExportServiceBase<F,Res,Ent>  where F : FilterRequest where Res:class where Ent:Entity
    {
        ExportResponse Export(F filter);
    }
}
