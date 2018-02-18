using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculator.CalculatorLogic.ExecutionLogic
{
    //wrapper class used for UNDO REDO stacks
    public class CommandWithMemento
    {
        public Command Command { get; set; }
        public Memento Memento { get; set; }
    }
}
