using RPNCalculator.CalculatorLogic.ExecutionLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculator.CalculatorLogic
{
    
    public class Calculator
    {
        public OperandStack OperandStack { get; set; }
        public List<string> Registers { get; set; }
        public bool Inverse { get; set; }
        public bool RAD { get; set; }

        public Calculator()
        {
            OperandStack = new OperandStack();
            OperandStack.Push(new Operand(0));
            OperandStack.Push(new Operand(0));
            OperandStack.Push(new Operand(0));
            OperandStack.Push(new Operand(0));

            Registers = new List<string>();
            for (int i = 0; i < 10; i++)
                Registers.Add("0");

            Inverse = RAD = false;
        }

        public Memento CreateMemento()
        {
            return new Memento(this);
        }
        public void RestoreMemento(Memento m)
        {
            OperandStack = m.Restore().OperandStack.Clone();
            Inverse = m.Restore().Inverse;
            RAD = m.Restore().RAD;

        }

        public void Add(Component c)
        {
            var operatorA = OperandStack.Pop();
            var operatorB = OperandStack.Pop();
            var result = operatorA.Value + operatorB.Value;

            OperandStack.Push(new Operand(result));
        }

        public void Sub(Component c)
        {
            var operatorA = OperandStack.Pop();
            var operatorB = OperandStack.Pop();
            var result = operatorA.Value - operatorB.Value;

            OperandStack.Push(new Operand(result));
        }

        public void Mul(Component c)
        {
            var operatorA = OperandStack.Pop();
            var operatorB = OperandStack.Pop();
            var result = operatorA.Value * operatorB.Value;

            OperandStack.Push(new Operand(result));
        }

        public void Div(Component c)
        {
            var operatorA = OperandStack.Pop();
            var operatorB = OperandStack.Pop();
            var result = operatorA.Value / operatorB.Value;

            OperandStack.Push(new Operand(result));
        }

        public void Enter(Component c)
        {
            OperandStack.Push((Operand)c);
        }

        public void Swap(Component c)
        {
            var operatorA = OperandStack.Pop();
            var operatorB = OperandStack.Pop();

            OperandStack.Push(operatorA);
            OperandStack.Push(operatorB);
        }

        public void ChangeSign(Component c)
        {
            var operatorA = OperandStack.Pop();
            operatorA.Value = operatorA.Value * -1;

            OperandStack.Push(operatorA);
        }

        public void Drop(Component c)
        {
            var operatorA = OperandStack.Pop();
        }

        public void Angle(Component c)
        {
            RAD = !RAD;
        }
        public void Inv(Component obj)
        {
            Inverse = !Inverse;
        }

        public void Cos(Component obj)
        {
            var operatorA = OperandStack.Pop();
            double angle = operatorA.Value;
            if (RAD == false)
            {
                angle = angle * Math.PI / 180;
            }
            operatorA.Value = Inverse ? Math.Acos(angle) : Math.Cos(angle);

            OperandStack.Push(operatorA);
        }

        public void Tan(Component obj)
        {
            var operatorA = OperandStack.Pop();
            double angle = operatorA.Value;
            if (RAD == false)
            {
                angle = angle * Math.PI / 180;
            }
            operatorA.Value = Inverse ? Math.Atan(angle) : Math.Tan(angle);

            OperandStack.Push(operatorA);
        }

        public void Sin(Component obj)
        {
            var operatorA = OperandStack.Pop();
            double angle = operatorA.Value;
            if (RAD == false)
            {
                angle = angle * Math.PI / 180;
            }
            operatorA.Value = Inverse ? Math.Asin(angle) : Math.Sin(angle);

            OperandStack.Push(operatorA);
        }


        public List<Operand> GetLastFour()
        {
            var list = new List<Operand>();
            for(int i = 0; i <= 3; i++)
            {
                list.Add(OperandStack.Pop());
            }
            
            for (int i = 3; i >= 0; i--)
            {
                OperandStack.Push(list[i]);
            }

            return list;
        }


    }
}
