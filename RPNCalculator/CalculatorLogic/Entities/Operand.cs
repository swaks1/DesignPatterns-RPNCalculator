using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculator.CalculatorLogic
{
    //Class used for the operands i.e decimal numbers
    public class Operand : Component
    {
        public double Value { get; set; }

        public Operand(double val)
        {
            Value = val;
        }
    }
}
