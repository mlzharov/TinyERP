namespace App.Common.Ftp
{
    public class FTPFileUploadRequest : FTPRequest
    {
        public FTPFileUploadRequest(string filePath, string baseFolder, FTPRequest uploadRequest)
            : base(uploadRequest)
        {
            this.FilePath = filePath;
            this.BaseFolder = baseFolder;
        }
        public string FilePath { get; set; }
        public string BaseFolder { get; set; }
    }
}
