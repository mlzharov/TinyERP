using System;
using System.Collections.Generic;
using App.Common.Providers;
using App.Service.Common.File;
using App.Common.Data;
using App.Context;
using App.Common;
using App.Common.Helpers;
using App.Common.DI;
using App.Repository.Common;
using App.Entity.Common;
using System.Drawing;

namespace App.Service.Impl.Common
{
    public class FileService : IFileService
    {
        public FileUpload Get(Guid id)
        {
            IFileRepository repo = IoC.Container.Resolve<IFileRepository>();
            return repo.GetById(id.ToString());
        }

        public string GetPhotoAsBase64(Guid id)
        {
            IFileRepository repo = IoC.Container.Resolve<IFileRepository>();
            App.Entity.Common.FileUpload file = repo.GetById(id.ToString());
            return ImageHelper.ToBase64(file.FileName, file.Content);
        }

        public Bitmap GetThumbnail(Guid id, ThumbnailSize size)
        {
            IFileRepository repo = IoC.Container.Resolve<IFileRepository>();
            App.Entity.Common.FileUpload file = repo.GetById(id.ToString());
            return ImageHelper.GetThumbnail(file.FileName, file.Content, size);
        }

        //public HttpResponseMessage CreateThumbnail(Guid id, ThumbnailType type)
        //{
        //    ValidateCreateThumbnailRequest(id);
        //    IFileUploadRepository repo = IoC.Container.Resolve<IFileUploadRepository>();
        //    FileUpload file = repo.GetById(id.ToString());
        //    Stream fileStream = GetFileStream(file, type);
        //    StreamContent strContent = new StreamContent(fileStream);
        //    strContent.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse(file.ContentType);

        //    HttpResponseMessage message = new HttpResponseMessage();
        //    message.Content = strContent;
        //    return message;
        //}

        //private Stream GetFileStream(FileUpload file, ThumbnailType type)
        //{
        //    Stream stream;
        //    Image img;
        //    switch (file.ContentType)
        //    {
        //        case FileContentType.Jpeg:
        //        case FileContentType.Png:
        //            byte[] contentInByte = Encoding.ASCII.GetBytes(file.Content);
        //            stream= new MemoryStream(contentInByte, 0, contentInByte.Length);
        //            //stream = new MemoryStream();
        //            //img = PhotoHelper.CreatePngStream(file.Content, type);
        //            //img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
        //            break;

        //            //stream = new MemoryStream();
        //            //img = PhotoHelper.CreatePngStream(file.Content, type);
        //            //img.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
        //            //break;
        //        default:
        //            throw new ValidationException("common.httpError.unsupportedContent");
        //    }
        //    return stream;
        //}

        //private void ValidateCreateThumbnailRequest(Guid id)
        //{
        //    IFileUploadRepository repo = IoC.Container.Resolve<IFileUploadRepository>();
        //    FileUpload file = repo.GetById(id.ToString());
        //    if (file == null)
        //    {
        //        throw new ValidationException("common.httpError.notFound");
        //    }
        //}

        //public IList<TEntity> GetByParentId<TEntity>(Guid parentId) where TEntity : IMappedFrom<FileUpload>
        //{
        //    IFileUploadRepository repo = IoC.Container.Resolve<IFileUploadRepository>();
        //    return repo.GetByParentId<TEntity>(parentId);
        //}

        //public FilesUploadResponse UploadFiles(Guid parentId, HttpFileCollection files)
        //{
        //    FilesUploadResponse uploadResponse = new FilesUploadResponse();
        //    ValidateUploadFilesRequest(parentId);
        //    using (IUnitOfWork uow = new UnitOfWork(new AppDbContext(IOMode.Write)))
        //    {
        //        IFileUploadRepository fileRepo = IoC.Container.Resolve<IFileUploadRepository>(uow);
        //        foreach (string fileKey in files)
        //        {
        //            HttpPostedFile file = files[fileKey];
        //            FileUpload fileUpload = new FileUpload(file);
        //            fileUpload.ParentId = parentId;
        //            fileRepo.Add(fileUpload);
        //            uploadResponse.File = fileUpload.Id;
        //        }
        //        uow.Commit();
        //    }
        //    return uploadResponse;
        //}

        //private void ValidateUploadFilesRequest(Guid parentId)
        //{
        //    if (parentId == null)
        //    {
        //        throw new ValidationException("common.fileUpload.invalidParentId");
        //    }
        //}

        //public FileUpload GetById(Guid id)
        //{
        //    IFileUploadRepository repo = IoC.Container.Resolve<IFileUploadRepository>();
        //    return repo.GetById(id.ToString());
        //}

        //public FilesUploadResponse UploadFiles(Guid parentId, IList<FileUploadInfo> files)
        //{
        //    FilesUploadResponse uploadResponse = new FilesUploadResponse();
        //    ValidateUploadFilesRequest(parentId);
        //    using (IUnitOfWork uow = new UnitOfWork(new AppDbContext(IOMode.Write)))
        //    {
        //        IFileUploadRepository fileRepo = IoC.Container.Resolve<IFileUploadRepository>(uow);
        //        foreach (FileUploadInfo file in files)
        //        {
        //            FileUpload fileUpload = new FileUpload(file);
        //            fileUpload.ParentId = parentId;
        //            fileRepo.Add(fileUpload);
        //            uploadResponse.File = fileUpload.Id;
        //        }
        //        uow.Commit();
        //    }
        //    return uploadResponse;
        //}
        public IList<FileUploadResponse> UploadFiles(List<MultipartFormDataMemoryStreamProvider.FileInfo> files)
        {
            ValidateUploadRequest(files);
            using (IUnitOfWork uow = new UnitOfWork(new AppDbContext(IOMode.Write)))
            {
                IFileRepository repo = IoC.Container.Resolve<IFileRepository>(uow);
                IList<FileUploadResponse> filesUploaded = new List<FileUploadResponse>();
                foreach (App.Common.Providers.MultipartFormDataMemoryStreamProvider.FileInfo file in files)
                {
                    App.Entity.Common.FileUpload fileCreated = new Entity.Common.FileUpload(file.FileName, file.ContentType, file.FileSize, file.Content);
                    repo.Add(fileCreated);
                    filesUploaded.Add(ObjectHelper.Convert<FileUploadResponse>(fileCreated));
                }
                uow.Commit();
                return filesUploaded;
            }
        }

        private void ValidateUploadRequest(object files)
        {
            //throw new NotImplementedException();
        }
    }
}
