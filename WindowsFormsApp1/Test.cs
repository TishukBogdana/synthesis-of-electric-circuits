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
        public static bool checkNodes(List<int[]> exception_nodes, int i, int j) // сравнение пар узлов с услами норатора и нуллатора, емкостей , индуктивностей из списка exception_nodes
        {
            for (int k = 0; k < exception_nodes.Count; k++)
            {
                int[] iter = exception_nodes.ElementAt(k);
                if((i==iter[0])&&(j == iter[1]) || (i == iter[1]) && (j == iter[0])){
                    return true;
                }               
            }
            return false;
        }

        public static bool isUnconnected(List <int> unconnectedNodes, int i) //проверяет,  является ли узел неподключенным ( в воздухе)
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
            int checker =0;
            int n_max = 0; // максимальное число узлов
            for (int i = 0; i < testcircuit.Count; i++)
            {
                for (int j = 0; j < 4; j++) {
                    checker = testcircuit.ElementAt(i).getNodes()[j];
                    if ( checker > n_max) {
                        n_max = checker;
                    }
                }
            }
           
            return n_max;
        }

       /* public static void startTest()
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
        }*/

        public static List<List<Record>> addParallelElement(List< Record> testcircuit)
        {
            List<List<Record>> newCircuits = new List<List<Record>>();
            int n_max = Max_nodes(testcircuit);
            List<int[]> exceptionNodes = getNullorNodes(testcircuit);
            List<int[]> capNodes = getPassiveNodes(testcircuit, "C");
            List<int[]> indNodes = getPassiveNodes(testcircuit, "L");
            List<int> unconnectedNodes = getUnconnected(testcircuit);
            for (int i = 0; i < n_max; i++)
            {
                for (int j = i + 1; j < n_max; j++)
                {
                    bool unconnected_i = isUnconnected(unconnectedNodes, i);
                    bool unconnected_j = isUnconnected(unconnectedNodes, j);
                    //добавление емкости между узлами и добавление синтезированной цепи в список
                    if ((!unconnected_i) && (!unconnected_j)) {
                        if ((!checkNodes(exceptionNodes, i, j)) && (!checkNodes(capNodes, i, j)))
                        {
                            int[] nodes = new int[4] { i, j, -1, -1 };
                            List<Record> newCir = testcircuit.GetRange(0, testcircuit.Count);
                            Record newCap = new Record("C" + capNodes.Count + 1, nodes, 1);
                            newCir.Add(newCap);
                            newCircuits.Add(newCir);
                        }

                        if ((!checkNodes(exceptionNodes, i, j)) && (!checkNodes(indNodes, i, j)))
                        {
                            int[] nodes = new int[4] { i, j, -1, -1 };
                            
                            List<Record> newCir = testcircuit.GetRange(0, testcircuit.Count);
                            Record newCap = new Record("L" + indNodes.Count + 1, nodes, 1);
                            newCir.Add(newCap);
                            newCircuits.Add(newCir);
                        }
                    }
                    else
                    {
                        //обработка случая замыкания контура, добавлением элемента
                    }
                }
            }
            return newCircuits;
        }

        public static List<int[]> getNullorNodes(List<Record> testcircuit) //возвращает пары узлов, в которых подключенны элементы нуллора
        {
            List<int[]> exceptionNodes = new List<int[]>();
            for( int i = 0; i< testcircuit.Count; i++)
            {
                if (testcircuit.ElementAt(i).getName().StartsWith("N"))
                {
                    int[] nullatorNodes = new int[2];
                    int[] noratorNodes = new int[2];
                    Array.Copy(testcircuit.ElementAt(i).getNodes(), 0, nullatorNodes, 0, 2);
                    Array.Copy(testcircuit.ElementAt(i).getNodes(), 3, noratorNodes, 0, 2);
                    exceptionNodes.Add(nullatorNodes );
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
                if (testcircuit.ElementAt(i).getName().StartsWith(match))
                {
                    int[] passiveNodes = new int[2];
                    Array.Copy(testcircuit.ElementAt(i).getNodes(), 0, passiveNodes, 0, 2);
                    lcNodes.Add(passiveNodes);                 
                }
            }
            return lcNodes;
        }

   

        public static List<int> getUnconnected(List<Record> testcircuit)
        {
            int n_max = Max_nodes(testcircuit);
            int[] counts = new int[n_max];
            for (int i =0; i < testcircuit.Count; i++)
            {
                int[] nodes = testcircuit.ElementAt(i).getNodes();
                for( int j =0; j < 4; j++)
                {
                    if(nodes[j] != -1)
                    {
                        counts[nodes[j] - 1]++;
                    }
                }
            }
            List<int> unconected = new List<int>();
            for(int i =0; i< n_max; i++)
            {
                if (counts[i] < 2)
                {
                    unconected.Add(counts[i]);
                }
            }
            return unconected;
        }
    }
}
