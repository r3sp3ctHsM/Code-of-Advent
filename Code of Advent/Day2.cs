using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_of_Advent
{
    public static class Day2
    {
        private static string fileName = "..\\..\\..\\Day2.txt";
        private static List<String> stringList = new List<String>();

        public static void Func()
        {
            stringList = FileReader.getData(fileName);
            List<List<int>> reports = new List<List<int>>();
            foreach (String s in stringList)
            {
                List<int> levels = new List<int>();
                string[] data;
                data = s.Split(' ');
                foreach (string c in data)
                {
                    levels.Add(int.Parse(c));
                }
                reports.Add(levels);
            }

            int count = 0;

            foreach (List<int> ints in reports)
            {
                int allInc = 0;
                int allDec = 0;
                int safe = 0;
                for (int i = 0; i < ints.Count - 1; i++)
                {
                    if (ints[i] > ints[i + 1])
                    {
                        allInc++;
                    }
                    else if (ints[i] < ints[i + 1])
                    {
                        allDec++;
                    }

                    if (1 <= Math.Abs(ints[i] - ints[i + 1]) && Math.Abs(ints[i] - ints[i + 1]) <= 3)
                    {
                        safe++;
                    }
                }
                if ((allInc == ints.Count() - 1 || allDec == ints.Count() - 1) && safe == ints.Count() - 1)
                {
                    count++;
                }
            }

            Console.WriteLine("Day 2 - Part 1: " + count);

            count = 0;

            foreach (List<int> ints in reports)
            {
                int allInc = 0;
                int allDec = 0;
                int safe = 0;
                int unSafe = 0;
                for (int i = 0; i < ints.Count - 1; i++)
                {
                    int gap = Math.Abs(ints[i] - ints[i + 1]);

                    if (ints[i] > ints[i + 1])
                    {
                        allInc++;
                    }
                    else if (ints[i] < ints[i + 1])
                    {
                        allDec++;
                    }

                    if (1 <= gap && gap <= 3)
                    {
                        safe++;
                    }
                    else if (gap == 0)
                    {
                        unSafe++;
                    }
                }

                if (unSafe == 1)
                {
                    safe++;
                }

                if ((allInc <= 1 || allDec <= 1) && safe >= ints.Count() - 1)
                {
                    count++;
                }
            }
            Console.WriteLine("Day 2 - Part 2: " + count);
        }
    }
}
