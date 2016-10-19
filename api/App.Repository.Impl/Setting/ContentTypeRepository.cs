using App.Common.Data;
using App.Common.Data.MSSQL;
using App.Context;
using App.Repository.Setting;

namespace App.Repository.Impl.Setting
{
    public class ContentTypeRepository: BaseContentRepository<App.Entity.Setting.ContentType>, IContentTypeRepository
    {
        public ContentTypeRepository(): base(new AppDbContext()){}
        public ContentTypeRepository(IUnitOfWork uow) : base(uow.Context as IMSSQLDbContext) { }
    }
}
