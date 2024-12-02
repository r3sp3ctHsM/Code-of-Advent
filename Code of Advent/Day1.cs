using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_of_Advent
{
    public static class Day1
    {
        private static string fileName = "..\\..\\..\\Day1.txt";
        private static List<String> stringList = new List<String>();

        public static void Func()
        {
            stringList = FileReader.getData(fileName);
            List<String> listL = new List<String>();
            List<String> listR = new List<String>();
            foreach (String line in stringList)
            {
                string[] data;
                data = line.Split("   ");
                listL.Add(data[0].Trim());
                listR.Add(data[1].Trim());
            }

            listL.Sort();
            listR.Sort();

            int sumDist = 0;

            for (int i = 0; i < listL.Count; i++)
            {
                int dist = Math.Abs(int.Parse(listL[i]) - int.Parse(listR[i]));
                sumDist += dist;
            }

            Console.WriteLine("Day 1 - Part 1: " + sumDist);

            int score = 0;

            for (int i = 0; i < listL.Count; i++)
            {
                int count = 0;
                for (int j = 0; j < listR.Count; j++)
                {
                    if (listL[i] == listR[j])
                    {
                        count++;
                    }
                }
                score += int.Parse(listL[i]) * count;
            }

            Console.WriteLine("Day 1 - Part 2: " + score);
        }
    }
}
