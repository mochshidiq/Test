using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            IMyInterface myInterface = new IMyInterface();
            var hasil = myInterface.GetWordsCount(new[] { "one", "two", "two", "three", "three", "three", "four", "One" });
            Console.WriteLine(hasil);
            Console.ReadKey();
        }
    }
}
