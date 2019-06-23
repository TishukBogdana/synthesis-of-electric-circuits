using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class CircuitTransformator
    {
        private 
        public static TransformedCircuit transform(List <Record> testcircuit)
        {
            TransformedCircuit tCir = new TransformedCircuit();
            return tCir;
        }

        /* public static List<Record>   deTransform(TransformedCircuit trCircuit)
         {

         }*/

        /* This method finds sequential subcircuits in circuit.
         * By the 1_st step it is neccessare to find sequential nodes: nodes, where connected only 2 elements
         * Then method finds what 2 elements are conntected in the sequential node and puts them into a List<Record>
         * For each sequential node connected elemennts are found and List <List<Record>> is assembled from lists of elements for concrete nodes
         * So, now exists list of sequential subcircuits, which contains 2 elements
         * Then for each subcircuit in the list are found new sequential elements and added to the subcircuit
         * Here is schematic of the method:
         * Iter1
         *      SUBCIRCUIT_1                       SUBCIRCUIT_2                    SUBCIRCUIT_3
         *      -------     -------               -------     ------             -------        -------
         *  ---|       |---|       |---       ---|       |---|      |---     ---|       |------|       |---
                -------     -------               -------     ------             -------        -------
                R1           pL1                    pL1         R2                R1            pL2

         * Iter2
         *      SUBCIRCUIT_1                                    SUBCIRCUIT_2                 
         *      -------     -------      -------                -------        -------
         *  ---|       |---|       |----|       |---        ---|       |------|       |---
                -------     -------      -------                -------        -------
                R1           pL1          pL2                    pL1              R2          
         * 
         * Iter3
         *      SUBCIRCUIT_1                                                   
         *      -------     -------      -------     -------        
         *  ---|       |---|       |----|       |---|       |---
                -------     -------      -------     -------       
                R1           pL1          pL2           R2       
          */
        public static List<List <Record>> findSerialSubcir(List<Record> testcircuit)  
        {
            int k = 0;
            List<int> serialNodes = Utils.getSerialNodes(testcircuit);
            List < List < Record >> tmpSerial = new List<List<Record>>();
            foreach(int i in serialNodes)
            {
                List<Record> pair = getElementsByNode(testcircuit, i);
                tmpSerial.Add(pair);
            }

            while (k < tmpSerial.Count )
            {
                for(int i = 0 ; i < tmpSerial.ElementAt(k).Count; i++ ) // in k_th subcircuit select following element
                {
                    string name = tmpSerial.ElementAt(k).ElementAt(i).getName();
                    for(int j = k + 1; j < tmpSerial.Count; j++) //in other part of lIst try to find this element
                    {
                        List<Record> pair = tmpSerial.ElementAt(j);
                        if (pair.ElementAt(0).getName().Equals(name)) // if element was found, place his 'neighbour' to k_th subcircuit and remove j-th subcircuit 
                        {
                            tmpSerial.ElementAt(k).Add(pair.ElementAt(1));
                            tmpSerial.RemoveAt(j);
                            break;
                        }
                        if (pair.ElementAt(1).getName().Equals(name))
                        {
                            tmpSerial.ElementAt(k).Add(pair.ElementAt(0));
                            tmpSerial.RemoveAt(j);
                            break;
                        }
                    }
                }
                k++; 
            }
            return tmpSerial;
        }

        /* This method finds parallel subcircuits in circuit.
         * To reduce complexity, method checks only not sequential nodes. 
         * At first step method gets an array of not sequential circuits
         * Then the List< List<Record>> is made. This list contains lists with elements which are connected in concrete not sequential node
         * For example , List of nodes, which are connected to the 3_d node
         * After that , in each list of nodes method tries to find sublist of elements, which are connected to the other not serial nodes
         * If this sublist was found, that means it is parallel subcircuit.
         * Then, struct SimplifiedCircuit is made from this 
         */
        public List <SimplifiedCircuit> findParallelSubcir(List<Record> testcircuit)
        {
            int n_max = Utils.Max_nodes(testcircuit);
            int k = 0;
            List<int> serial = Utils.getSerialNodes(testcircuit);
            List<SimplifiedCircuit> parallelCirs = new List<SimplifiedCircuit>();
            int[] notSerial = new int[n_max-serial.Count];
            List<List<Record>> byNodes = new List<List<Record>>();
            for (int i = 1; i <= n_max; i++)  // get an array of not sequential nodes
            {
                if (!serial.Contains(i))
                {
                    notSerial[k] = i;
                    k++;
                }
            }

            for(int i = 0; i < notSerial.Length; i++)
            {
                 List<Record> byNode = getElementsByNode(testcircuit, notSerial[i]);
                 byNodes.Add(byNode);
            }

            for (int i = 0; i < notSerial.Length; i++)
            {
               for (int  j = i + 1; j < notSerial.Length; j++)
                {
                    List<Record> parallel = getElementsByNode(byNodes.ElementAt(i), notSerial[j]);
                    if(parallel.Count > 1)
                    {
                        SimplifiedCircuit cir = new SimplifiedCircuit();
                        cir.initialNodes.Add(notSerial[i]);
                        cir.initialNodes.Add(notSerial[j]);
                        for ( int n = 0; n < parallel.Count; n ++)
                        {
                            cir.elements.Add(parallel.ElementAt(n).getName());
                            byNodes.ElementAt(i).Remove(parallel.ElementAt(n));
                            byNodes.ElementAt(j).Remove(parallel.ElementAt(n));
                        }
                        parallelCirs.Add(cir);
                    }               
                }
            }
            return parallelCirs;
        }

        public List <SimplifiedCircuit> toSimplifiedCir(List<List<Record>> cirlist) //transforms to List<list<Record>> to List <SimplifiedCircuit>
        {
            List<SimplifiedCircuit> simplCirList = new List<SimplifiedCircuit>();
            for( int i = 0; i < cirlist.Count; i++)
            {
                SimplifiedCircuit sCir = new SimplifiedCircuit();       
                for( int j = 0; j < cirlist.ElementAt(i).Count; j++)
                {
                   sCir.elements.Add( cirlist.ElementAt(i).ElementAt(j).getName());
                    int[] nodes = cirlist.ElementAt(i).ElementAt(j).getNodes();
                    for (int k = 0; k < 4; k++)
                    {
                        if(nodes[k] > 0)
                        {
                            sCir.initialNodes.Add(nodes[k]);
                        }
                    }
                    sCir.initialNodes.Distinct();
                    simplCirList.Add(sCir);
                }
            }

            return simplCirList;
        }

        public static List<Record> getElementsByNode(List<Record> testcircuit, int num) //finds elements, connected to concrete node
        {
            List<Record> conElements = new List<Record>();
            for (int i = 0; i < testcircuit.Count; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    if (testcircuit.ElementAt(i).getNodes()[j]==num)
                    {
                        conElements.Add(testcircuit.ElementAt(i));

                    }                  
                }             
            }
            return conElements;
        }
    }


}
