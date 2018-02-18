using RPNCalculator.CalculatorLogic.ExecutionLogic;
using RPNCalculator.CalculatorLogic.Interpreter;
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
    //Transient state whcih executes the saved program from the user...than transfers the control to Calculation State
    public class ExeState : IState
    {
        CalculatorFramework Framework { get; set; }
        public string ExecutedResult { get; set; }

        public ExeState(CalculatorFramework framework)
        {
            Framework = framework;
            ExecutedResult = "";
            Framework.CurrentInput = "";

            TryParseExpression();
        }

        private void TryParseExpression()
        {
            InterpreterParser parser = new InterpreterParser();
            ExecutedResult = parser.ParseExpression(Framework.SavedProgram);
            StateButtonClicked(CalcState.EXE);
        }

        public void OperandClicked(int num)
        {
            Framework.TriggerRefreshUI("You are in Exec state.. Can't use that here");

        }
        public void OperatorClicked(CalcOperation calcOperaiton)
        {
            Framework.TriggerRefreshUI("You are in Exec state.. Can't use that here");

        }

        public void FuncitonButtonClicked(CalcFunction calcFunction)
        {
            Framework.TriggerRefreshUI("You are in Exec state.. Can't use that here");
            
        }
        public void BonusFunctionClicked(CalcBonusFunctions calcBonusFunction)
        {
            Framework.TriggerRefreshUI("You are in Exec state.. Can't use that here");

        }

        public void StateButtonClicked(CalcState calcState)
        {
            switch (calcState)
            {
                case CalcState.EXE:
                    double result;
                    if (double.TryParse(ExecutedResult, out result))
                        Framework.CurrentInput = ExecutedResult;

                    Framework.CurrentState = new CalculationState(Framework);
                    Framework.TriggerRefreshUI("The Result of " + Framework.SavedProgram + " is " + ExecutedResult);
                    break;
            }
        }


    }
}
