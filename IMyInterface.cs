using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Test
{
    class IMyInterface
    {
        public class playerdata
        {
            public string playername { get; set; }
            public int score { get; set; }
            public List<int> dice { get; set; }
        }

        public void GetWinner(int player, int dicecount)
        {
            List<playerdata> playerdatalist = new List<playerdata>();
            for(int i = 1; i < player + 1; i++)
            {
                List<int> dice2 = new List<int>();
                int dicecount2 = dicecount;
                while (dicecount2 != 0)
                {
                    dice2.Add(7);
                }
                playerdatalist.Add(new playerdata{
                    playername = "Pemain #" + i,
                    score = 0,
                    dice = dice2
                });
            }

            int playercount = player, iterasi = 0;
            Random rd = new Random();
            
            while (playercount != 1)
            {
                iterasi++;
                Console.WriteLine("Giliran " + iterasi + " lempar dadu:");

                foreach (var playersingle in playerdatalist)
                {

                    Console.Write(playersingle.playername + " (" + playersingle.score + "): ");

                    dicecount = iterasi != 1 ? playersingle.dice.Count() : dicecount;
                    for (int i = 0; i < dicecount; i++)
                    {
                        if (playersingle.dice[i] != 0)
                        {
                            int rand_num = rd.Next(1, 6);
                            playersingle.dice[i] = rand_num;
                            if (i == 0)
                                Console.Write(rand_num);
                            else
                                Console.Write("," + rand_num);
                            if (rand_num == 6)
                            {
                                playersingle.score++;
                                playersingle.dice[i] = 0;
                            }
                            else if (rand_num == 1)
                            {                                
                                playersingle.dice[i] = 0;

                            }
                        }
                    }
                    
                    Console.WriteLine();
                }
            }


            Console.WriteLine("The winner is : " + string.Join(',', playerdatalist.Where(x => x.score == playerdatalist.Max(x => x.score)).Select(x => x.playername).ToList()));
        }
    }
}
