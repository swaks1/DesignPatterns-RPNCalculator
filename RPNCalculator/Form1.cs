using RPNCalculator.CalculatorLogic;
using RPNCalculator.CalculatorLogic.Entities;
using RPNCalculator.CalculatorLogic.ExecutionLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPNCalculator
{
    //Class in which the UserInterface is communicating with the Calculatior Framework.There isnt any logic except refreshing the view when 
    //event is triggered from the framework.
    public partial class Form1 : Form
    {
        CalculatorFramework calcFramework;

        //Init framework class and subscirbe to Event to refresh the view
        public Form1()
        {
            InitializeComponent();
            calcFramework = new CalculatorFramework();
            calcFramework.RefreshUI += RefreshView;

            RefreshView(null, null);
        }

        //Callback called from the framework.. It updates the Message, Last 4 elements on the stack, the Registers etc..
        private void RefreshView(object sender, EventArgs e)
        {
            var message = "";
            var eventMessage = (EventMessage)e;
            if(eventMessage != null)
            {
                message = eventMessage.Message;
            }
            labelMsg.Text = message;

            var lastFour = calcFramework.GetLastFour();
            labelX.Text = lastFour[0].Value.ToString();
            labelY.Text = lastFour[1].Value.ToString();
            labelZ.Text = lastFour[2].Value.ToString();
            labelT.Text = lastFour[3].Value.ToString();

            var Registers = calcFramework.GetRegisters();
            lblReg0.Text = Registers[0]; lblReg1.Text = Registers[1]; lblReg2.Text = Registers[2]; 
            lblReg3.Text = Registers[3]; lblReg4.Text = Registers[4]; lblReg5.Text = Registers[5];
            lblReg6.Text = Registers[6]; lblReg7.Text = Registers[7]; lblReg8.Text = Registers[8];
            lblReg9.Text = Registers[9];

            labelInput.Text = calcFramework.GetInput();            
            labelState.Text = calcFramework.GetState();

            var savedProgram = calcFramework.GetSavedProgram();
            if(savedProgram != "")
            {
                lblSavedProgram.Visible = true;
                pnlSavedProgram.Visible = true;
                labelSavedProg.Visible = true;
                labelSavedProg.Text = savedProgram;
            }

            var isRad = calcFramework.IsRad();
            var isInverse = calcFramework.IsInverse();

            if (isRad)
                lblDegree.Text = "RAD";
            else
                lblDegree.Text = "DEG";

            if (isInverse)
                lblInverse.Text = "YES";
            else
                lblInverse.Text = "NO";
        }

        // ===== OPERANDS =======
        private void btn0_Click(object sender, EventArgs e)
        {
            calcFramework.OperandClicked(0);
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            calcFramework.OperandClicked(1);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            calcFramework.OperandClicked(2);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            calcFramework.OperandClicked(3);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            calcFramework.OperandClicked(4);
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            calcFramework.OperandClicked(5);
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            calcFramework.OperandClicked(6);
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            calcFramework.OperandClicked(7);
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            calcFramework.OperandClicked(8);
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            calcFramework.OperandClicked(9);
        }

        // ===== OPERATORS =======
        private void btnEnter_Click(object sender, EventArgs e)
        {
            calcFramework.OperatorClicked(CalcOperation.ENTER);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            calcFramework.OperatorClicked(CalcOperation.ADD);
        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            calcFramework.OperatorClicked(CalcOperation.SUB);
        }

        private void btnMul_Click(object sender, EventArgs e)
        {
            calcFramework.OperatorClicked(CalcOperation.MUL);
        }
        private void btnDiv_Click(object sender, EventArgs e)
        {
            calcFramework.OperatorClicked(CalcOperation.DIV);
        }

        private void btnChs_Click(object sender, EventArgs e)
        {
            calcFramework.OperatorClicked(CalcOperation.CHS);
        }

        private void btnDro_Click(object sender, EventArgs e)
        {
            calcFramework.OperatorClicked(CalcOperation.DROP);
        }

        private void btnSwa_Click(object sender, EventArgs e)
        {
            calcFramework.OperatorClicked(CalcOperation.SWAP);
        }

        // ===== FUNCTIONS =======
        private void btnDot_Click(object sender, EventArgs e)
        {
            calcFramework.FuncitonButtonClicked(CalcFunction.DOT);
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            calcFramework.FuncitonButtonClicked(CalcFunction.UNDO);
        }

        private void btnRedo_Click(object sender, EventArgs e)
        {
            calcFramework.FuncitonButtonClicked(CalcFunction.REDO);
        }

        // ===== STATES =======
        private void btnSto_Click(object sender, EventArgs e)
        {
            calcFramework.StateButtonClicked(CalcState.STO);
        }

        private void btnRcl_Click(object sender, EventArgs e)
        {
            calcFramework.StateButtonClicked(CalcState.RCL);
        }

        private void btnPro_Click(object sender, EventArgs e)
        {
            calcFramework.StateButtonClicked(CalcState.PROG);
        }

        private void btnExe_Click(object sender, EventArgs e)
        {
            calcFramework.StateButtonClicked(CalcState.EXE);
        }


        // ====== New Bonus Functions =====
        private void btnInv_Click(object sender, EventArgs e)
        {
            calcFramework.BonusFunctionClicked(CalcBonusFunctions.INV);
        }

        private void btnAngle_Click(object sender, EventArgs e)
        {
            calcFramework.BonusFunctionClicked(CalcBonusFunctions.ANGLE);
        }

        private void btnTan_Click(object sender, EventArgs e)
        {
            calcFramework.BonusFunctionClicked(CalcBonusFunctions.TAN);
        }

        private void btnCos_Click(object sender, EventArgs e)
        {
            calcFramework.BonusFunctionClicked(CalcBonusFunctions.COS);
        }

        private void btnSin_Click(object sender, EventArgs e)
        {
            calcFramework.BonusFunctionClicked(CalcBonusFunctions.SIN);
        }
    }
}
