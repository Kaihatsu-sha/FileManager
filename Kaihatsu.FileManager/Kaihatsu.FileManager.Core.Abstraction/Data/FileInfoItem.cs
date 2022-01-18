using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.FileManager.Core.Abstraction.Data
{
    public class FileInfoItem : ItemBase
    {
        public FileInfoItem(string path)
        {
            if (!File.Exists(path))
            {
                throw new ArgumentException("Не определен тип");
            }

            FileInfo fileInfo = new FileInfo(path);
            Type = ItemType.File;
            Size = fileInfo.Length;
            CreationTime = fileInfo.CreationTime.ToString();
            LastWriteTime = fileInfo.LastWriteTime.ToString();
            Path = fileInfo.FullName;
            Name = fileInfo.Name;

            if(fileInfo.Extension == ".txt")
            {
                CalculateProperties();
                IsLoadProperty = true;
            }
        }

        public bool IsLoadProperty { get; protected set; } = false;
        public int WordCount { get; protected set; }//кол-во слов
        public int LineCount { get; protected set; }// кол-во строк
        public int ParagraphCount { get; protected set; }//кол-во абзацев
        public int CharactersCount { get; protected set; }//кол-во символов с пробелами
        public int CharactersWithoutSpacesCount { get; protected set; }

        public async void CalculateSize()
        {
            CalculateProperties();

            IsLoadProperty = true;
        }

        private async void CalculateProperties()
        {
            FileInfo fileInfo = new FileInfo(Path);

            using (StreamReader streamReader = fileInfo.OpenText())
            {
                //bool lastCharIsSpace = true;
                while (!streamReader.EndOfStream)
                {
                    int length = (int)streamReader.BaseStream.Length;//1024
                    char[] buffer = new char[length];
                    await streamReader.ReadBlockAsync(buffer, 0, length);
                    //Без пробелов и символов перевода строки
                    CharactersWithoutSpacesCount += buffer
                        .Where(item => { return item != ' ' && item != '\n' && item != '\r' && item != '\0'; })
                        .Count();
                    //Без символов перевода строки
                    CharactersCount += buffer
                        .Where(item => item != '\n' && item != '\r' && item != '\0')
                        .Count();


                    string line = new string(buffer).TrimEnd('\0');

                    string[] paragraph = line.Split(new char[] { '\u00B6' });
                    ParagraphCount += paragraph.Count();

                    string[] lines = line.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    LineCount += lines.Count();

                    string[] words = line.Split(new char[] { ' ', '\r', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    WordCount += words.Count();

                    //Проверка: не разрезали ли мы слово/число
                    //if (!lastCharIsSpace)
                    //{
                    //    WordCount--;
                    //    LineCount--;
                    //}

                    //char lastChar = buffer[line.Length - 1];
                    //lastCharIsSpace = char.IsWhiteSpace(lastChar);

                    //    //	 U+00B6 - абзац
                    //    // U+000A - новая линия
                    //    //"\r\n" - символ перевода каретки и символ новой строки вместе
                    //    //"\t" - символ табуляции, который как правило используется для отступа абзацев
                    //    //"\r\n\t" - новый абзац скорее всего будет идти после такой последовательности
                }
            }

        }

    }
}
