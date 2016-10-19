using System;

namespace App.Service.Setting
{
    public interface IContentTypeService
    {
        System.Collections.Generic.IList<ContentTypeListItem> GetContentTypes();
        void CreateIfNotExist(System.Collections.Generic.IList<CreateContentTypeRequest> request);
        void Delete(Guid id);
        GetContentTypeResponse Get(Guid id);
        void Create(CreateContentTypeRequest request);
        void Update(UpdateContentTypeRequest request);
    }
}
