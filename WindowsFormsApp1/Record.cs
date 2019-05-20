using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    // Класс, в котором хранятся сведения  об элементах , то есть объектное представление строки netlist
    class Record
    {
        private string name;
        private int[] nodes =  new int[4] { -1,-1,-1,-1};
   
        private int nominal;
 
        /* Если двухполюсник, то node[2] и node[3] устанавливаются -1
        */
        public Record() { }
        public Record(string name, int[] nodes, int nominal)
        {
            this.name = name;
            this.nodes = nodes;
            this.nominal = nominal;       
        }
        // getters and setters to observe incapsulation
        public void setName(string name)
        {
            this.name = name;
        }

        public void setNodes(int[] nodes)
        {
            this.nodes = nodes;
        }


        public void setNominal(int nominal)
        {
            this.nominal = nominal;
        }


        public string getName()
        {
            return name;
        }

        public int[] getNodes()
        {
            return nodes;
        }

        public int getNominal()
        {
            return nominal;
        }
        
    }
}
