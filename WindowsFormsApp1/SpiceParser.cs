using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace WindowsFormsApp1
{
    class SpiceParser
    {
        // В метод передается путь к netlist'у, метод парсит документ в список элементов Record

        public List<Record> parseNetList(string path)
        {
            string[] allLines = null;
            try
            {
                allLines = File.ReadAllLines(path);
            }
            catch
            {
                Console.WriteLine("Wrong path to file");
            }

            List<Record> circuit = new List<Record>();
            for (int i = 1; i < allLines.Length - 2; i++)
            {
                string[] words = allLines[i].Split(new char[] { ' ', '\t' });
                int[] nodes = new int[4] { -1, -1, -1, -1 };
                int nominal = -1;
                if ((words[0].StartsWith("K")) || (words[0].StartsWith("H")) || (words[0].StartsWith("G")) || (words[0].StartsWith("B")))
                {

                    for (int j = 0; j < 4; j++)
                    {
                        try
                        {
                            nodes[j] = Int32.Parse(words[j + 1].Replace("N", ""));
                        }
                        catch
                        {
                            Console.WriteLine("Wrong file structure");
                            return null;
                        }
                    }
                    try
                    {
                        nominal = Int32.Parse(words[5]);
                    }
                    catch { }
                }

                if ((words[0].StartsWith("N")) || (words[0].StartsWith("M")) || (words[0].StartsWith("T")))
                {

                    for (int j = 0; j < 4; j++)
                    {
                        try
                        {
                            nodes[j] = Int32.Parse(words[j + 1].Replace("N", ""));
                        }
                        catch
                        {
                            Console.WriteLine("Wrong file structure");
                            return null;
                        }
                    }

                }
                if ((words[0].StartsWith("R")) || (words[0].StartsWith("g")) || (words[0].StartsWith("L")) || (words[0].StartsWith("C")))
                {

                    for (int j = 0; j < 2; j++)
                    {
                        try
                        {
                            nodes[j] = Int32.Parse(words[j + 1].Replace("N", ""));
                        }
                        catch
                        {
                            Console.WriteLine("Wrong file structure");
                            return null;
                        }
                    }
                    try
                    {
                        nominal = Int32.Parse(words[3]);
                    }
                    catch { }
                }
                Record newJunc = new Record(words[0], nodes, nominal);
                circuit.Add(newJunc);
            }

            return circuit;
        }

    }
}
