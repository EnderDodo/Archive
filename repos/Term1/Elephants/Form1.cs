using System;
using System.Windows.Forms;

namespace Elephants
{
    public partial class Form1 : Form
    {

        private Elephant lucinda;
        private Elephant lloyd;

        public Form1()
        {
            InitializeComponent();
            lucinda = new Elephant() { Name = "Lucinda", EarSize = 33 };
            lloyd = new Elephant() { Name = "Lloyd", EarSize = 40 };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lloyd.WhoAmI();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lucinda.WhoAmI();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Elephant o = lloyd;
            lloyd = lucinda;
            lucinda = o;

            MessageBox.Show("Objects swapped", "Message!");
        }
    }

    class Elephant
    {

        public int EarSize { get; set; }
        public string Name { get; set; }
        public void WhoAmI()
        {
            MessageBox.Show($"My ears are {EarSize} inches tall", $"{Name} says...");
        }

    }
}
