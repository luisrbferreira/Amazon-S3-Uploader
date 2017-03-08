using System.IO;

namespace AmazonS3Uploader
{
    public static class Delegates
    {
        public delegate void ShowTextDelegate(string text);
        public delegate void Upload_ExclusaoDelegate(string subFolder, string fileName, string filePath, WatcherChangeTypes type);
        public delegate void RenomeacaoDelegate(string oldName, string subFolder, string fileName, string filePath, WatcherChangeTypes type);
    }
}