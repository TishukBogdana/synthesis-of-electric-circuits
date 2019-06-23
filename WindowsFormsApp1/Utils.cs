using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.IO;
using System.Text;

namespace WindowsFormsApp1
{
    class Utils
    {
        public static bool checkNodes(List<int[]> exception_nodes, int i, int j) // сравнение пар узлов с услами норатора и нуллатора, емкостей , индуктивностей из списка exception_nodes
        {
            for (int k = 0; k < exception_nodes.Count; k++)
            {
                int[] iter = exception_nodes.ElementAt(k);
                if ((i == iter[0]) && (j == iter[1]) || (i == iter[1]) && (j == iter[0]))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool isUnconnected(List<int> unconnectedNodes, int i) //проверяет,  является ли узел неподключенным ( в воздухе)
        {
            for (int k = 0; k < unconnectedNodes.Count; k++)
            {
                if (i == unconnectedNodes.ElementAt(k))
                {
                    return true;
                }
            }
            return false;
        }


        public static int Max_nodes(List<Record> testcircuit)

        {
            int checker = 0;
            int n_max = 0; // максимальное число узлов
            for (int i = 0; i < testcircuit.Count; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    checker = testcircuit.ElementAt(i).getNodes()[j];
                    if (checker > n_max)
                    {
                        n_max = checker;
                    }
                }
            }

            return n_max;
        }

  

        public static List<int[]> getNullorNodes(List<Record> testcircuit) //возвращает пары узлов, в которых подключенны элементы нуллора
        {
            List<int[]> exceptionNodes = new List<int[]>();
            for (int i = 0; i < testcircuit.Count; i++)
            {
                if (testcircuit.ElementAt(i).getName().StartsWith("N"))
                {
                    int[] nullatorNodes = new int[2];
                    int[] noratorNodes = new int[2];
                    Array.Copy(testcircuit.ElementAt(i).getNodes(), 0, nullatorNodes, 0, 2);
                    Array.Copy(testcircuit.ElementAt(i).getNodes(), 2, noratorNodes, 0, 2);
                    exceptionNodes.Add(nullatorNodes);
                    exceptionNodes.Add(noratorNodes);
                }
            }
            return exceptionNodes;
        }
        

        public static List<int[]> getPassiveNodes(List<Record> testcircuit, string match) // возвращает пары узлов, куда подключенны двухполюсники
        {
            List<int[]> lcNodes = new List<int[]>();
            
            for (int i = 0; i < testcircuit.Count; i++)
            {
                int[] passiveNodes = new int[2];
                Array.Copy(testcircuit.ElementAt(i).getNodes(), 0, passiveNodes, 0, 2);
                if (testcircuit.ElementAt(i).getName().StartsWith(match))
                {              
                    lcNodes.Add(passiveNodes);
                }
            }
            
            int[] cur = new int[2];
            int[] next = new int[2];
            //bad solution, because of O (NlogN) complexity, I'll try to find more suitable method
            for(int  i = 0;  i < lcNodes.Count; i++)
            {
                cur = lcNodes.ElementAt(i);
                for (int j = i + 1; j < lcNodes.Count; j++) {
                    next = lcNodes.ElementAt(j);
                 if   (((cur[0] == next[0]) && (cur[1] == next[1])) || ((cur[0] == next[1]) && (cur[1] == next[0])))
                {
                        lcNodes.RemoveAt(j);
                    }
                }
            }
            return lcNodes;
        }

        public static List<int> getUnconnected(List<Record> testcircuit) // возвращает список номеров неподключенных узлов 
        {

            int[] counts = nodesCount(testcircuit);
            int n_max = Max_nodes(testcircuit); 
            List<int> unconected = new List<int>();
            for (int i = 0; i < n_max; i++)
            {
                if (counts[i] < 2)
                {
                    unconected.Add(i + 1);
                }
            }
            return unconected;
        }

        public static List<int> getSerialNodes(List <Record> testcircuit)
        {
            int[] counts = nodesCount(testcircuit);
            int n_max = Max_nodes(testcircuit);
            List<int> serial = new List<int>();
            for (int i = 0; i < n_max; i++)
            {
                if (counts[i] == 2)
                {
                    serial.Add(i + 1);
                }
            }
            return serial;
        }

        public static int[] nodesCount(List<Record> testcircuit)// возвращает массив в котором для каждого узла посчитано количество подключеных в него компанентов
        {
            int n_max = Max_nodes(testcircuit);
            int[] counts = new int[n_max];
            for (int i = 0; i < testcircuit.Count; i++)
            {
                int[] nodes = testcircuit.ElementAt(i).getNodes();
                for (int j = 0; j < 4; j++)
                {
                    if ((nodes[j] != -1) && (nodes[j] != 0))
                    {
                        counts[nodes[j] - 1]++;
                    }
                }
            }
            return counts;
        }
      
    }
}
