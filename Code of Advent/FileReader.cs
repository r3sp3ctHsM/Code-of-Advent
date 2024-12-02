using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_of_Advent
{
    public static class FileReader
    {
        private static List<String> stringList = new List<String>();
        public static List<String> getData(string fileName)
        {
            stringList.Clear();
            String line;
            try
            {
                StreamReader sr = new StreamReader(fileName);
                line = sr.ReadLine();
                while (line != null)
                {
                    stringList.Add(line);
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }

            return stringList;
        }
    }
}
