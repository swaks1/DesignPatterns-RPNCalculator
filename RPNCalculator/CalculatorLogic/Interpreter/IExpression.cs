using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculator.CalculatorLogic.Interpreter
{
    //base abstract expression
    public interface IExpression
    {
        double Interpret();
    }
}
