namespace Kaihatsu.FileManager.Core.Abstraction
{
    public  class FileInfoBase
    {
        public string FullPath { get; private set; }
        public string Name { get; private set; }
        public FileType Type { get; private set; }

        /// <summary>
        /// Return size in Kbytes
        /// </summary>
        public float Size { get; private set; }
        public string CreationTime { get; private set; }
        public string LastWriteTime { get; private set; }

        public FileInfoBase(string path)
        {
            if (Directory.Exists(path))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(path);
                Type = FileType.Folder;
                Size = 0;
                CreationTime = directoryInfo.CreationTime.ToString();
                LastWriteTime = directoryInfo.LastWriteTime.ToString();
                FullPath = directoryInfo.FullName;
                Name = directoryInfo.Name;
            }
            else if (File.Exists(path))
            {
                FileInfo fileInfo = new FileInfo(path);
                Type = FileType.File;
                Size = fileInfo.Length / (1024);
                CreationTime = fileInfo.CreationTime.ToString();
                LastWriteTime = fileInfo.LastWriteTime.ToString();
                FullPath = fileInfo.FullName;
                Name = fileInfo.Name;
            } 
            else
            {
                throw new ArgumentException("Не определен тип");
            }
        }
    }
}