using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            SpiceParser parser = new SpiceParser();
            List<Record> circuit = parser.parseNetList("K:\\ifmo\\3_course\\netlists\\netlist1");
            int max_num = Utils.Max_nodes(circuit);
            List<int[]> cap = Utils.getPassiveNodes(circuit, "C");
            List<int[]> nullor = Utils.getNullorNodes(circuit);
            List<int> unconnected = Utils.getUnconnected(circuit);
            bool uncon;
            for (int i =1; i <=5; i++)
            {
                 uncon = Utils.isUnconnected(unconnected, i);
            }
            List<List<Record>> new_cirs = Adder.addParallelElement(circuit);

            Console.WriteLine("Hello!");
            //Application.EnableVisualStyles();
          //  Application.SetCompatibleTextRenderingDefault(false);
           // Application.Run(new Form1());
        }
    }
}
