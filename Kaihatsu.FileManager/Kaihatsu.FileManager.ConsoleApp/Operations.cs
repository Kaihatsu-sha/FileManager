using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.FileManager.ConsoleApp
{
    internal class Operations
    {
        internal delegate string MyDelegate(int age);
        MyDelegate _delegate;
        public Operations()
        {
            string[] massivNames = new string[] { "Jix", "Dgjn", "Anna" };

            var rezult = massivNames.Where(t => t.ToUpper().StartsWith("J")).FirstOrDefault();
            Action<int> action = (int age) => Console.WriteLine(age);
            Func<int, string> func = delegate (int age) { return ""; };
            Predicate<int> predicate = (int age) => { return age > 10 ? true : false; };
            _delegate = delegate (int ages) { return "" + ages; };
            _delegate.Invoke(5);

            //massivNames.Select(t => { Console.WriteLine(t); return true; });
            List<User> users = new List<User>
            {
                new User {Name="Том", Age=23, Languages = new List<string> {"английский", "немецкий" }},
                new User {Name="Боб", Age=27, Languages = new List<string> {"английский", "французский" }},
                new User {Name="Джон", Age=29, Languages = new List<string> {"английский", "испанский" }},
                new User {Name="Элис", Age=24, Languages = new List<string> {"испанский", "немецкий" }}
            };

            //var rezultUser = users.Where(
            //    u => u.Age < 40 &&
            //    u.Languages.Exists(
            //        l => l.Contains("немецкий")) // && l.Contains("английский")
            //    );
            //var items = users.Select(u => new User
            //    {
            //        Name = u.Name,
            //        Age = u.Age,
            //        Languages = u.Languages.Where(l => l.Contains("немецкий") && !l.Contains("английский")).ToList()
            //    } 
            //    );
            //rezultUser = rezultUser.Where(u => u.Languages.Exists(match => !match.Contains("английский") ));

            //var rezultUserD = users
            //    .SelectMany(u => u.Languages, (u, l) => new { Useris = u, Lang = l })
            //    .Where(u => u.Useris.Age < 40 && u.Lang.Contains("немецкий"))
            //    .Select(u => u.Useris);
            //var rezultUserNotE = users
            //    .SelectMany(u => u.Languages, (u, l) => new { Useris = u, Lang = l })
            //    .Where(u => u.Useris.Age < 40 && !u.Lang.Contains("английский"))
            //    .Select(u => u.Useris);
            //rezultUser.ToList().ForEach(u => Console.WriteLine(u.Useris.Name + u.Lang));

            //var rezultD = users.Where(u => u.Languages.Contains("немецкий"));
            //var rezultE = users.Where(u => !u.Languages.Contains("английский")).ToList();

            //var rezultE = users.Where(u => u.Languages.Contains("английский")).Where(u => u.Languages.Contains("испанский")).ToList();
            //var rezultE = users.Where(u => u.Languages.Contains("немецкий")).Where(u => u.Languages.Contains("испанский")).ToList();
            //var rezultI = users.Where(u => u.Languages.Contains("испанский")).ToList();

            //var rezultUser = users.OrderBy(u => u.Age);
            var rezultUser = users.OrderByDescending(u => u.Name).ThenBy(u => u.Age);

            rezultUser.ToList().ForEach(u => Console.WriteLine(u.Name));




            string[] names = new string[] { "David", "Jon", "Ariy", "Sansa" };

            //var chuked = names
            //    .Select((x, i) => new { Index = i, Value = x })//Anonymos Type
            //    .GroupBy(x => x.Index / 2)
            //    .Select(x => x.Select(v => v.Value)).ToList();

            var chunked = names.Chunk(2);
            var chinked2 = names.Chunk(2).ToList();
            Console.ReadKey();
        }

        IEnumerable<IEnumerable<T>> ChunkBy<T>(IEnumerable<T> source, int size)
        {
            return source.Select((x, i) => new { Index = i, Value = x })//Anonymos Type
                .GroupBy(x => x.Index / size)
                .Select(x => x.Select(v => v.Value));
        }
    }

    class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<string> Languages { get; set; }
        public User()
        {
            Languages = new List<string>();
        }
    }
}
