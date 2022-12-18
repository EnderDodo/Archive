
namespace MineSweeper
{
    partial class FirstForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button = new System.Windows.Forms.Button();
            this.size1FieldTextBox = new System.Windows.Forms.TextBox();
            this.hintLabel = new System.Windows.Forms.Label();
            this.percentTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.size2FieldTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button
            // 
            this.button.Location = new System.Drawing.Point(101, 273);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(159, 41);
            this.button.TabIndex = 0;
            this.button.Text = "Начать игру!";
            this.button.UseVisualStyleBackColor = true;
            this.button.Click += new System.EventHandler(this.button_Click);
            // 
            // size1FieldTextBox
            // 
            this.size1FieldTextBox.Location = new System.Drawing.Point(101, 45);
            this.size1FieldTextBox.Name = "size1FieldTextBox";
            this.size1FieldTextBox.Size = new System.Drawing.Size(159, 27);
            this.size1FieldTextBox.TabIndex = 1;
            this.size1FieldTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // hintLabel
            // 
            this.hintLabel.AutoSize = true;
            this.hintLabel.Location = new System.Drawing.Point(61, 9);
            this.hintLabel.Name = "hintLabel";
            this.hintLabel.Size = new System.Drawing.Size(249, 20);
            this.hintLabel.TabIndex = 2;
            this.hintLabel.Text = "Введите размер поля (от 10 до 25)";
            // 
            // percentTextBox
            // 
            this.percentTextBox.Location = new System.Drawing.Point(101, 223);
            this.percentTextBox.Name = "percentTextBox";
            this.percentTextBox.Size = new System.Drawing.Size(159, 27);
            this.percentTextBox.TabIndex = 3;
            this.percentTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 186);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(286, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Введите процентное соотношение мин";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(249, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Введите размер поля (от 10 до 25)";
            // 
            // size2FieldTextBox
            // 
            this.size2FieldTextBox.Location = new System.Drawing.Point(101, 135);
            this.size2FieldTextBox.Name = "size2FieldTextBox";
            this.size2FieldTextBox.Size = new System.Drawing.Size(159, 27);
            this.size2FieldTextBox.TabIndex = 5;
            this.size2FieldTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FirstForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 339);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.size2FieldTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.percentTextBox);
            this.Controls.Add(this.hintLabel);
            this.Controls.Add(this.size1FieldTextBox);
            this.Controls.Add(this.button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FirstForm";
            this.Text = "Config";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FirstForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button;
        private System.Windows.Forms.TextBox size1FieldTextBox;
        private System.Windows.Forms.Label hintLabel;
        private System.Windows.Forms.TextBox percentTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox size2FieldTextBox;
    }
}