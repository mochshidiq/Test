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
        ok:
            Console.Clear();
            Console.Write("Input your player count !!! : ");
            int player = Int32.Parse(Console.ReadLine().Trim());
            Console.Write("Input your dice count !!! : ");
            int dice = Int32.Parse(Console.ReadLine().Trim());
            myInterface.GetWinner(player, dice);

            ok2:
            Console.Write("Play Again ??? [Y/N] : ");
            char choose = Char.Parse(Console.ReadLine().Trim());
            if (choose.ToString().ToUpper() == "Y")
                goto ok;
            else if (choose.ToString().ToUpper() == "N")
                Console.ReadKey();
            else
            {
                Console.WriteLine("Input the correct char !!!");
                goto ok2;
            }
        }
    }
}
