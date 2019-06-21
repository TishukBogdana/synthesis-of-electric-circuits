using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    struct SimpifiedCircuit
    {
        List<string> elements;
        int[] initialNodes;
    }
    class TransformedCircuit
    {
        private List<Record> single = new List<Record>();
        private List<SimpifiedCircuit> serial = new List<SimpifiedCircuit>();
        private List<SimpifiedCircuit> parallel = new List<SimpifiedCircuit>();
        private TransformedCircuit subcir;

        public TransformedCircuit() { }
        public TransformedCircuit(List<Record> single, List<SimpifiedCircuit> ser, List <SimpifiedCircuit> parallel, TransformedCircuit subcir)
        {
            this.single = single;
            this.serial = ser;
            this.parallel = parallel;
            this.subcir = subcir;
        }

        public List<Record> getSingle()
        {
            return single;
        }

        public List<SimpifiedCircuit> getSerial()
        {
            return serial;
        }

        public List<SimpifiedCircuit> getParallel()
        {
            return parallel;
        }

        public TransformedCircuit getSubCircuit()
        {
            return subcir;
        }

        public void setSingle(List <Record > single)
        {
            this.single = single;
        }

        public void setSerial(List<SimpifiedCircuit> serial)
        {
            this.serial = serial;
        }

        public void setParallel(List<SimpifiedCircuit> parallel )
        {
           this.parallel =  parallel;
        }

        public void setSubCircuit(TransformedCircuit subcir)
        {
            this.subcir = subcir;
        }
    }
}
