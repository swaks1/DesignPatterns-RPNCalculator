using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculator.CalculatorLogic.Entities
{
    public class EventMessage : EventArgs
    {
        public string Message { get; set; }
    }
}
