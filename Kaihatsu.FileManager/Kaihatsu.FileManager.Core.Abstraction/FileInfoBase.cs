namespace Kaihatsu.FileManager.Core.Abstraction
{
    public  class FileInfoBase
    {
        public string FullPath { get; private set; }
        public string Name { get; private set; }
        public byte Type { get; private set; }
        public float Size { get; private set; }
        
        //Создан
        //Изменен

        public FileInfoBase(string path)
        {
            FileSystemInfo info = null;
            if (Directory.Exists(path))
            {
                info = new DirectoryInfo(path);
                Type = 0;
                Size = 0;
            }
            if (File.Exists(path))
            {
                info = new FileInfo(path);
                Type = 1;
                Size = ((FileInfo)info).Length / (1024);
            }
            
            FullPath = info.FullName;
            Name = info.Name;
            //Extension = path.Extension;
        }

        public void Delete()
        {
            //FileSystemInfo file = new FileSystemInfo(FullPath);
            //file.Delete();
        }
    }
}