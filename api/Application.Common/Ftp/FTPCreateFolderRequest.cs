namespace App.Common.Ftp
{
    public class FTPCreateFolderRequest : FTPRequest
    {
        public FTPCreateFolderRequest(string subDir, FTPRequest request): base(request)
        {
            this.SubDir = subDir;
        }
        public string SubDir { get; set; }
    }
}
