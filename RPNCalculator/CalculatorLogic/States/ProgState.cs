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
    public class ProgState : IState
    {
        CalculatorFramework Framework { get; set; }
        public IStrategy Strategy { get; set; }
        public string ToBeSaved { get; set; }

        public ProgState(CalculatorFramework framework)
        {
            Framework = framework;
            Framework.CurrentInput = "";
        }
        public void OperandClicked(int num)
        {
            Framework.CurrentInput +=num;
            Framework.TriggerRefreshUI("");
        }
        public void OperatorClicked(CalcOperation calcOperaiton)
        {
            switch (calcOperaiton)
            {
                case CalcOperation.ADD:
                    Framework.CurrentInput += " + ";
                    break;

                case CalcOperation.SUB:
                    Framework.CurrentInput += " - ";
                    break;

                case CalcOperation.MUL:
                    Framework.CurrentInput += " *  ";
                    break;

                case CalcOperation.DIV:
                    Framework.CurrentInput += " /  ";
                    break;

                case CalcOperation.ENTER:
                    Framework.CurrentInput += " ";
                    break;
                default:
                    Framework.TriggerRefreshUI("You are in PROG state.. Can't use that here");
                    break;


            }
            Framework.TriggerRefreshUI("Added to expression");
        }

        public void FuncitonButtonClicked(CalcFunction calcFunction)
        {
            switch (calcFunction)
            {
                case CalcFunction.DOT:
                        Framework.CurrentInput += ".";
                        Framework.TriggerRefreshUI("Added DOT");
                    break;
                default:
                    Framework.TriggerRefreshUI("You are in PROG state.. Can't use that here");
                    break;
            }

        }

        public void BonusFunctionClicked(CalcBonusFunctions calcBonusFunction)
        {
            Framework.TriggerRefreshUI("You are in PROG state.. Can't use that here");
        }

        public void StateButtonClicked(CalcState calcState)
        {
            switch (calcState)
            {
                case CalcState.PROG:
                    Framework.SavedProgram = Framework.CurrentInput;
                    Framework.CurrentInput = "";
                    Framework.CurrentState = new CalculationState(Framework);
                    Framework.TriggerRefreshUI("Changed to Calculation State");
                    break;

                case CalcState.EXE:
                    Framework.SavedProgram = Framework.CurrentInput;
                    Framework.CurrentInput = "";
                    var transitState =  new ExeState(Framework);
                    break;

                default:
                    Framework.TriggerRefreshUI("Click PROG to leave this state");
                    break;
            }
        }

    }
}
