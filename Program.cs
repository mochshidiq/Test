using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            IMyInterface myInterface = new IMyInterface();
            //string[] inputan = new[] { "one", "two", "two", "three", "three", "three", "four", "One" };
            Console.Write("Input your words (separate with space) !!! : ");
            string[] inputan = Console.ReadLine().TrimEnd().Split(' ').ToArray();
            var hasil = myInterface.GetWordsCount(inputan);
            Console.WriteLine(hasil);
            Console.ReadKey();
        }
    }
}
