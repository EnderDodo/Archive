using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweeper
{
    public class NotAcceptableNumberException : Exception
    {
        public NotAcceptableNumberException() { }
        public NotAcceptableNumberException(string message) : base(message) { }
    }
    public partial class FirstForm : Form
    {
        public FirstForm()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            
            try
            {
                int size1Field = int.Parse(size1FieldTextBox.Text);
                int size2Field = int.Parse(size2FieldTextBox.Text);
                int percentMines = int.Parse(percentTextBox.Text);
                if ((size1Field < 10 || size1Field > 25) || (percentMines < 10) || (percentMines > 90) || (size2Field < 10 || size2Field > 25))
                {
                    throw new NotAcceptableNumberException("Для размеров поля приемлемы значения от 10 до 25, для процентного соотношения мин - от 10 до 90.");
                }

                int countBombs = size1Field * size2Field * percentMines / 100;

                MainForm mainForm = new MainForm(this, size1Field, size2Field, countBombs);
                mainForm.Show();
                this.Hide();
            }

            catch (NotAcceptableNumberException)
            {
                MessageBox.Show("Для размеров поля приемлемы значения от 10 до 25, для процентного соотношения мин - от 10 до 90.");
                return;
            }
            catch (FormatException)
            {
                MessageBox.Show("Давай ты сам попробуешь нарисовать такое поле, а я посмотрю." + "\n" + "Просто введи в каждое поле по ОДНОМУ ЧИСЛУ.");
                return;
            }
        }

        private void FirstForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
