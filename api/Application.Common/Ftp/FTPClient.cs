using App.Common.Helpers;
using System.IO;
using System.Net;
using System.Text;
namespace App.Common.Ftp
{
    public class FTPClient
    {
        public FTPRequest FTPRequest { get; set; }
        public FTPClient(FTPRequest request)
        {
            this.FTPRequest = request;
        }
        public void UploadFile(string filePath)
        {
            string fileRelativePath = FileHelper.GetRelativeFilePath(filePath, this.FTPRequest.LocalFolder);
            fileRelativePath = fileRelativePath.Replace("\\", "/");

            string ftpPath = string.Format("{0}{1}{2}", this.FTPRequest.Server, this.FTPRequest.BasePath, fileRelativePath);
            string subDir = Path.GetDirectoryName(fileRelativePath);
            if (!string.IsNullOrWhiteSpace(subDir) && !this.Exists(subDir, FTPResourceType.Directory))
            {
                this.CreateFolder(subDir);
            }

            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpPath);
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential(this.FTPRequest.UserName, this.FTPRequest.Pwd);
            StreamReader sourceStream = new StreamReader(filePath);
            byte[] fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
            sourceStream.Close();

            request.ContentLength = fileContents.Length;

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(fileContents, 0, fileContents.Length);
            requestStream.Close();

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            System.Console.WriteLine("'{0}' was uploaded completely, status {1}", fileRelativePath, response.StatusDescription);
            response.Close();
            response.Dispose();
        }

        private bool Exists(string path, FTPResourceType type)
        {
            try
            {
                string ftpPath = string.Format("{0}{1}{2}", this.FTPRequest.Server, this.FTPRequest.BasePath, path);
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpPath);
                request.Method = type == FTPResourceType.Directory ? WebRequestMethods.Ftp.ListDirectoryDetails : WebRequestMethods.Ftp.GetFileSize;
                request.Credentials = new NetworkCredential(this.FTPRequest.UserName, this.FTPRequest.Pwd);
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                response.Close();
                response.Dispose();
            }
            catch (WebException ex)
            {
                return false;
            }
            return true;
        }

        private void CreateFolder(string path)
        {
            string[] pathItems = path.Split('\\', '/');
            string basePath = string.Empty;
            foreach (string pathItem in pathItems)
            {
                basePath = Path.Combine(basePath, pathItem);
                if (Exists(basePath, FTPResourceType.Directory)) { continue; }
                string ftpPath = GetServerPath(basePath);
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpPath);
                request.Method = WebRequestMethods.Ftp.MakeDirectory;
                request.Credentials = new NetworkCredential(this.FTPRequest.UserName, this.FTPRequest.Pwd);
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                response.Close();
                response.Dispose();
            }
        }

        private string GetServerPath(string path)
        {
            string pathOnServer = string.Format("{0}{1}{2}", this.FTPRequest.Server, this.FTPRequest.BasePath, path);
            return pathOnServer.Replace("\\", "/");
        }
    }
}
