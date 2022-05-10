using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircularList
{
    class Program
    {
        static void Main(string[] args)
        {
            CircleList<string> list = new CircleList<string>();
            list.AddLast("Hyundai");
            list.AddLast("Mazda");
            list.AddLast("Mercedes-Benz");
            list.AddLast("BMW");
            list.AddLast("Bentley");
            list.AddLast("Subaru");

            foreach(var irem in list)
            {
                Console.WriteLine(irem);
            }

            list.Remove("Subaru");

            CircleListNode<string> Chery = new CircleListNode<string>("Chery");
            list.AddLast(Chery);
            list.AddLast("Haval");

            list.Remove(Chery);
            list.RemoveFirst();
            list.RemoveLast();

            Console.WriteLine("\n После удаления: \n");

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\n"+list.Last.Data);
            Console.WriteLine(list.Count);

            Console.WriteLine(list.Any());

            Index index = new Index(2, false);
            Console.WriteLine(list.ElementAt(index));
        }
    }
}