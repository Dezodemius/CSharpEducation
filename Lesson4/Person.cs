using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4e21
{
    class Persondawf
    {
        public int Id;
        public string Name;
        public static int Count;

        public void SayHello(string message)
        {
            Console.WriteLine(message);
        }

        public Persondawf() : this(-1, "пустое имя")
        {
        }

        public Persondawf(int id) : this(id, "другое пустое имя")
        {
            Id = id;
        }

        public Persondawf(string name) : this(-2, name)
        {
            Name = name;
        }
        
        public Persondawf(int id, string name)
        {
        }
    }
}
