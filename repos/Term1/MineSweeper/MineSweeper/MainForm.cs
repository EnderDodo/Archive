using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweeper
{
    public partial class MainForm : Form
    {

        private readonly int size1Field;
        private readonly int size2Field;
        private readonly int countBombs;
        private int currentCountOpenedCells = 0;

        private const int HEIGHT_BUTTON = 40;
        private const int WIDTH_BUTTON = 40;
        private const int HEIGHT_PANEL = 70;

        private Label countBombsLabel;
        private Button[,] fieldButtons;
        private int[,] field;

        private bool isFirstClick = true;
        private bool isLose = false;

        private Random random;

        private readonly FirstForm firstForm;

        public MainForm(FirstForm firstForm, int size1Field, int size2Field, int countBombs)
        {
            InitializeComponent();
            this.size1Field = size1Field;
            this.size2Field = size2Field;
            this.firstForm = firstForm;
            this.countBombs = countBombs;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitForm();
            InitPanel();
            InitButtons();
        }

        private void InitForm()
        {
            this.Text = "MineSweeper";
            this.Width = size1Field * WIDTH_BUTTON + 18;
            this.Height = HEIGHT_PANEL + size2Field * HEIGHT_BUTTON + HEIGHT_BUTTON + 6;
        }

        private void InitPanel()
        {
            countBombsLabel = new Label();

            Font labelFont = new Font("Arial", 20, FontStyle.Bold);

            countBombsLabel.Font = labelFont;
            countBombsLabel.ForeColor = Color.Black;
            countBombsLabel.Text = countBombs.ToString();

            countBombsLabel.AutoSize = true;
            countBombsLabel.Location = new Point(10, 15);
            this.Controls.Add(countBombsLabel);
        }

        private void InitButtons()
        {
            fieldButtons = new Button[size2Field, size1Field];
            Font buttonFont = new Font("Arial", 12, FontStyle.Bold);

            for (int i = 0, idButton = 0; i < size2Field; i++)
            {
                for (int j = 0; j < size1Field; j++)
                {
                    fieldButtons[i, j] = new Button();
                    fieldButtons[i, j].Text = "";
                    fieldButtons[i, j].BackColor = Color.Gray;

                    fieldButtons[i, j].FlatStyle = FlatStyle.Flat;
                    fieldButtons[i, j].FlatAppearance.BorderColor = Color.LightGray;
                    fieldButtons[i, j].FlatAppearance.BorderSize = 1;

                    fieldButtons[i, j].Name = idButton.ToString();
                    idButton++;

                    //focus TAB
                    fieldButtons[i, j].TabStop = false;

                    //font
                    fieldButtons[i, j].ForeColor = Color.Black;
                    fieldButtons[i, j].Font = buttonFont;


                    fieldButtons[i, j].Size = new Size(WIDTH_BUTTON, HEIGHT_BUTTON);
                    fieldButtons[i, j].Location = new Point(WIDTH_BUTTON * j, HEIGHT_BUTTON * i + HEIGHT_PANEL);

                    fieldButtons[i, j].Click += ButtonClick;
                    fieldButtons[i, j].MouseUp += MouseUpOnButton;
                    this.Controls.Add(fieldButtons[i, j]);
                }
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isLose)
            {
                Application.Exit();
            }
        }


        private void MouseUpOnButton(object sender, MouseEventArgs e)
        {

            Button clickedButton = sender as Button;

            switch (e.Button)
            {
                case MouseButtons.Right:

                    int countBombs = int.Parse(countBombsLabel.Text);

                    if (clickedButton.Text == "F")
                    {
                        clickedButton.Text = "";
                        countBombsLabel.Text = (countBombs + 1).ToString();
                    }
                    else
                    {
                        clickedButton.Text = "F";
                        countBombsLabel.Text = (countBombs - 1).ToString();
                    }

                    if (int.Parse(countBombsLabel.Text) == 0) // Если все флаги раставлены верно => Победа 
                    {

                        if (isFirstClick) // Если не было первого клика, (field did not init)
                        {
                            return;
                        }

                        int temp = 0;
                        for (int i = 0; i < size2Field; i++)
                        {
                            for (int j = 0; j < size1Field; j++)
                            {
                                if (fieldButtons[i, j].Text == "F" && field[i, j] == -1)
                                {
                                    temp++;
                                }
                            }
                        }

                        if (temp == this.countBombs)
                        {
                            ShowDialog("You win!!!");
                        }
                    }

                    break;
            }

        }


        private void ButtonClick(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            clickedButton.BackColor = Color.White;
            //Click's indexes
            int index = int.Parse(clickedButton.Name) / size1Field;
            int jindex = int.Parse(clickedButton.Name) % size1Field;


            if (isFirstClick)
            {
                InitField(index, jindex);
                ShuffleField(index, jindex);
                InitCountBombs();
                isFirstClick = false;
                RecursionOpeningButton(index, jindex);
                return;
            }

            if (field[index, jindex] == -1)
            {
                isLose = true;
                ShowDialog(message: "You lose");
            }
            else
            {
                RecursionOpeningButton(index, jindex);
            }


            if (CheckWin())
            {
                ShowDialog(message: "You win!!!");
            }

        }


        private async void ShowDialog(string message)
        {

            await Task.Run(() =>
            {
                for (int i = 0; i < size2Field; i++)
                {
                    for (int j = 0; j < size1Field; j++)
                    {
                        if (field[i, j] == -1)
                        {
                            Invoke((MethodInvoker)delegate
                            {
                                fieldButtons[i, j].BackColor = Color.Red;
                                fieldButtons[i, j].Text = "M";
                            });
                        }
                    }
                }
            });

            DialogResult result = MessageBox.Show(
                        message,
                        "Message",
                        MessageBoxButtons.RetryCancel,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.DefaultDesktopOnly
                );

            if (result == DialogResult.Retry)
                ClearField();

            if (result == DialogResult.Cancel)
                Application.Exit();

        }


        private bool CheckWin()
        {

            if (currentCountOpenedCells == size1Field * size2Field - countBombs)
                return true;
            return false;

        }

        private void RecursionOpeningButton(int index, int jindex)
        {
            fieldButtons[index, jindex].BackColor = Color.White;
            fieldButtons[index, jindex].Enabled = false;
            currentCountOpenedCells++;
            countBombsLabel.Focus();

            if (field[index, jindex] == 0)
            {
                fieldButtons[index, jindex].Text = "";
            }
            else
            {
                fieldButtons[index, jindex].Text = field[index, jindex].ToString();
            }

            if (field[index, jindex] == 0)
            {
                for (int i = index - 1; i < index + 2; i++)
                {
                    for (int j = jindex - 1; j < jindex + 2; j++)
                    {
                        if (!IsInBorder(i, j) || !fieldButtons[i, j].Enabled)
                        {
                            continue;
                        }
                        RecursionOpeningButton(i, j);
                    }
                }
            }
            else
            {
                return;
            }
        }

        private void ClearField()
        {
            firstForm.Show();
            this.Close();
        }

        private void InitCountBombs()
        {
            for (int i = 0; i < size2Field; i++)
            {
                for (int j = 0; j < size1Field; j++)
                {
                    if (field[i, j] == -1)
                    {
                        continue;
                    }
                    field[i, j] = CountBombsAroundButton(i, j);
                }
            }
        }

        private int CountBombsAroundButton(int index, int jindex)
        {
            int countBombs = 0;

            for (int i = index - 1; i < index + 2; i++)
            {
                for (int j = jindex - 1; j < jindex + 2; j++)
                {
                    if (i == index && j == jindex || !IsInBorder(i, j))
                    {
                        continue;
                    }
                    if (field[i, j] == -1)
                    {
                        countBombs++;
                    }
                }
            }

            return countBombs;
        }

        private bool IsInBorder(int i, int j)
        {
            if (i < 0 || j < 0 || j >= size1Field || i >= size2Field)
                return false;
            return true;
        }


        private void InitField(int index, int jindex)
        {
            field = new int[size2Field, size1Field];

            int tempCountBombs = countBombs;

            for (int i = 0; i < size2Field; i++)
            {
                for (int j = 0; j < size1Field; j++)
                {
                    if (tempCountBombs == 0)
                    {
                        return;
                    }

                    if (i == index && j == jindex)
                    {
                        continue; // Перепрыгиваем первый клик
                    }

                    field[i, j] = -1;
                    tempCountBombs--;
                }
            }

        }

        private void ShuffleField(int index, int jindex)
        {
            random = new Random();
            int[] tempArr = new int[size2Field * size1Field];
            ConvertArray(ref tempArr, isTwoDimToOneDim: true);

            int numberFirstClick = (index * size1Field) + jindex; //линейный номер первого клика

            for (int i = tempArr.Length - 1; i >= 0; i--)
            {
                int id = random.Next(i + 1);
                if (numberFirstClick == i || numberFirstClick == id)
                {
                    continue;//пропуск первого клика
                }
                int temp = tempArr[id];
                tempArr[id] = tempArr[i];
                tempArr[i] = temp;
            }
            ConvertArray(ref tempArr, isTwoDimToOneDim: false);
        }

        private void ConvertArray(ref int[] tempArr, bool isTwoDimToOneDim)
        {
            if (isTwoDimToOneDim)
            {
                for (int i = 0, t = 0; i < size2Field; i++)
                {
                    for (int j = 0; j < size1Field; j++)
                    {
                        tempArr[t] = field[i, j];
                        t++;
                    }
                }
            }
            else
            {
                for (int i = 0, t = 0; i < size2Field; i++)
                {
                    for (int j = 0; j < size1Field; j++)
                    {
                        field[i, j] = tempArr[t];
                        t++;
                    }
                }
            }
        }



    }
}
