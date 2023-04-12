using System;
using Lesson4e21;

namespace Lesson4
{
    internal class Program
    {
        public static void Main()
        {
            var a = new Persondawf();
            Console.WriteLine($"Объект 'a': Id = {a.Id}, Name = {a.Name}");

            var b = new Persondawf(1);
            Console.WriteLine($"Объект 'b': Id = {b.Id}, Name = {b.Name}");

            var c = new Persondawf("name");
            Console.WriteLine($"Объект 'c': Id = {c.Id}, Name = {c.Name}");

            var d = new Persondawf(1, "name");
            Console.WriteLine($"Объект 'd': Id = {d.Id}, Name = {d.Name}");

            Console.ReadKey();
        }
    }

    internal struct MyPerson
    {
        public string Name;
        public int Id;

        public MyPerson(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
