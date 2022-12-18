using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Palyndrom
{
    public partial class Form1 : Form
    {
        bool palyndrom = true;
        public Form1()
        {
            InitializeComponent();
        }

        private void palynd()
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            string a = textBox1.Text;
            System.Text.StringBuilder ab = new System.Text.StringBuilder(a);
            for (int i = 0; i < ab.Length; i++)
            {
                ab[i] = System.Char.ToLower(ab[i]);
            }
            ab = ab.Replace(" ", "");
            for (int i = 0; i < ab.Length / 2; i++)
            {
                if (ab[i] != ab[ab.Length - i - 1])
                {
                    palyndrom = false;
                    break;
                }
            }
            if (palyndrom)
                label2.Text = "Поздравляем! У вас палиндром!";
            else label2.Text = "Сожалею, но у вас обычный текст.";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            palyndrom = true;
            label2.Text = "";
        }
    }
}
