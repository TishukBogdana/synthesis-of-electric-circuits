using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Adder
    {
        public static List<List<Record>> addParallelElement(List<Record> testcircuit)
        {
            List<List<Record>> newCircuits = new List<List<Record>>();
            int n_max = Utils.Max_nodes(testcircuit);
            List<int[]> exceptionNodes = Utils.getNullorNodes(testcircuit);
            List<int[]> capNodes = Utils.getPassiveNodes(testcircuit, "C");
            List<int[]> indNodes = Utils.getPassiveNodes(testcircuit, "L");
            List<int> unconnectedNodes = Utils.getUnconnected(testcircuit);
            for (int i = 1; i < n_max; i++)
            {
                for (int j = i + 1; j <= n_max; j++)
                {
                    bool unconnected_i = Utils.isUnconnected(unconnectedNodes, i);
                    bool unconnected_j = Utils.isUnconnected(unconnectedNodes, j);
                    //добавление емкости между узлами и добавление синтезированной цепи в список
                    if ((!unconnected_i) && (!unconnected_j))
                    {
                        if ((!Utils.checkNodes(exceptionNodes, i, j)) && (!Utils.checkNodes(capNodes, i, j)))
                        {
                            int[] nodes = new int[4] { i, j, -1, -1 };
                            List<Record> newCir = testcircuit.GetRange(0, testcircuit.Count);
                            Record newCap = new Record("C" + (capNodes.Count + 1), nodes, 1);
                            newCir.Add(newCap);
                            newCircuits.Add(newCir);
                        }

                        if ((!Utils.checkNodes(exceptionNodes, i, j)) && (!Utils.checkNodes(indNodes, i, j)))
                        {
                            int[] nodes = new int[4] { i, j, -1, -1 };

                            List<Record> newCir = testcircuit.GetRange(0, testcircuit.Count);
                            Record newCap = new Record("L" + (indNodes.Count + 1), nodes, 1);
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
    }
}
