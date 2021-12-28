using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Test
{
    class IMyInterface
    {

        public string GetWordsCount(string[] inputword)
        {
            string hasil = "{ ";
            foreach (var iw in inputword.Distinct())
            {
                var res = from n in inputword
                          where n == iw
                          select n;
                hasil += "{\"" + iw + "\", " + res.Count() + "}, ";
            }
            return hasil.Substring(0, hasil.Length - 2) + " }";
        }
    }
}
