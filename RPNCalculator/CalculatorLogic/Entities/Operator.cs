using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculator.CalculatorLogic
{
    public class Operator : Component
    {
        public CalcOperation Value { get; set; }

        public Operator(CalcOperation val)
        {
            Value = val;
        }
    }
}
