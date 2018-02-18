using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculator.CalculatorLogic.Entities
{
    public class BonusOperator : Component
    {
        public CalcBonusFunctions Value { get; set; }

        public BonusOperator(CalcBonusFunctions val)
        {
            Value = val;
        }
    }
}
