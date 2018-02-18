using RPNCalculator.CalculatorLogic.ExecutionLogic;
using RPNCalculator.CalculatorLogic.Factories;
using RPNCalculator.CalculatorLogic.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculator.CalculatorLogic.States
{
    //Main state thath manages the Calculations requestet by the User.. Communicates with the Framework to get the input form the user, as well 
    //give the output of the requests.. The functionality is made by using Strategy pattern where the requests are encapsulated in Commands
    // which are delegated to Invoker who executes them on the Reciever
    public class CalculationState : IState
    {
        CalculatorFramework Framework { get; set; }
        public IStrategy Strategy { get; set; }

        public CalculationState(CalculatorFramework framework)
        {
            Framework = framework;
        }
        public void OperandClicked(int num)
        {
            Framework.CurrentInput += num;
            Framework.TriggerRefreshUI("Clicked " + num);
        }
        public void OperatorClicked(CalcOperation calcOperaiton)
        {
            switch (calcOperaiton)
            {
                case CalcOperation.ADD:
                    Strategy = new AddStrategy(Framework.CurrentInput);
                    break;

                case CalcOperation.SUB:
                    Strategy = new SubStrategy(Framework.CurrentInput);
                    break;

                case CalcOperation.MUL:
                    Strategy = new MulStrategy(Framework.CurrentInput);
                    break;

                case CalcOperation.DIV:
                    Strategy = new DivStrategy(Framework.CurrentInput);
                    break;

                case CalcOperation.ENTER:
                    Strategy = new EnterStrategy(Framework.CurrentInput);
                    break;

                case CalcOperation.CHS:
                    Strategy = new ChangeSignStrategy();
                    break;

                case CalcOperation.DROP:
                    Strategy = new DropStrategy();
                    break;

                case CalcOperation.SWAP:
                    Strategy = new SwapStrategy();
                    break;
            }

            Strategy.ExecuteStrategy();
            Framework.CurrentInput = "";
            Framework.TriggerRefreshUI("Executed " + calcOperaiton);
        }

        public void FuncitonButtonClicked(CalcFunction calcFunction)
        {
            string response = "";
            switch (calcFunction)
            {
                case CalcFunction.UNDO:
                    response = Invoker.GetInstance().Undo();
                    Framework.TriggerRefreshUI(response);
                    break;

                case CalcFunction.REDO:
                    response = Invoker.GetInstance().Redo();
                    Framework.TriggerRefreshUI(response);
                    break;

                case CalcFunction.DOT:
                    if (!Framework.CurrentInput.Contains("."))
                    {
                        Framework.CurrentInput += ".";
                        Framework.TriggerRefreshUI("Added DOT");
                    }
                    else
                    {
                        Framework.TriggerRefreshUI("You already have DOT");
                    }

                    break;
            }

        }

        public void BonusFunctionClicked(CalcBonusFunctions calcBonusFunction)
        {
            Command command = CommandFactory.GetInstance().GetBonusOperationCommand(calcBonusFunction);

            Invoker.GetInstance().ExecuteCommand(command);
            Framework.CurrentInput = "";
            Framework.TriggerRefreshUI("Executed " + calcBonusFunction);
        }

        public void StateButtonClicked(CalcState calcState)
        {
            switch (calcState)
            {
                case CalcState.STO:
                    if (Framework.CurrentInput != "" && Framework.CurrentInput != ".")
                    {
                        Framework.CurrentState = new StorageState(Framework);
                        Framework.TriggerRefreshUI("Changed to Storage State");
                    }
                    else
                    {
                        Framework.TriggerRefreshUI("Enter operand than press STO");
                    }
                    break;

                case CalcState.RCL:
                    Framework.CurrentState = new RecallState(Framework);
                    Framework.TriggerRefreshUI("Changed to Recall State");
                    break;

                case CalcState.PROG:
                    Framework.CurrentState = new ProgState(Framework);
                    Framework.TriggerRefreshUI("Changed to Prog State.. Enter 20 steps long instruction");
                    break;

                case CalcState.EXE:
                    if (Framework.SavedProgram != "")
                    {
                        var transientState = new ExeState(Framework);
                    }
                    else
                    {
                        Framework.TriggerRefreshUI("First enter Prog than use Exe");
                    }
                    break;
            }
        }


    }
}
