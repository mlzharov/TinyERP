using App.Common.Data;

namespace App.Entity.Common
{
    public class FileUpload: BaseEntity
    {
        public string FileName { get; set; }
        public byte[] Content { get; set; }
        public string ContentType { get; set; }
        //public string Ext { get; set; }
        //public Guid ParentId { get; set; }
        public long Size { get; set; }
        /// <summary>
        /// this should be called by EF only
        /// </summary>
        public FileUpload(){}
        //public FileUpload(System.Web.HttpPostedFile file): base()
        //{
        //    if (file == null) { return; }
        //    this.FileName = Path.GetFileName(file.FileName);
        //    this.Ext = Path.GetExtension(this.FileName);
        //    this.Content = FileHelper.GetContent(file);
        //    this.ContentType = file.ContentType;
        //    this.Size = file.ContentLength;
        //}

        public FileUpload(string fileName, string contentType, long fileSize, byte[] content)
        {
            this.FileName = fileName;
            this.ContentType = contentType;
            this.Size = fileSize;
            this.Content = content;
        }

        //public FileUpload(FileUploadInfo file)
        //{
        //    if (file == null) { return; }
        //    this.FileName = Path.GetFileName(file.Name);
        //    this.Ext = Path.GetExtension(this.FileName);
        //    this.Content = Encoding.Default.GetString(file.Content);
        //    this.ContentType = file.ContentType;
        //    this.Size = file.Length;
        //}
    }
}
