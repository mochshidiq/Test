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
            //isi data awal dadu diberikan angka 8 sebagai angka yang akan diproses pertama2
            for(int i = 1; i < player + 1; i++)
            {
                List<int> dice2 = new List<int>();
                int dicecount2 = dicecount;
                while (dicecount2 != 0)
                {
                    dice2.Add(8);
                    dicecount2--;
                }
                playerdatalist.Add(new playerdata{
                    playername = "Pemain #" + i,
                    score = 0,
                    dice = dice2
                });
            }

            int playercount = player, iterasi = 0;
            Random rd = new Random();
            
            //perulangan yg terjadi hingga player tinggal 1
            while (playercount != 1)
            {
                iterasi++;
                Console.WriteLine("Giliran " + iterasi + " lempar dadu:");                
                
                //looping giliran
                for (int j = 0; j < playerdatalist.Count(); j++)
                {
                    //penanda jika dadu bernilai 9 maka akan diganti menjadi 8, 
                    //karena jika dadu langsung diisi 8 maka akan diproses sebelum giliran baru
                    if (j == 0)
                    {
                        foreach (var pdl in playerdatalist)
                        {
                            for (int k = 0; k < pdl.dice.Count(); k++)
                            {
                                pdl.dice[k] = pdl.dice[k] == 9 ? 8 : pdl.dice[k];
                            }
                        }
                    }

                    Console.Write(playerdatalist[j].playername + " (" + playerdatalist[j].score + "): ");
                    
                    //jika masih iterasi 1 maka dadu yg digulir hanya sesuai jumlah dadu saja
                    dicecount = iterasi != 1 ? playerdatalist[j].dice.Count() : dicecount;
                    string isi = "";
                    for (int i = 0; i < dicecount; i++)
                    {
                        //kondisi untuk mencegah agar pemain yang jumlah dadunya sudah habis tidak bisa bermain lagi
                        //begitupun jika dadu bernilai 0 yang artinya dadu tersebut sebelumnya bernilai 6 atau 1
                        if (playerdatalist[j].dice[i] != 0 && playerdatalist[j].dice.Sum() != 0)
                        {                            
                            int rand_num = rd.Next(1, 7);
                            rand_num = rand_num == 7 ? 6 : rand_num;
                            playerdatalist[j].dice[i] = rand_num;
                            isi += isi.Length == 0 ? rand_num.ToString() : "," + rand_num;
                            if (rand_num == 6)
                            {
                                playerdatalist[j].score++;
                                playerdatalist[j].dice[i] = 0;
                            }
                            else if (rand_num == 1)
                            {
                                playerdatalist[j].dice[i] = 0;

                                //logic agar ketika nilai satu diberikan ke pemain sebelahnya dan
                                int k = j == 0 ? playerdatalist.Count() - 1 : j - 1;
                                bool flagstop = false;
                                while(flagstop == false)
                                {
                                    if (playerdatalist[k].dice.Sum() != 0)
                                    {
                                        flagstop = true;
                                        playerdatalist[k].dice.Add(9);
                                    }
                                    k = k == 0 ? playerdatalist.Count() - 1 : k - 1;
                                }
                               
                            }
                            //point jika satu pemain kehabisan dadu maka akan berkurang satu orang
                            if (playerdatalist[j].dice.Sum() == 0)
                                playercount--;
                        }
                    }
                    Console.WriteLine(isi);
                    Console.WriteLine();
                }
            }


            Console.WriteLine("The winner is : " + string.Join(',', playerdatalist.Where(x => x.score == playerdatalist.Max(x => x.score)).Select(x => x.playername).ToList()));
        }
    }
}
