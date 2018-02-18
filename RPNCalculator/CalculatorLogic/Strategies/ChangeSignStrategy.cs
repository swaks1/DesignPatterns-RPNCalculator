using RPNCalculator.CalculatorLogic.ExecutionLogic;
using RPNCalculator.CalculatorLogic.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculator.CalculatorLogic.Strategies
{
    //Strategy which describes the Change of sign functionality.. It uses CommandFactory go get the command and than delegate the command to the Invoker which
    //controls the UNDO REDO functionality
    public class ChangeSignStrategy : IStrategy
    {
        public string Input { get; set; }

        public ChangeSignStrategy()
        {
        }

        public void ExecuteStrategy()
        {
            Command command;

            command = CommandFactory.GetInstance().GetOperationCommand(CalcOperation.CHS);
            Invoker.GetInstance().ExecuteCommand(command);
        }
    }
}
