using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        string a = "";
        double ans = 0;
        string last = "null";
        public Form1()
        {
            InitializeComponent();
        }

        private void Divide(ref double ans, string a)
        {
            try { ans /= Convert.ToDouble(a); }
            catch(Exception e)
            {
                MessageBox.Show(e.Message + e.StackTrace);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text += "1";
            label2.Text += "1";
            a += '1';
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text += "2";
            label2.Text += "2";
            a += '2';
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label1.Text += "3";
            label2.Text += "3";
            a += '3';
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label1.Text += "4";
            label2.Text += "4";
            a += '4';
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label1.Text += "5";
            label2.Text += "5";
            a += '5';
        }

        private void button6_Click(object sender, EventArgs e)
        {
            label1.Text += "6";
            label2.Text += "6";
            a += '6';
        }

        private void button7_Click(object sender, EventArgs e)
        {
            label1.Text += "7";
            label2.Text += "7";
            a += '7';
        }

        private void button8_Click(object sender, EventArgs e)
        {
            label1.Text += "8";
            label2.Text += "8";
            a += '8';
        }

        private void button9_Click(object sender, EventArgs e)
        {
            label1.Text += "9";
            label2.Text += "9";
            a += '9';
        }

        private void button10_Click(object sender, EventArgs e)
        {
            label1.Text += "0";
            label2.Text += "0";
            a += '0';
        }

        private void button11_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            label2.Text += "C";
            a = "";
            ans = 0;
        }

        private void button12_Click(object sender, EventArgs e)
        {

            label1.Text += "=";
            label2.Text += "=";
            if (last == "null")
                ans = Convert.ToDouble(a);
            else if (last == "plus")
                ans += Convert.ToDouble(a);
            else if (last == "minus")
                ans -= Convert.ToDouble(a);
            else if (last == "multiply")
                ans *= Convert.ToDouble(a);
            else if (last == "divide")
                Divide(ref ans, a);
            else if (last == "degree")
                ans = Math.Pow(ans, Convert.ToDouble(a));
            label1.Text += ans.ToString();
            last = "null";
            a = ans.ToString();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            label1.Text += "+";
            label2.Text += "+";
            if (last == "null")
                ans = Convert.ToDouble(a);
            else if (last == "plus")
                ans += Convert.ToDouble(a);
            else if (last == "minus")
                ans -= Convert.ToDouble(a);
            else if (last == "multiply")
                ans *= Convert.ToDouble(a);
            else if (last == "divide")
                Divide(ref ans, a);
            else if (last == "degree")
                ans = Math.Pow(ans, Convert.ToDouble(a));
            a = "";
            last = "plus";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            label1.Text += "-";
            label2.Text += "-";
            if (last == "null")
                ans = Convert.ToDouble(a);
            else if (last == "plus")
                ans += Convert.ToDouble(a);
            else if (last == "minus")
                ans -= Convert.ToDouble(a);
            else if (last == "multiply")
                ans *= Convert.ToDouble(a);
            else if (last == "divide")
                Divide(ref ans, a);
            else if (last == "degree")
                ans = Math.Pow(ans, Convert.ToDouble(a));
            a = "";
            last = "minus";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            label1.Text += "*";
            label2.Text += "*";
            if (last == "null")
                ans = Convert.ToDouble(a);
            else if (last == "plus")
                ans += Convert.ToDouble(a);
            else if (last == "minus")
                ans -= Convert.ToDouble(a);
            else if (last == "multiply")
                ans *= Convert.ToDouble(a);
            else if (last == "divide")
                Divide(ref ans, a);
            else if (last == "degree")
                ans = Math.Pow(ans, Convert.ToDouble(a));
            a = "";
            last = "multiply";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            label1.Text += "/";
            label2.Text += "/";
            if (last == "null")
                ans = Convert.ToDouble(a);
            else if (last == "plus")
                ans += Convert.ToDouble(a);
            else if (last == "minus")
                ans -= Convert.ToDouble(a);
            else if (last == "multiply")
                ans *= Convert.ToDouble(a);
            else if (last == "divide")
                Divide(ref ans, a);
            else if (last == "degree")
                ans = Math.Pow(ans, Convert.ToDouble(a));
            a = "";
            last = "divide";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            label1.Text += "^";
            label2.Text += "^";
            if (last == "null")
                ans = Convert.ToDouble(a);
            else if (last == "plus")
                ans += Convert.ToDouble(a);
            else if (last == "minus")
                ans -= Convert.ToDouble(a);
            else if (last == "multiply")
                ans *= Convert.ToDouble(a);
            else if (last == "divide")
                Divide(ref ans, a);
            else if (last == "degree")
                ans = Math.Pow(ans, Convert.ToDouble(a));
            a = "";
            last = "degree";
        }

        private void button18_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("C:/Program Files (x86)/Steam/Steam.exe");
        }
    }
}
