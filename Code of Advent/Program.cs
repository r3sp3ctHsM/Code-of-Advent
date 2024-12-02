using System;
using System.IO;

namespace CodeOfAdvent
{
    internal class Program
    {
        static List<String> stringList = new List<String>();

        static void getData(string fileName)
        {
            String line;
            try
            {
                StreamReader sr = new StreamReader(fileName);
                line = sr.ReadLine();
                while(line != null)
                {
                    stringList.Add(line);
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }

        static void Day1()
        {
            stringList.Clear();
            getData("..\\..\\..\\Day1.txt");
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
                    if(listL[i] == listR[j])
                    {
                        count++;
                    }
                }
                score += int.Parse(listL[i]) * count;
            }

            Console.WriteLine("Day 1 - Part 2: " + score);
        }

        static void Day2()
        {
            stringList.Clear();
            getData("..\\..\\..\\Day2.txt");            
            List<List<int>> reports = new List<List<int>>();
            foreach(String s in stringList)
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

            foreach(List<int> ints in reports)
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

                if(unSafe == 1)
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

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Day1();

            Day2();

            //foreach(String data in stringList)
            //{
            //    Console.WriteLine(data);
            //}
        }
    }
}