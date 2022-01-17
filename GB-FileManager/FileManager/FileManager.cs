using System;
using System.IO;

namespace FileManager
{
    public class Manager
    {
        //Выводит "родителя" ... для перехода на уровень выше.
        public (string name, string path) GetParent(string path)
        {
            if (!Directory.Exists(path))
            {
                throw new System.IO.DirectoryNotFoundException("Каталог не существует.");
            }

            DirectoryInfo directoryParent = new DirectoryInfo(path).Parent;
            if (directoryParent != null)
            {
                return ("...", directoryParent.FullName);
            }
            else
            {
                return ("root", new DirectoryInfo(path).Root.ToString());
            }
        }
        
        //Возвращает имена файлов и папок вместе в путями по указнному пути
        public (string[] names, string[] paths) AllItemsFromPath(string path)
        {
            FileSystemInfo sysInfo = new DirectoryInfo(path);
            
            if ((sysInfo.Attributes & FileAttributes.Directory) == FileAttributes.Directory)//Папка
            {
                int i = 0;
                int lengthDir = Directory.GetDirectories(path).Length;
                int lengthFiles = Directory.GetFiles(path).Length;

                string[] names = new string[lengthDir + lengthFiles];
                string[] paths = new string[lengthDir + lengthFiles];

                foreach (string dir in Directory.GetDirectories(path))
                {
                    DirectoryInfo directory = new DirectoryInfo(dir);
                    names[i] = directory.Name + "/";
                    paths[i] = directory.FullName;

                    i++;
                }

                foreach (string dir in Directory.GetFiles(path))
                {
                    FileInfo directory = new FileInfo(dir);
                    names[i] = directory.Name;
                    paths[i] = directory.FullName;

                    i++;
                }


                return (names, paths);
            }

            return (null, null);//передали файл
        }

        //Возвращает дополнительные атрибуты в зависимости от типа
        public string GetInfo(string path)
        {
            string response = "";
            FileSystemInfo sysInfo = new DirectoryInfo(path);            

            if ((sysInfo.Attributes & FileAttributes.Directory) == FileAttributes.Directory)
            {
                DirectoryInfo dir = new DirectoryInfo(path);
                
                if (!dir.Exists)
                {
                    throw new System.IO.DirectoryNotFoundException("Каталог не существует.");
                }
                response = $"Полный путь: {dir.FullName}\nАтрибур: {dir.Attributes}\nДата создания: {dir.CreationTime}\nПоследние изменения: {dir.LastWriteTime.ToShortDateString()}\n";
            }
            else
            {
                FileInfo file = new FileInfo(path);
                if (!file.Exists)
                {
                    throw new System.IO.FileNotFoundException("Файл не существует.");
                }
                response = $"Полный путь: {file.FullName}\nАтрибур: {file.Attributes}\nДата создания: {file.CreationTime}\nПоследние изменения: {file.LastWriteTime.ToShortDateString()}\nВес в байтах: {file.Length}\n";

            }
            return response;
        }

        //Удаление файла/папки
        public void Delete(string path)
        {
            FileSystemInfo sysInfo = new DirectoryInfo(path);

            if ((sysInfo.Attributes & FileAttributes.Directory) == FileAttributes.Directory)
            {
                DirectoryInfo dir = new DirectoryInfo(path);
                if (!dir.Exists)
                {
                    throw new System.IO.DirectoryNotFoundException("Каталог не существует.");
                }
                dir.Delete(true);
            }
            else
            {
                FileInfo file = new FileInfo(path);
                if (!file.Exists)
                {
                    throw new System.IO.FileNotFoundException("Файл не существует.");
                }
                file.Delete();
            }
        }
        //Копирование файла/папки
        public void Copy(string pathSource, string pathTarget)
        {
            FileSystemInfo sysInfo = new DirectoryInfo(pathSource);

            //Создать пусть есть нет
            if ((sysInfo.Attributes & FileAttributes.Directory) == FileAttributes.Directory)
            {
                DirectoryInfo dirS = new DirectoryInfo(pathSource);
                DirectoryInfo dirT = new DirectoryInfo(pathTarget);

                if (!dirS.Exists)
                {
                    throw new System.IO.DirectoryNotFoundException("Каталог не существует.");
                }

                if (!dirT.Exists)
                {
                    dirT.Create();
                }

                DirectoryInfo[] dirs = dirS.GetDirectories();

                FileInfo[] files = dirS.GetFiles();
                foreach (FileInfo file in files)
                {
                    string tempPath = Path.Combine(pathTarget, file.Name);
                    file.CopyTo(tempPath, false);
                }

                foreach (DirectoryInfo subdir in dirs)
                {
                    string tempPath = Path.Combine(pathTarget, subdir.Name);
                    Copy(subdir.FullName, tempPath);
                }
            }
            else
            {
                FileInfo fileS = new FileInfo(pathSource);
                FileInfo fileT = new FileInfo(pathSource);

                if (!fileS.Exists)
                {
                    throw new System.IO.FileNotFoundException("Файл не существует.");
                }

                if (fileT.Exists)
                {
                    throw new Exception("Файл уже существует.");
                }

                fileS.CopyTo(pathTarget);
            }
        }
    }
}