using RPNCalculator.CalculatorLogic.Entities;
using RPNCalculator.CalculatorLogic.ExecutionLogic;
using RPNCalculator.CalculatorLogic.Factories;
using RPNCalculator.CalculatorLogic.States;
using RPNCalculator.CalculatorLogic.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculator.CalculatorLogic
{
    public class CalculatorFramework
    {

        public Calculator Calculator { get; set; }
        public IState CurrentState { get; set; }
        public string CurrentInput { get; set; }
        public string SavedProgram { get; set; }

        public event EventHandler RefreshUI;


        public CalculatorFramework()
        {
            Calculator = new Calculator();
            CommandFactory.GetInstance().Calculator = Calculator;
            CurrentInput = "";
            SavedProgram = "";
            CurrentState = new CalculationState(this);
        }


        public void OperandClicked(int num)
        {
            CurrentState.OperandClicked(num);
        }
        public void OperatorClicked(CalcOperation calcOperaiton)
        {
            CurrentState.OperatorClicked(calcOperaiton);
        }

        public void FuncitonButtonClicked(CalcFunction calcFunction)
        {
            CurrentState.FuncitonButtonClicked(calcFunction);
        }

        public void StateButtonClicked(CalcState calcState)
        {
            CurrentState.StateButtonClicked(calcState);
        }

        public void BonusFunctionClicked(CalcBonusFunctions calcBonusFunction)
        {
            CurrentState.BonusFunctionClicked(calcBonusFunction);
        }

        public void TriggerRefreshUI(string message)
        {
            EventMessage eventMessage = new EventMessage { Message = message };
            RefreshUI(this, eventMessage);
        }

        public string GetSavedProgram()
        {
            return SavedProgram;
        }

        public string GetInput()
        {
            return CurrentInput;
        }

        public List<string> GetRegisters()
        {
            return Calculator.Registers;
        }

        public List<Operand> GetLastFour()
        {
            return Calculator.GetLastFour();
        }
        public string GetState()
        {
            return CurrentState.GetType().Name;
        }

        public bool IsInverse()
        {
            return Calculator.Inverse;
        }

        public bool IsRad()
        {
            return Calculator.RAD;
        }


    }
}
