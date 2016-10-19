namespace App.Common.Ftp
{
    public class FTPFolderUploadRequest : FTPRequest
    {
        public FTPFolderUploadRequest(string folder, string server, string userName, string pwd, string basePath, string baseLocalPath): 
            base(server, userName, pwd, basePath, baseLocalPath)
        {
            this.FolderToUpload = folder;
        }
        public string FolderToUpload { get; set; }
    }
}
