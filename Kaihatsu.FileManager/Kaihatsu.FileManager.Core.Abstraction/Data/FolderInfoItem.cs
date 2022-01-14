using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Immutable;

namespace Kaihatsu.FileManager.Core.Abstraction.Data
{
    public class FolderInfoItem : ItemBase
    {
        public FolderInfoItem(string path, bool calculateSize = true)
        {
            if (!Directory.Exists(path))
            {
                throw new ArgumentException("Не определен тип");
            }

            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            Type = ItemType.Folder;
            CreationTime = directoryInfo.CreationTime.ToString();
            LastWriteTime = directoryInfo.LastWriteTime.ToString();
            Path = directoryInfo.FullName;
            Name = directoryInfo.Name;

            Parent = null;

            if (calculateSize)
            {
                Parent = directoryInfo?.Parent is not null ? new FolderInfoItem(directoryInfo.Parent.FullName, false) : null;

                CalculateSize();
            }            
        }

        public int FoldersCount { get; protected set; }
        public int FilesCount { get; protected set; }
        public bool IsLoadet { get; protected set; } = false;
        public FolderInfoItem Parent { get; protected set; }


        public async void CalculateSize()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(Path);
            
            Size = await CalculateSizeAsync(directoryInfo);
            FoldersCount = await CalculateFoldersCount(directoryInfo);
            FilesCount = await CalculateFilesCount(directoryInfo);

            IsLoadet = true;
        }

        private Task<long> CalculateSizeAsync(DirectoryInfo directoryInfo)//TODO : Exceptions
        {
            return Task.Run(
                () =>
                {
                    long size = 0;
                    try
                    {
                        directoryInfo
                            .GetFiles("", SearchOption.AllDirectories)
                            .ToList()
                            .ForEach(fileInfo => { size += fileInfo.Length; });
                        
                    }
                    catch (UnauthorizedAccessException ex)
                    {
                        //TODO : UnauthorizedAccessException
                    }

                    return size;

                });
        }

        private Task<int> CalculateFoldersCount(DirectoryInfo directoryInfo)
        {
            return Task.Run(
                ()=>
                {
                    int foldersCount = 0;
                    try
                    {
                        foldersCount = directoryInfo
                            .GetDirectories("", SearchOption.AllDirectories)
                            .Count();
                    }
                    catch (UnauthorizedAccessException ex)
                    {
                        //TODO : UnauthorizedAccessException
                    }

                    return foldersCount;
                });
        }

        private Task<int> CalculateFilesCount(DirectoryInfo directoryInfo)
        {
            return Task.Run(
                () =>
                {
                    int filesCount = 0;
                    try
                    {
                        filesCount = directoryInfo
                            .GetFiles("", SearchOption.AllDirectories)
                            .Count();
                    }
                    catch (UnauthorizedAccessException ex)
                    {
                        //TODO : UnauthorizedAccessException
                    }

                    return filesCount;
                });
        }
    }
}
