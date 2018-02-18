using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RPNCalculator.CalculatorLogic.Interpreter
{
    //Parser class, implementing the Interpreter Pattern. Used for interpreting the Program which is entered from the user
    public class InterpreterParser
    {
        Stack<IExpression> ExpressionStack = new Stack<IExpression>();

        public string ParseExpression(string fullExpression)
        {
            try
            {
                // split to individual expressions
                var expressionList = Regex.Split(fullExpression, @"\s+").ToList();
                expressionList.RemoveAll(e => String.IsNullOrEmpty(e.Trim()));

                foreach (var expr in expressionList)
                {
                    if (IsOperator(expr))
                    {
                        IExpression firstOperand = ExpressionStack.Pop();
                        IExpression secondOperand = ExpressionStack.Pop();
                        IExpression operatorExpression = GetOperatorExpression(expr, firstOperand, secondOperand);

                        double result = operatorExpression.Interpret();

                        ExpressionStack.Push(new NumberExpression(result.ToString()));
                    }
                    else
                    {
                        IExpression operandExpression = new NumberExpression(expr);
                        ExpressionStack.Push(operandExpression);
                    }
                }

                return ExpressionStack.Pop().Interpret().ToString();
            }
            catch (Exception e)
            {

                return "Error parsing..." + e.Message;
            }

        }

        public bool IsOperator(string str)
        {
            if (str =="+" || str =="-" || str =="*" || str=="/")
                return true;           
            return false;
        }

        public IExpression GetOperatorExpression(string operatorStr, IExpression first, IExpression second)
        {
            switch (operatorStr)
            {
                case "+":
                    return new AddExpression(first, second);
                case "-":
                    return new SubExpression(first, second);
                case "*":
                    return new MultiplyExpression(first, second);
                case "/":
                    return new DivideExpression(first, second);
            }
            return null;
        }
    }
}
