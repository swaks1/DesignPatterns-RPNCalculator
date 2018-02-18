using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculator.CalculatorLogic.ExecutionLogic
{
    public class CommandWithMemento
    {
        public Command Command { get; set; }
        public Memento Memento { get; set; }
    }
}
