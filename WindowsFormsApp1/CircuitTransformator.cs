using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class CircuitTransformator
    {
        
        public static TransformedCircuit transform(List <Record> testcircuit)
        {
            TransformedCircuit tCir = new TransformedCircuit();
            List<SimplifiedCircuit> par = findParallelSubcir(testcircuit);
            List<int[]> parNodes = new List<int[]>();
            List<int> serialNodes = Utils.getSerialNodes(testcircuit);
            List<Record> single = new List<Record>();
            tCir.setParallel(par);
            tCir.setSerial(toSimplifiedCir(findSerialSubcir(testcircuit)));
            for( int i =0; i < par.Count; i++ )
            {
                int[] nodes = par.ElementAt(i).initialNodes.ToArray();
                parNodes.Add(nodes);            
            }
            for(int i = 0; i < testcircuit.Count; i++)
            {
                int[] nodes = testcircuit.ElementAt(i).getNodes();
                if( (!serialNodes.Contains(nodes[0])) && (!serialNodes.Contains(nodes[1])) && (!Utils.checkNodes(parNodes, nodes[0],nodes[1])) )
                {
                    single.Add(testcircuit.ElementAt(i));  
                }
            }
            tCir.setSingle(single);
            return tCir;
        }
        // now freature is unimplemented.
         public static List<Record>   deTransform(TransformedCircuit trCircuit, bool mix)
         {
            List<Record> detransformed = trCircuit.getSingle().GetRange(0, trCircuit.getSingle().Count -1);
            for(int i = 0;  i < trCircuit.getParallel().Count; i++)
            {
                int[] nodes = trCircuit.getParallel().ElementAt(i).initialNodes.ToArray();
                List<string> names = trCircuit.getParallel().ElementAt(i).elements;
                for (int j = 0; j < names. Count; j++)
                {
                    Record newParallel = new Record(names.ElementAt(j), nodes, 1);
                    detransformed.Add(newParallel);
                }
            }
            if(!mix)
            {
                for (int i =0; i< trCircuit.getSerial().Count; i++)
                {
                    List<int> sNodes = trCircuit.getSerial().ElementAt(i).initialNodes;
                    List<string> names = trCircuit.getSerial().ElementAt(i).elements;
                    for (int j = 0; j < names.Count ; j++)
                    {
                        int[] nodes = { sNodes.ElementAt(j), sNodes.ElementAt(j + 1) };
                        Record newSer = new Record(names.ElementAt(j), nodes, 1);
                        detransformed.Add(newSer);
                    }
                }
            }
            return detransformed;
        }

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
        public static List<SimplifiedCircuit> findParallelSubcir(List<Record> testcircuit)
        {
            
            List<SimplifiedCircuit> parallelCirs = new List<SimplifiedCircuit>();
            int[] notSerial = Utils.getNotSerialNodes(testcircuit);
            List<List<Record>> byNodes = new List<List<Record>>();
           

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

        public static List <SimplifiedCircuit> toSimplifiedCir(List<List<Record>> cirlist) //transforms to List<list<Record>> to List <SimplifiedCircuit>
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
