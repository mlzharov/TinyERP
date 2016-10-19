using System.IO;
using System.Web.Mvc;
using System;

namespace App.Common.MVC.Upload
{

    [ModelBinder(typeof(UploadFileBinder))]
    public class FileUploader
    {
        public string Filename { get; set; }
        public string FileType { get; set; }
        public string FileExtension { get; set; }
        public Stream InputStream { get; set; }

        public void SaveAs(string destination, bool overwrite = false, bool autoCreateDirectory = true)
        {
            if (autoCreateDirectory)
            {
                var directory = new FileInfo(destination).Directory;
                if (directory.Exists == false)
                {
                    directory.Create();
                }
            }
            using (var file = new FileStream(destination, overwrite ? FileMode.Create : FileMode.CreateNew))
            {
                InputStream.CopyTo(file);
                file.Close();
            }
        }

        public class UploadFileBinder : IModelBinder
        {
            public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
            {
                var request = controllerContext.RequestContext.HttpContext.Request;
                var formUpload = request.Files.Count > 0;

                // find filename
                var xFileName = request.Headers["X-File-Name"];
                var fileName = request["Filename"];
                var fileType = formUpload ? request.Files[0].ContentType : null;
                var formFilename = formUpload ? request.Files[0].FileName : null;
                var ext = Path.GetExtension(formFilename);

                var upload = new FileUploader
                {
                    Filename = xFileName ?? fileName ?? formFilename,
                    FileType = fileType,
                    InputStream = formUpload ? request.Files[0].InputStream : request.InputStream,
                    FileExtension = ext
                };

                return upload;
            }
        }

    }
}