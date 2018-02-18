using RPNCalculator.CalculatorLogic.ExecutionLogic;
using RPNCalculator.CalculatorLogic.Strategies;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RPNCalculator.CalculatorLogic.States
{
    //A state where user enters number of register which will be loaded in the calculator
    public class RecallState : IState
    {
        CalculatorFramework Framework { get; set; }
        public IStrategy Strategy { get; set; }
        public string LoadedNumber { get; set; }

        public RecallState(CalculatorFramework framework)
        {
            Framework = framework;
            LoadedNumber = "";
            Framework.CurrentInput = "Enter reg to load from: ";
        }
        public void OperandClicked(int num)
        {
            LoadedNumber = Framework.Calculator.Registers[num];
            StateButtonClicked(CalcState.RCL);

        }
        public void OperatorClicked(CalcOperation calcOperaiton)
        {
            Framework.TriggerRefreshUI("You are in Recall state.. Can't use that here");

        }

        public void FuncitonButtonClicked(CalcFunction calcFunction)
        {
            Framework.TriggerRefreshUI("You are in Recall state.. Can't use that here");
            
        }

        public void BonusFunctionClicked(CalcBonusFunctions calcBonusFunction)
        {
            Framework.TriggerRefreshUI("You are in Recall state.. Can't use that here");
        }

        public void StateButtonClicked(CalcState calcState)
        {
            switch (calcState)
            {
                case CalcState.RCL:
                    Framework.CurrentInput = LoadedNumber;
                    Framework.CurrentState = new CalculationState(Framework);
                    Framework.TriggerRefreshUI("Changed to Calculation State");
                    break;
                default:
                    Framework.TriggerRefreshUI("Click RCL to leave this state");
                    break;
            }
        }


    }
}
