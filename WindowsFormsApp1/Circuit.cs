using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
     enum Type{
        RLC, 
        RC,
        RL,
        LC
    }
    enum Func
    {
        I,
        U, 
        Ki,
        Ku
    }
    class Circuit
    {
        private int type;
        private int func;
        private int degree;
        private String numerator;
        private String denominator;
        public Circuit() { }
        public Circuit(int type, int func, int degree, String numerator, String denominator)
        {
            this.type = type;
            this.func = func;
            this.degree = degree;
            this.numerator = numerator;
            this.denominator = denominator;
          
        }
        public int getType()
        {
            return type;
        }

        public int getFunc()
        {
            return func;
        }

        public int getDegree()
        {
            return degree;
        }

        public void setType(int type)
        {
            this.type = type;
        }

        public void setDegree(int degree)
        {
            this.degree = degree;
        }

        public void setFunc(int func)
        {
            this.func = func;
        }

    }
}
