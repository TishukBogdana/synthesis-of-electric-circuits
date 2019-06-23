using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    struct SimplifiedCircuit
    {
        public List<string> elements;
        public List<int> initialNodes;
    }
    class TransformedCircuit
    {
        private List<Record> single = new List<Record>();
        private List<SimplifiedCircuit> serial = new List<SimplifiedCircuit>();
        private List<SimplifiedCircuit> parallel = new List<SimplifiedCircuit>();
        private TransformedCircuit subcir;

        public TransformedCircuit() { }
        public TransformedCircuit(List<Record> single, List<SimplifiedCircuit> ser, List <SimplifiedCircuit> parallel, TransformedCircuit subcir)
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

        public List<SimplifiedCircuit> getSerial()
        {
            return serial;
        }

        public List<SimplifiedCircuit> getParallel()
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

        public void setSerial(List<SimplifiedCircuit> serial)
        {
            this.serial = serial;
        }

        public void setParallel(List<SimplifiedCircuit> parallel )
        {
           this.parallel =  parallel;
        }

        public void setSubCircuit(TransformedCircuit subcir)
        {
            this.subcir = subcir;
        }
    }
}
