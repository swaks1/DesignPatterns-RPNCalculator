using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculator.CalculatorLogic.ExecutionLogic
{
    
    public class Memento
    {
        private Calculator state;

        public Memento(Calculator _state)
        {
            state = new Calculator();
            state.OperandStack = _state.OperandStack.Clone();
            state.Inverse = _state.Inverse;
            state.RAD = _state.RAD;
        }

        public Calculator Restore()
        {
            return state;
        }
    }
}
