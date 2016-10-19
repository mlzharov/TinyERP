using App.Common.Data;
using App.Common.Mapping;
using App.Entity.Common;
using System;

namespace App.Service.Common
{
    public class FileUploadPreview : BaseEntity, IMappedFrom<FileUpload>
    {
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public string Ext { get; set; }
        public Guid ParentId { get; set; }
        public long Size { get; set; }
    }
}
