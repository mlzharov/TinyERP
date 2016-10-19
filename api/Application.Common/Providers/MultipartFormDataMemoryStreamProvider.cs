using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace App.Common.Providers
{
    public class MultipartFormDataMemoryStreamProvider : MultipartMemoryStreamProvider
    {
        public class FileInfo
        {
            public Byte[] Content { get; set; }
            public string ContentType { get; internal set; }
            public string FileName { get; set; }
            public long FileSize { get; internal set; }
            public FileInfo()
            {
                this.ContentType = FileContentType.Png;
                this.FileSize = 0;
            }
        }

        private readonly Collection<bool> isFormData = new Collection<bool>();
        private readonly NameValueCollection formData = new NameValueCollection(StringComparer.OrdinalIgnoreCase);
        private readonly List<FileInfo> fileData = new List<FileInfo>();

        public NameValueCollection FormData
        {
            get { return formData; }
        }

        public List<FileInfo> FileData
        {
            get { return fileData; }
        }

        public override Stream GetStream(HttpContent parent, HttpContentHeaders headers)
        {
            if (null == parent)
            {
                throw new ArgumentNullException("parent");
            }

            if (null == headers)
            {
                throw new ArgumentNullException("headers");
            }

            ContentDispositionHeaderValue contentDisposition = headers.ContentDisposition;
            if (null == contentDisposition)
            {
                throw new InvalidOperationException("Did not find required 'Content-Disposition' header field in MIME multipart body part.");
            }

            isFormData.Add(String.IsNullOrEmpty(contentDisposition.FileName));
            return base.GetStream(parent, headers);
        }

        public override async Task ExecutePostProcessingAsync()
        {
            for (int index = 0; index < Contents.Count; ++index)
            {
                HttpContent formContent = Contents[index];
                if (isFormData[index])
                {
                    // Field
                    string formFieldName = UnquoteToken(formContent.Headers.ContentDisposition.Name) ?? string.Empty;
                    string formFieldValue = await formContent.ReadAsStringAsync();
                    FormData.Add(formFieldName, formFieldValue);
                }
                else
                {
                    // File
                    FileInfo fileInfo = new FileInfo();
                    fileInfo.FileName = UnquoteToken(formContent.Headers.ContentDisposition.FileName);
                    fileInfo.Content = await formContent.ReadAsByteArrayAsync();
                    fileInfo.FileSize = (long)formContent.Headers.ContentLength;
                    fileInfo.ContentType = formContent.Headers.ContentType.MediaType;

                    FileData.Add(fileInfo);
                }
            }
        }

        private static string UnquoteToken(string token)
        {
            if (true == String.IsNullOrWhiteSpace(token))
            {
                return token;
            }

            if ((true == token.StartsWith("\"", StringComparison.Ordinal))
                && (true == token.EndsWith("\"", StringComparison.Ordinal))
                && (token.Length > 1))
            {
                return token.Substring(1, token.Length - 2);
            }

            return token;
        }
    }
}

//using App.Common.Validation;
//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.IO;
//using System.Net.Http;
//using System.Net.Http.Headers;
//using System.Threading.Tasks;

//namespace App.Common.Providers
//{
//    public class FileUploadInfo
//    {
//        public byte[] Content { get; protected set; }
//        public string Name { get; protected set; }
//        public int Length { get; set; }
//        public string ContentType { get; set; }

//        public FileUploadInfo(string name, byte[] content, string contentType, int length)
//        {
//            this.Name = name;
//            this.Content = content;
//            this.ContentType = contentType;
//            this.Length = length;
//        }
//    }
//    public class MultipartFormDataMemoryStreamProvider : System.Net.Http.MultipartMemoryStreamProvider
//    {
//        public MultipartFormDataMemoryStreamProvider() : base()
//        {
//            this.Files = new List<FileUploadInfo>();
//        }
//        private readonly Collection<bool> isFormData = new Collection<bool>();
//        public IList<FileUploadInfo> Files { get; protected set; }

//        public override Stream GetStream(HttpContent content, HttpContentHeaders headers)
//        {
//            if (content == null || headers == null || headers.ContentDisposition == null)
//            {
//                throw new ValidationException("common.errors.invlaidFileUploadRequest");
//            }
//            this.Files.Add(GetFileUploadInfo(content, headers));
//            return base.GetStream(content, headers);
//        }
//        private FileUploadInfo GetFileUploadInfo(HttpContent contentItem, HttpContentHeaders headers)
//        {
//            string contentType = headers.ContentType.ToString();
//            string fileName = UnquoteToken(headers.ContentDisposition.FileName);
//            byte[] fileContent = contentItem.ReadAsByteArrayAsync().Result;
//            int contentLength = (int)contentItem.Headers.ContentLength;
//            return new FileUploadInfo(fileName, fileContent, contentType, contentLength);
//        }

//        private static string UnquoteToken(string token)
//        {
//            if (true == String.IsNullOrWhiteSpace(token))
//            {
//                return token;
//            }

//            if ((true == token.StartsWith("\"", StringComparison.Ordinal))
//                && (true == token.EndsWith("\"", StringComparison.Ordinal))
//                && (token.Length > 1))
//            {
//                return token.Substring(1, token.Length - 2);
//            }

//            return token;
//        }
//    }
//}
