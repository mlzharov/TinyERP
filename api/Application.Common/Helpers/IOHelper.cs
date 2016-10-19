using System.IO;
using App.Common.Configurations;

namespace App.Common.Helpers
{
    public class IOHelper
    {
        //public static string GetFullPath(string relativePath)
        //{
        //    return Path.Combine(Configuration.Current.Folders.Root, relativePath);
        //}

        public static void CreateFolderIfNotExist(string fullFolderPath)
        {
            if (Directory.Exists(fullFolderPath))
            {
                return;
            }
            Directory.CreateDirectory(fullFolderPath);
        }

        //public static bool IsFullPath(string folderPath)
        //{
        //    return folderPath.ToLower().StartsWith(Configuration.Current.Folders.Root.ToLower());
        //}

        public static MemoryStream CopyFileToMemoryStream(string filePath)
        {
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            MemoryStream ms = new MemoryStream();
            fs.CopyTo(ms);
            return ms;
        }
    }
}
