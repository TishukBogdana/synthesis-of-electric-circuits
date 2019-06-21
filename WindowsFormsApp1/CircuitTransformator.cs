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
            
        }

        public static List<Record>   deTransform(TransformedCircuit trCircuit)
        {

        }

        public static List<SimpifiedCircuit> findSerial(List<Record> testcircuit)
        {
            List<SimpifiedCircuit> serials = new List<SimpifiedCircuit>();
            List<int> serialNodes = Utils.getSerialNodes(testcircuit);
            List < List < Record >> tmpSerial = new List<List<Record>>();
            foreach(int i in serialNodes)
            {
                List<Record> pair = getElementsByNode(testcircuit, i);
                tmpSerial.Add(pair);
            }

            for(int i = 0; i < tmpSerial.Count; i++)
            {

            }
            return serials;
        }
        
        public static List<Record> getElementsByNode(List<Record> testcircuit, int num) //ищет элементы, подключенные в данный узел
        {
            List<Record> conElements = new List<Record>();
            int count = 0;
            for (int i = 0; i < testcircuit.Count; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    if (testcircuit.ElementAt(i).getNodes()[j]==num)
                    {
                        count++;
                        
                    }
                    if(count == 1)
                    {
                        conElements.Add(testcircuit.ElementAt(i));
                    }
                }
               
                
            }
            return conElements;
        }
    }
}
