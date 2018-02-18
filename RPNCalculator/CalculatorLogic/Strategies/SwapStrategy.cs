using RPNCalculator.CalculatorLogic.ExecutionLogic;
using RPNCalculator.CalculatorLogic.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculator.CalculatorLogic.Strategies
{
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
