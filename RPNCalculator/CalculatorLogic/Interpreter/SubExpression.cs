using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculator.CalculatorLogic.Interpreter
{
    //Nonterminal expression describing how to subtract two terminal expressions
    public class SubExpression : IExpression
    {
        IExpression FirstExpression;
        IExpression SecondExpression;

        public SubExpression(IExpression first, IExpression second)
        {
            FirstExpression = first;
            SecondExpression = second;
        }

        public double Interpret()
        {
            return FirstExpression.Interpret() - SecondExpression.Interpret();
        }

    }
}
