using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManager;

namespace UI
{
    //Класс отвечающих за вывод информации на консоль
    class OutToConsole
    {
        readonly Manager _manager;
        readonly Logger _logger;
        readonly Configuration<OutToConsoleConfig> _confEngine;
        readonly int _depthLevel;

        int _indexSelectedItem;
        int _indexItem;
        int _selectedPage;
        int _outItems;
        int _skip;
        OutToConsoleConfig _config;

        bool _isWork = true;
        List<string> _paths;

        int SelectedItem
        {
            get { return _indexSelectedItem; }
            set
            {
                if (value != 0 && value >= _indexItem)
                {
                    _indexSelectedItem = 0;
                }
                else if (value < 0)
                {
                    _indexSelectedItem = --_indexItem;
                }
                else
                {
                    _indexSelectedItem = value;
                }
            }
        }

        int SelectedPage
        {
            get { return _selectedPage; }
            set
            {
                if (value < 0)
                {
                    _selectedPage = 0;
                }
                else
                {
                    _selectedPage = value;
                }
            }
        }

        public OutToConsole(ref Logger logger, ref Configuration<OutToConsoleConfig> confEngine, ref Manager manager)
        {
            _manager = manager;
            _logger = logger;
            _confEngine = confEngine;

            _config = new OutToConsoleConfig();
            _confEngine.Load(ref _config);

            _depthLevel = _config.DepthLevel;
            _indexItem = 0;
            SelectedItem = 0;
            SelectedPage = 0;
            _outItems = _config.PageSize;
            _paths = new List<string>();
            _skip = 0;

            Start(_config.CurrentDirectory);
        }

        //Метод запуска отображения структуры, информации, и меню.
        public void Start(string path)
        {
            try
            {
                Console.Clear();
                SelectedItem = 0;
                SelectedPage = 0;
                _skip = 0;
                _config.CurrentDirectory = path;
                while (_isWork)
                {
                    _indexItem = 0;
                    _outItems = _config.PageSize; ;
                    _paths.Clear();
                    Console.CursorVisible = false;

                    PrintItems(path, _depthLevel, "", true);
                    PrintAttributes();
                    ConsoleKeyInfo keyInfo = Console.ReadKey();

                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.UpArrow:
                            SelectedItem--;
                            break;
                        case ConsoleKey.DownArrow:
                            SelectedItem++;
                            break;
                        case ConsoleKey.PageUp:
                            SelectedPage--;
                            _outItems = _config.PageSize; ;
                            _skip = SelectedPage * _config.PageSize; ;
                            break;
                        case ConsoleKey.PageDown:
                            SelectedPage++;
                            _outItems = _config.PageSize; ;
                            _skip = SelectedPage * _config.PageSize; ;
                            break;
                        case ConsoleKey.Enter:
                            Console.Clear();
                            Start(_paths[SelectedItem]);
                            break;
                        default:
                            Commands();
                            break;
                    }

                    Console.Clear();
                }
            }
            catch (Exception ex)
            {
                _logger.Write("Exception.txt", "Start: " + ex.Message);
            }
        }

        //Рекурсивно отображает данные по странично
        public void PrintItems(string path, int depthLeve, string margin, bool addParent = false)
        {
            if (addParent)//Добавление "..."
            {
                (string name, string pathP) = _manager.GetParent(path);
                _paths.Add(pathP);
                PrintInfo(name, margin);
            }

            if (depthLeve == 0)
            {
                return;
            }

            (string[] names, string[] paths) = _manager.AllItemsFromPath(path);

            if (names == null)//Передали файл
            {
                return;
            }

            for (int i = 0; i < names.Length; i++)
            {
                if (_outItems == 0)//Ограничение на вывод
                {
                    return;
                }

                if (_skip == 0 && _outItems != 0)//Выводить по размеру страницы
                {
                    _paths.Add(paths[i]);
                    PrintInfo(names[i], margin);
                    _outItems--;
                }

                if (_skip != 0)//Пропускать 
                {
                    _skip--;
                }

                if (depthLeve != 1)//На уроверь ниже
                {
                    PrintItems(paths[i], depthLeve - 1, margin + "-");
                }

            }

        }

        //Вывод данных и подсветка курсора
        void PrintInfo(string name, string margin)
        {
            if (_indexItem == SelectedItem)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;

                Console.Write($"{margin} {name}" + Environment.NewLine);
            }
            else
            {
                Console.Write($"{margin} {name}" + Environment.NewLine);
            }
            Console.ResetColor();


            _indexItem++;
        }

        //Вывод дополнительной информации по файлу/папке
        void PrintAttributes()
        {
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("=");
            }
            Console.Write(Environment.NewLine);

            try
            {
                Console.Write(_manager.GetInfo(_paths[SelectedItem]));
            }
            catch (Exception ex)
            {
                _logger.Write("Exception.txt", "PrintAttributes: " + ex.Message);
            }

            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("=");
            }
        }
        
        //Метод распознает команды и запускает обработку
        void Commands()
        {
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.Write(">");
            Console.SetCursorPosition(1, Console.CursorTop);

            Console.CursorVisible = true;
            string inputCommandLine = Console.ReadLine();

            string command = inputCommandLine.Split(" ")[0];

            switch (command.ToLower())
            {
                case "cp":
                    string pathSource = inputCommandLine.Split("\"")[1];
                    pathSource = pathSource.Trim('\"');
                    string pathTarget = inputCommandLine.Split("\"")[3];
                    pathTarget = pathTarget.Trim('\"');

                    _manager.Copy(pathSource, pathTarget);
                    break;
                case "rm":
                    string path = inputCommandLine.Split("\"")[1];
                    path = path.Trim('\"');

                    _manager.Delete(path);
                    break;
                case "q":
                    _isWork = false;
                    _confEngine.Save(ref _config);
                    return;
                case "main":
                    return;
                case "help":
                    Console.WriteLine("Помощь по коммандам:");
                    Console.WriteLine("cp \"файл/директория источник\" \"файл/директория целевая\" - копирование файлов и директорий");
                    Console.WriteLine("rm \"файл/директория источник\" - удаление файлов и директорий");
                    Console.WriteLine("q  - выход из приложения");
                    Console.WriteLine("main  - выход из режима ввода команд");
                    Console.WriteLine("help - помощь по коммандам");
                    Commands();
                    break;
                default:
                    Console.WriteLine("Команда не распознана, используйте команду HELP для помощи");
                    Commands();
                    break;
            }

        }

    }
}
