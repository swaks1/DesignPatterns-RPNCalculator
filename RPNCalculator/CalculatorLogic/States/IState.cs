using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculator.CalculatorLogic.States
{
    //Abstract state specifying what operations a state must implement
    public interface IState
    {
        void OperandClicked(int num);
        void OperatorClicked(CalcOperation calcOperaiton);
        void FuncitonButtonClicked(CalcFunction calcFunction);
        void StateButtonClicked(CalcState calcState);
        void BonusFunctionClicked(CalcBonusFunctions calcBonusFunction);
    }
}
