using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculator.CalculatorLogic.Entities
{
    //Class used to transfer some Message from the Calculator Framework to the UI..
    public class EventMessage : EventArgs
    {
        public string Message { get; set; }
    }
}
