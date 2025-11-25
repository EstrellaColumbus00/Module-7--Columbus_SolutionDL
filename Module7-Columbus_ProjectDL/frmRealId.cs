using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/* 
 * Estrella Columbus
 * Obj-Orient Prg Using C# (ITD-2343) - Module 7Project 
 * Due Date: October 26, 2025
 */
namespace Module6MethodsProjectDL
{
    public partial class frmRealId : Form
    {
        // Public Contsants to use
        // Public Contsants to use
        const byte ADD = 0;
        const byte SUBTRACT = 1;
        const byte MULTIPLY = 2;
        const byte DIVIDE = 3;
        const byte MODULUS = 4;

        public frmRealId()
        {
            InitializeComponent();
        }

        //Put Your method here

        private double PerformCalculation(double num1, double num2, string operation)
        {
            switch (operation)
            {
                case "+": return num1 + num2;
                case "-": return num1 - num2;
                case "*": return num1 * num2;
                case "/": return num1 / num2;
                case "%": return num1 % num2;
                default: throw new InvalidOperationException("Unsupported operation.");
            }
        }

        private void ExecuteOperation(string operation)
        {
            List<string> errors = new List<string>();
            double num1 = 0, num2 = 0;
            bool leftValid = false, rightValid = false;

            // Validate Left Operand
            if (string.IsNullOrWhiteSpace(txtLeftOperand.Text))
            {
                errors.Add("Left operand cannot be empty.");
            }
            else if (!double.TryParse(txtLeftOperand.Text, out num1))
            {
                errors.Add("Left operand must be a valid number.");
            }
            else
            {
                leftValid = true;
            }

            // Validate Right Operand
            if (string.IsNullOrWhiteSpace(txtRightOperand.Text))
            {
                errors.Add("Right operand cannot be empty.");
            }
            else if (!double.TryParse(txtRightOperand.Text, out num2))
            {
                errors.Add("Right operand must be a valid number.");
            }
            else
            {
                rightValid = true;
            }

            // Additional validation only if both operands are valid
            if (leftValid && rightValid)
            {
                if (operation == "/" && num2 == 0)
                    errors.Add("Cannot divide by zero.");

                if (operation == "%" && (num1 < 0 || num2 < 0))
                    errors.Add("Modulus requires both operands to be non-negative.");

                if (operation == "%" && num2 == 0)
                    errors.Add("Cannot perform modulus with a divisor of zero.");
            }

            // Display errors or result
            if (errors.Count > 0)
            {
                lblResultLabel.ForeColor = Color.Red;
                lblResultLabel.Text = string.Join(Environment.NewLine, errors);
            }
            else
            {
                try
                {
                    double result = PerformCalculation(num1, num2, operation);
                    lblResultLabel.ForeColor = Color.Black;
                    lblResultLabel.Text = $"Result: {result}";
                }
                catch (Exception)
                {
                    lblResultLabel.ForeColor = Color.Red;
                    lblResultLabel.Text = "Unexpected error occurred during calculation.";
                }
            }
        }
        private void lblLeftOperand(object sender, EventArgs e)
        {
         
        }

        private void lblRightOperand(object sender, EventArgs e)
        {
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ExecuteOperation("+");
        }

        private void btnSubtraction_Click(object sender, EventArgs e)
        {
            ExecuteOperation("-");
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            ExecuteOperation("*");
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            ExecuteOperation("/");
        }

        private void btnModulus_Click(object sender, EventArgs e)
        {
            ExecuteOperation("%");
        }


        private void btnClear_click(object sender, EventArgs e)
        {
            txtLeftOperand.Text = "";
            txtRightOperand.Text = "";
            lblResultLabel.Text = "";
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
