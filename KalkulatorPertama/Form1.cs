using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace KalkulatorPertama
{
    public partial class Form1 : Form
    {
        public static string num1 = "0";
        public static string operation = "";
        public static string num2 = "";
        public static bool validInt = false;

        public Form1()
        {
            InitializeComponent();
            this.KeyPress += Form1_KeyPress;
            setText();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                Debug.WriteLine("it is Char!");
                //numberButtonHandler(e.KeyChar.ToString());
            }
            else if (e.KeyChar == (char)Keys.Enter)
            {
                Debug.WriteLine("it is Enter!");
                //calculate();
            }
            else if (e.KeyChar == '+' || e.KeyChar == '-' || e.KeyChar == '/' || e.KeyChar == '*')
            {
                Debug.WriteLine("it is Operation!");
                //operationHandler(e.KeyChar.ToString());
            }
        }

        public void clear()
        {
            num1 = "0";
            operation = "";
            num2 = "";
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        public void setText()
        {
            if (operation != "" && num2 != "")
            {
                label1.Text = num1 + " " + operation + " " + num2;
                return;
            }

            if (operation != "" && num2 == "")
            {
                label1.Text = num1 + " " + operation + " ...";
                return;
            }

            label1.Text = num1;
        }

        public void numberButtonHandler(string number)
        {
            if (operation != "" && num2 != "")
            {
                num2 += number;
                setText();
                return;
            }

            if (operation != "" && num2 == "")
            {
                num2 = number;
                setText();
                return;
            }

            if (num1 != "0")
            {
                num1 += number;
                setText();
                return;
            }

            num1 = number;
            setText();
        }

        public void operationHandler(string Operator)
        {
            operation = Operator;
            setText();
        }

        public void calculate()
        {
            string result = "undefined";

            if (label1.Text.Split(' ').Length == 1)
            {
                setText();
            }

            if (operation == "" && num2 == "")
            {
                MessageBox.Show("Choose operation!");
                clear();
                return;
            }

            if (num1 == "0" && operation == "" && num2 == "")
            {
                MessageBox.Show("Do some math!");
                clear();
                return;
            }

            int number1 = Convert.ToInt32(num1);
            int number2 = Convert.ToInt32(num2);
            switch (operation)
            {
                case "+":
                    result = $"{number1 + number2}";
                    break;
                case "-":
                    result = $"{number1 - number2}";
                    break;
                case "*":
                    result = $"{number1 * number2}";
                    break;
                case "/":
                    result = $"{number1 / number2}";
                    break;
                default:
                    break;
            }
            label1.Text = result;
            clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            numberButtonHandler("1");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            numberButtonHandler("3");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            numberButtonHandler("4");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            numberButtonHandler("2");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            numberButtonHandler("5");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            numberButtonHandler("6");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            numberButtonHandler("7");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            numberButtonHandler("8");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            numberButtonHandler("9");
        }

        private void button0_Click(object sender, EventArgs e)
        {
            numberButtonHandler("0");
        }

        private void total(object sender, EventArgs e)
        {
            calculate();
        }

        private void plus(object sender, EventArgs e)
        {
            operationHandler("+");
        }

        private void minus(object sender, EventArgs e)
        {
            operationHandler("-");
        }

        private void divide_Click(object sender, EventArgs e)
        {
            operationHandler("/");
        }

        private void times_Click(object sender, EventArgs e)
        {
            operationHandler("*");
        }
    }
}
