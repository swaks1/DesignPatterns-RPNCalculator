using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculator.CalculatorLogic.Interpreter
{
    public class NumberExpression : IExpression
    {
        public double Value { get; set; }

        public NumberExpression(string number)
        {
            Value = double.Parse(number);
        }
        public double Interpret()
        {
            return Value;
        }
    }
}
