using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculator.CalculatorLogic
{
    public enum CalcOperation
    {
        ADD,
        SUB,
        MUL,
        DIV,
        ENTER,
        CHS,
        DROP,
        SWAP
    }

    public enum CalcFunction
    {
        DOT,
        UNDO,
        REDO
    }
    public enum CalcState
    {
        STO,
        RCL,
        PROG,
        EXE
    }

    public enum CalcBonusFunctions
    {
        COS,
        SIN,
        TAN,
        INV,
        ANGLE
    }
}
