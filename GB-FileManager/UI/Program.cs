using System;
using FileManager;

namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {   
            Manager manager = new Manager();
            Logger logger = new Logger();
            Configuration<OutToConsoleConfig> config = new Configuration<OutToConsoleConfig>("configuration.json");

            OutToConsole toConsole = new OutToConsole(ref logger, ref config, ref manager);
        }
    }
}
