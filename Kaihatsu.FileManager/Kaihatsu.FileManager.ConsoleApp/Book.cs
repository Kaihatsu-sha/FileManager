using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.FileManager.ConsoleApp
{
    internal class Book
    {
        private void Chrter9()
        {
            Func<string, int> anonim;
            anonim = delegate(string stroka){ return stroka.Length; };//Анонимный метод
            anonim = (string stroka) => { return stroka.Length; };//Лямбда выражение
            anonim = (string stroka) => stroka.Length;//Лямбда выражение Одиночное выражение,
                                                      //значение которого  представляет собой результат Лямбда выражение
            anonim = (stroka) => stroka.Length;//Не явно типизированное лямбдо выражение
            anonim = stroka => stroka.Length;//Только для одного и с возможностью неявной типизиции!!!
            anonim = (stroks => stroks.Length);
            int strokaLenght = 0;
            Action<string> action = delegate (string stroka) { strokaLenght = stroka.Length; };

            _ = anonim ?? throw new ArgumentNullException();

            if(anonim is null)
            { }

            if(anonim is object)
            { }

            if (anonim is { })
            {
                
            }
            Book valueBook = null;
            valueBook ??= new Book();
            if(valueBook is null)//Аналогично, что выше
            {
                valueBook = new Book();
            }
        }

        internal void Charter921()
        {
            var films = new List<Film>
            {
                new Film{ Name = "Зомбицид", Year = 1999},
                new Film{ Name = "Однажды в голливуде", Year = 1952},
                new Film{ Name = "Карты деньги два ствола", Year = 1968},
                new Film{ Name = "Большой куш", Year = 1991},
                new Film{ Name = "Джонни", Year = 1988},
                new Film{ Name = "Мачете", Year = 1951},
            };

            Action<Film> outToConsole =
                film => Console.WriteLine($"Название: {film.Name} год выпуска: {film.Year}");

            films.ForEach(outToConsole);

            Console.WriteLine(Environment.NewLine);
            films.FindAll(item => item.Year>= 1960)
                .ForEach(outToConsole);

            Console.WriteLine(Environment.NewLine);
            films.Sort((item1, item2) => item1.Year.CompareTo(item2.Year));
            films.ForEach(outToConsole);

        }

        internal void Log(string title, object sender, EventArgs e)
        {

        }

        internal void ExpressionExample()
        {
            Expression firstArg = Expression.Constant(2);
            Expression secondArg = Expression.Constant(3);
            Expression add = Expression.Add(firstArg, secondArg);


            Func<int> expressionLambda = Expression.Lambda<Func<int>>(add).Compile();

            Expression<Func<int> > return5 = () =>5;
            Func<int> return5Func = return5.Compile();


            Expression<Func<string, string, bool>> expression1 = (x, y) => x.StartsWith(y);
        }
    }

    internal class Film
    {
        public string Name { get; set; }
        public int Year { get; set; }
    }
}
