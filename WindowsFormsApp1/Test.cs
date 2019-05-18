using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.IO;
using System.Text;

namespace WindowsFormsApp1
{
    class Test
    {
        public static bool check_nodes(List<string> exception_nodes, int i, int j) // сравнение пар узлов с услами норатора и нуллатора из списка exception_nodes
        {
            for (int k = 0; k < exception_nodes.Count; k++)
            {
                string s = exception_nodes.ElementAt(k);
                string[] words = s.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (i == Int32.Parse(words[0]) && j == Int32.Parse(words[1]))
                { return true; }
                if (i == Int32.Parse(words[1]) && j == Int32.Parse(words[0]))
                { return true; }
            }
            return false;
        }

        public static int Max_nodes(List<string> testcircuit)

        {
            // определяем число узлов
            List<string> nodes = new List<string>();
            int n_max = 0; // максимальное число узлов
            for (int i = 0; i < testcircuit.Count; i++)
            {
                string s = testcircuit.ElementAt(i);
                string[] words = s.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (words.Length > 4)
                {
                    nodes.Add(words[1]); nodes.Add(words[2]); nodes.Add(words[3]); nodes.Add(words[4]);
                }
                else
                {
                    nodes.Add(words[1]);
                    nodes.Add(words[2]);
                }

            }
            for (int i = 0; i < nodes.Count; i++)
            {
                int b = Int32.Parse(nodes[i]);
                if (b > n_max)
                    n_max = b;
            }
            return n_max;
        }

        public static void startTest()
        {
            // исходные данные
            List<string> testcircuit = new List<string>() { "N1 1 3 1 2", "R1 1 2 1", "L1 3 4 1", "R2 2 4 1" }; // тестовая схема
            List<string> tempcircuit = new List<string>(); // список для хранения промежуточных результатов 
            string add_element = "c1";  // название добавляемого элемента

            // элемент добавляется при условии, что степень должна увеличиться, то есть нельзя подключать с1 параллельно к норатору и нуллатору

            List<string> exception_nodes = new List<string>() { "1 3", "1 2" }; // узлы, к которым не нужно подключать 

            int n_max = Max_nodes(testcircuit);

            // комбинаторно перебираем пары узлов, сверяя с исключениями
            for (int i = 1; i < n_max + 1; i++)
            {
                for (int j = i + 1; j < n_max + 1; j++)
                {
                    if (!check_nodes(exception_nodes, i, j))
                    {
                        tempcircuit.Add("new circuit");
                        for (int k = 0; k < testcircuit.Count; k++)
                        {
                            tempcircuit.Add(testcircuit[k]);
                        }
                        tempcircuit.Add(add_element + " " + i + " " + j + " 1");
                        tempcircuit.Add(".END");
                    }
                }
            }

            for (int k = 0; k < tempcircuit.Count; k++)
            {
                Console.WriteLine(tempcircuit[k]);

            }
            Console.ReadLine();
        }
    }
}
