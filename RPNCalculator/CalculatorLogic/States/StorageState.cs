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
    public class StorageState : IState
    {
        CalculatorFramework Framework { get; set; }
        public IStrategy Strategy { get; set; }
        public string ToBeSaved { get; set; }

        public StorageState(CalculatorFramework framework)
        {
            Framework = framework;
            ToBeSaved = Framework.CurrentInput;
            Framework.CurrentInput = "Enter reg to save " + ToBeSaved;
        }
        public void OperandClicked(int num)
        {
            Framework.Calculator.Registers[num] = ToBeSaved;
            Framework.CurrentInput = "";
            StateButtonClicked(CalcState.STO);

        }
        public void OperatorClicked(CalcOperation calcOperaiton)
        {
            Framework.TriggerRefreshUI("You are in Storage state.. Can't use that here");

        }

        public void FuncitonButtonClicked(CalcFunction calcFunction)
        {
            Framework.TriggerRefreshUI("You are in Storage state.. Can't use that here");
            
        }

        public void BonusFunctionClicked(CalcBonusFunctions calcBonusFunction)
        {
            Framework.TriggerRefreshUI("You are in Storage state.. Can't use that here");
        }

        public void StateButtonClicked(CalcState calcState)
        {
            switch (calcState)
            {
                case CalcState.STO:
                    Framework.CurrentInput = "";
                    Framework.CurrentState = new CalculationState(Framework);
                    Framework.TriggerRefreshUI("Changed to Calculation State");
                    break;
                default:
                    Framework.TriggerRefreshUI("Click STO to leave this state");
                    break;
            }
        }


    }
}
