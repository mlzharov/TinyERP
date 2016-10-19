using System;
using System.Collections.Generic;
using App.Common;
using App.Common.Providers;
using App.Entity.Common;

namespace App.Service.Common.File
{
    public interface IFileService
    {
        //IList<TEntity> GetByParentId<TEntity>(Guid parentId) where TEntity: IMappedFrom<FileUpload>;
        //System.Net.Http.HttpResponseMessage CreateThumbnail(Guid id, ThumbnailType type);
        //FileUpload GetById(Guid id);
        //FilesUploadResponse UploadFiles(Guid parentId, IList<FileUploadInfo> files);
        //FilesUploadResponse UploadFiles(Guid parentId, System.Web.HttpFileCollection files);
        IList<FileUploadResponse> UploadFiles(List<MultipartFormDataMemoryStreamProvider.FileInfo> fileData);
        string GetPhotoAsBase64(Guid id);
        FileUpload Get(Guid id);
        System.Drawing.Bitmap GetThumbnail(Guid id, ThumbnailSize medium);
    }
}
