using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculator.CalculatorLogic.ExecutionLogic
{
    //Basic command encapsulating the request from the user.. when executed saves memento from the Reciever (Calculator) and executes the Action
    public class Command
    {
        public Calculator Subject { get; set; }
        public Component Component { get; set; }
        public Action<Component> Action { get; set; }

        public Command(Calculator _subject, Component _component, Action<Component> _action)
        {
            Subject = _subject;
            Component = _component;
            Action = _action;
        }

        public Memento Execute()
        {
            Memento previous = Subject.CreateMemento();
            Action(Component);

            return previous;
        }
    }
}
