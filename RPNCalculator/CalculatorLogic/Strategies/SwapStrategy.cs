using RPNCalculator.CalculatorLogic.ExecutionLogic;
using RPNCalculator.CalculatorLogic.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculator.CalculatorLogic.Strategies
{
    //Strategy which describes the Swap functionality.. It uses CommandFactory go get the command and than delegate the command to the Invoker which
    //controls the UNDO REDO functionality
    public class SwapStrategy : IStrategy
    {
        public string Input { get; set; }

        public SwapStrategy()
        {
        }

        public void ExecuteStrategy()
        {
            Command command;

            command = CommandFactory.GetInstance().GetOperationCommand(CalcOperation.SWAP);
            Invoker.GetInstance().ExecuteCommand(command);
        }
    }
}
