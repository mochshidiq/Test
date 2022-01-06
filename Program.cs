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
            Console.Write("Input your player count !!! : ");
            int player = Int32.Parse(Console.ReadLine().Trim());
            Console.Write("Input your dice count (separate with space) !!! : ");
            int dice = Int32.Parse(Console.ReadLine().Trim());
            myInterface.GetWinner(player, dice);
            
            Console.ReadKey();
        }
    }
}
