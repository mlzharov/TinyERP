namespace App.Common.Ftp
{
    public class FTPRequest
    {
        public FTPRequest(string server, string userName, string pwd, string basePath, string localFolder)
        {
            this.Server = server;
            this.UserName = userName;
            this.Pwd = pwd;
            this.BasePath = basePath;
            this.LocalFolder = localFolder;
        }
        public FTPRequest(FTPRequest request)
        {
            this.Server = request.Server;
            this.UserName = request.UserName;
            this.Pwd = request.Pwd;
            this.BasePath = request.BasePath;
            this.LocalFolder = request.LocalFolder;
        }
        public string LocalFolder { get; set; }
        public string Server { get; set; }
        public string UserName { get; set; }
        public string Pwd { get; set; }
        public string BasePath { get; set; }
    }
}
