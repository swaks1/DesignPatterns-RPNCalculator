using RPNCalculator.CalculatorLogic.Entities;
using RPNCalculator.CalculatorLogic.ExecutionLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculator.CalculatorLogic.Factories
{
    //Class implementing the Factory Pattern and the Singlton pattern.. Used for createing differnet kinds of Commands used in the system
    public class CommandFactory
    {
        private static CommandFactory Instance = null;
        public Calculator Calculator { get; set; }

        private CommandFactory() { }

        public static CommandFactory GetInstance()
        {
            if (Instance == null)
            {
                Instance = new CommandFactory();
            }
            return Instance;
        }

        public Command GetEnterCommand(string input)
        {
            Command command = null;
            if (!string.IsNullOrEmpty(input)){
                var num = double.Parse(input);
                command = new Command(Calculator, new Operand(num), Calculator.Enter);
            }

            return command;
        }

        public Command GetOperationCommand(CalcOperation operation)
        {
            switch (operation)
            {
                case CalcOperation.ADD:
                    return new Command(Calculator, new Operator(CalcOperation.ADD), Calculator.Add);

                case CalcOperation.SUB:
                    return new Command(Calculator, new Operator(CalcOperation.SUB), Calculator.Sub);

                case CalcOperation.MUL:
                    return new Command(Calculator, new Operator(CalcOperation.MUL), Calculator.Mul);

                case CalcOperation.DIV:
                    return new Command(Calculator, new Operator(CalcOperation.DIV), Calculator.Div);

                case CalcOperation.CHS:
                    return new Command(Calculator, new Operator(CalcOperation.CHS), Calculator.ChangeSign);

                case CalcOperation.DROP:
                    return new Command(Calculator, new Operator(CalcOperation.DROP), Calculator.Drop);

                case CalcOperation.SWAP:
                    return new Command(Calculator, new Operator(CalcOperation.SWAP), Calculator.Swap);

                default:
                    return null;
            }
        }
        public Command GetBonusOperationCommand(CalcBonusFunctions operation)
        {
            switch (operation)
            {
                case CalcBonusFunctions.COS:
                    return new Command(Calculator, new BonusOperator(CalcBonusFunctions.COS), Calculator.Cos);

                case CalcBonusFunctions.TAN:
                    return new Command(Calculator, new BonusOperator(CalcBonusFunctions.TAN), Calculator.Tan);

                case CalcBonusFunctions.SIN:
                    return new Command(Calculator, new BonusOperator(CalcBonusFunctions.SIN), Calculator.Sin);

                case CalcBonusFunctions.INV:
                    return new Command(Calculator, new BonusOperator(CalcBonusFunctions.INV), Calculator.Inv);

                case CalcBonusFunctions.ANGLE:
                    return new Command(Calculator, new BonusOperator(CalcBonusFunctions.ANGLE), Calculator.Angle);

                default:
                    return null;
            }
        }
    }
}
