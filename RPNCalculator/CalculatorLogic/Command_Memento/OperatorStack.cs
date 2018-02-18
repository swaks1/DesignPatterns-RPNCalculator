using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculator.CalculatorLogic.ExecutionLogic
{
    public class OperandStack 
    {
        public Stack<Operand> MainStack { get; set; }

        public OperandStack()
        {
            MainStack = new Stack<Operand>();
        }

        public void Push(Operand c)
        {
            MainStack.Push(c);
        }
        public Operand Peek()
        {
            return MainStack.Peek();
        }
        public Operand Pop()
        {
            if(MainStack.Count == 0)
            {
                return new Operand(0);
            }
            else
            {
                return MainStack.Pop();
            }
        }
        public OperandStack Clone()
        {
            var newInstance = new OperandStack();
            newInstance.MainStack = new Stack<Operand>();
            foreach(var item in MainStack.Reverse())
            {
                newInstance.MainStack.Push(new Operand(item.Value));
            }

            return newInstance;
        }

       
    }
}
