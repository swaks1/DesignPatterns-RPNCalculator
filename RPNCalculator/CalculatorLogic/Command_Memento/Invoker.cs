using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculator.CalculatorLogic.ExecutionLogic
{
    //Invoker class whcih controls the undo redo stacks, and also knows when to execute the command
    public class Invoker
    {
        private static Stack<CommandWithMemento> UndoStack = new Stack<CommandWithMemento>();
        private static Stack<CommandWithMemento> RedoStack = new Stack<CommandWithMemento>();
        private static Invoker Instance = null;

        private Invoker(){}

        public static Invoker GetInstance()
        {
            if (Instance == null)
            {
                Instance = new Invoker();
            }
            return Instance;
        }

        public bool UndoPossible()
        {
            return UndoStack.Count > 0;
        }

        public bool RedoPossible()
        {
            return RedoStack.Count > 0;
        }

        public void ExecuteCommand(Command commandObj)
        {
            var obj = new CommandWithMemento
            {
                Command = commandObj,
                Memento = commandObj.Execute()
            };

            UndoStack.Push(obj);
            RedoStack.Clear();
        }
        public string Undo()
        {
            if (UndoPossible())
            {
                CommandWithMemento obj = UndoStack.Pop();
                var memento = obj.Memento;
                var command = obj.Command;
                command.Subject.RestoreMemento(memento);
                RedoStack.Push(obj);
                return "Executed Undo: " + command.Action.Method.Name;
            }
            else
            {
                return "Nothing to Undo";
            }
        }

        public string Redo()
        {
            if (RedoPossible())
            {
                var obj = RedoStack.Pop();
                var obj2 = new CommandWithMemento()
                {
                    Command = obj.Command,
                    Memento = obj.Command.Execute()
                };

                UndoStack.Push(obj2);
                return "Executed Redo: " + obj2.Command.Action.Method.Name;
            }
            else
            {
                return "Nothing to Redo";
            }
        }
    }
}
