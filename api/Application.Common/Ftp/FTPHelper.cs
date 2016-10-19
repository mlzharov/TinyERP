using System.IO;
namespace App.Common.Ftp
{
    public class FTPHelper
    {
        /// <summary>
        /// Should add retries options, exclude files, include files, multiple thread
        /// </summary>
        /// <param name="request"></param>
        public static void UploadFolder(FTPFolderUploadRequest request)
        {
            string[] files = Directory.GetFiles(request.LocalFolder, "*", SearchOption.AllDirectories);

            FTPClient ftp = new FTPClient(request);
            foreach (string fileName in files)
            {
                ftp.UploadFile(fileName);
            }
        }
    }
}
