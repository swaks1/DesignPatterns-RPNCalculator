using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculator.CalculatorLogic.Entities
{
    //Class that describes the bonus operators (sin, cos,tan,inv,angle)
    public class BonusOperator : Component
    {
        public CalcBonusFunctions Value { get; set; }

        public BonusOperator(CalcBonusFunctions val)
        {
            Value = val;
        }
    }
}
