﻿using RPNCalculator.CalculatorLogic.ExecutionLogic;
using RPNCalculator.CalculatorLogic.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculator.CalculatorLogic.Strategies
{
    public class AddStrategy : IStrategy
    {
        public string Input { get; set; }

        public AddStrategy(string input)
        {
            Input = input;
        }

        public void ExecuteStrategy()
        {
            Command command;
            if (Input != "" && Input != ".")
            {
                command = CommandFactory.GetInstance().GetEnterCommand(Input);
                Invoker.GetInstance().ExecuteCommand(command);
            }

            command = CommandFactory.GetInstance().GetOperationCommand(CalcOperation.ADD);
            Invoker.GetInstance().ExecuteCommand(command);
        }
    }
}
