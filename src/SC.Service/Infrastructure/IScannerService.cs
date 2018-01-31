using SC.Model.Entity;

namespace SC.Service.Infrastructure
{
    public interface IScannerService : IEntityService<Scanner>
    {
        void Import(long id,string file);
    }
}
