using static System.Formats.Asn1.AsnWriter;

namespace Clicker_v2
{
    partial class Clicker
    {
        private System.ComponentModel.IContainer components = null;
        private DrawPanelBoard drawPanelBoard;
        private DrawPanelTimerIndicator drawPanelTimerIndicator;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Clicker));
            this.drawPanelBoard = new DrawPanelBoard();
            this.drawPanelTimerIndicator = new DrawPanelTimerIndicator();
            this.comboBoxMaxTime = new ComboBox();
            this.comboBoxInterval = new ComboBox();
            this.richTextBoxCountDown = new RichTextBox();
            this.richTextBoxDisplaySomething = new RichTextBox();
            this.pictureBox1 = new PictureBox();
            this.textBoxCoords = new TextBox();
            this.textBox2 = new TextBox();
            this.textBoxHitMiss = new TextBox();
            this.textBoxDisplayScore = new TextBox();
            this.pictureBox2 = new PictureBox();
            this.pictureBox3 = new PictureBox();
            this.textBox1 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.pictureBox3).BeginInit();
            this.SuspendLayout();
            // 
            // drawPanelBoard
            // 
            this.drawPanelBoard.BackColor = Color.Black;
            this.drawPanelBoard.BorderStyle = BorderStyle.FixedSingle;
            this.drawPanelBoard.Location = new Point(236, 128);
            this.drawPanelBoard.Margin = new Padding(4, 3, 4, 3);
            this.drawPanelBoard.Name = "drawPanelBoard";
            this.drawPanelBoard.Size = new Size(1334, 751);
            this.drawPanelBoard.TabIndex = 0;
            // 
            // drawPanelTimerIndicator
            // 
            this.drawPanelTimerIndicator.BackColor = Color.Green;
            this.drawPanelTimerIndicator.BorderStyle = BorderStyle.Fixed3D;
            this.drawPanelTimerIndicator.Location = new Point(1035, 12);
            this.drawPanelTimerIndicator.Name = "drawPanelTimerIndicator";
            this.drawPanelTimerIndicator.Size = new Size(535, 110);
            this.drawPanelTimerIndicator.TabIndex = 0;
            // 
            // comboBoxMaxTime
            // 
            this.comboBoxMaxTime.FormattingEnabled = true;
            this.comboBoxMaxTime.Items.AddRange(new object[] { "1000", "2500", "5000", "7500", "10000", "12500", "15000", "17500", "20000" });
            this.comboBoxMaxTime.Location = new Point(14, 167);
            this.comboBoxMaxTime.Margin = new Padding(4, 3, 4, 3);
            this.comboBoxMaxTime.Name = "comboBoxMaxTime";
            this.comboBoxMaxTime.Size = new Size(214, 23);
            this.comboBoxMaxTime.TabIndex = 1;
            this.comboBoxMaxTime.SelectedIndexChanged += this.ComboBoxMaxTime_SelectedIndexChanged;
            // 
            // comboBoxInterval
            // 
            this.comboBoxInterval.FormattingEnabled = true;
            this.comboBoxInterval.Items.AddRange(new object[] { "25", "50", "75", "100", "250", "500", "750", "1000", "1200", "1500", "1750", "2000" });
            this.comboBoxInterval.Location = new Point(14, 128);
            this.comboBoxInterval.Margin = new Padding(4, 3, 4, 3);
            this.comboBoxInterval.Name = "comboBoxInterval";
            this.comboBoxInterval.Size = new Size(214, 23);
            this.comboBoxInterval.TabIndex = 0;
            this.comboBoxInterval.SelectedIndexChanged += this.ComboBoxInterval_SelectedIndexChanged;
            // 
            // richTextBoxCountDown
            // 
            this.richTextBoxCountDown.BackColor = SystemColors.Info;
            this.richTextBoxCountDown.Font = new Font("Courier New", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.richTextBoxCountDown.Location = new Point(1579, 11);
            this.richTextBoxCountDown.Margin = new Padding(4, 3, 4, 3);
            this.richTextBoxCountDown.Name = "richTextBoxCountDown";
            this.richTextBoxCountDown.Size = new Size(214, 110);
            this.richTextBoxCountDown.TabIndex = 2;
            this.richTextBoxCountDown.Text = "\n\nCOUNTDOWN";
            // 
            // richTextBoxDisplaySomething
            // 
            this.richTextBoxDisplaySomething.BackColor = SystemColors.Info;
            this.richTextBoxDisplaySomething.Font = new Font("Courier New", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.richTextBoxDisplaySomething.Location = new Point(236, 12);
            this.richTextBoxDisplaySomething.Margin = new Padding(4, 3, 4, 3);
            this.richTextBoxDisplaySomething.Name = "richTextBoxDisplaySomething";
            this.richTextBoxDisplaySomething.Size = new Size(116, 110);
            this.richTextBoxDisplaySomething.TabIndex = 3;
            this.richTextBoxDisplaySomething.Text = "\nDISPLAY SOMETHING";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = Color.LightGray;
            this.pictureBox1.Image = Properties.Resources.dotted_circles;
            this.pictureBox1.Location = new Point(15, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(214, 110);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // textBoxCoords
            // 
            this.textBoxCoords.BackColor = SystemColors.Info;
            this.textBoxCoords.Font = new Font("Courier New", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.textBoxCoords.Location = new Point(14, 199);
            this.textBoxCoords.Multiline = true;
            this.textBoxCoords.Name = "textBoxCoords";
            this.textBoxCoords.Size = new Size(214, 680);
            this.textBoxCoords.TabIndex = 8;
            this.textBoxCoords.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = SystemColors.Info;
            this.textBox2.Font = new Font("Courier New", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.textBox2.Location = new Point(14, 886);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Size(214, 42);
            this.textBox2.TabIndex = 9;
            this.textBox2.Text = "BottomMessageStuff";
            // 
            // textBoxHitMiss
            // 
            this.textBoxHitMiss.BackColor = SystemColors.Info;
            this.textBoxHitMiss.Font = new Font("Courier New", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.textBoxHitMiss.Location = new Point(359, 12);
            this.textBoxHitMiss.Multiline = true;
            this.textBoxHitMiss.Name = "textBoxHitMiss";
            this.textBoxHitMiss.Size = new Size(546, 110);
            this.textBoxHitMiss.TabIndex = 10;
            this.textBoxHitMiss.Text = "Display Something TextBox";
            this.textBoxHitMiss.TextAlign = HorizontalAlignment.Center;
            // 
            // textBoxDisplayScore
            // 
            this.textBoxDisplayScore.BackColor = SystemColors.Info;
            this.textBoxDisplayScore.Font = new Font("Courier New", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.textBoxDisplayScore.Location = new Point(913, 12);
            this.textBoxDisplayScore.Multiline = true;
            this.textBoxDisplayScore.Name = "textBoxDisplayScore";
            this.textBoxDisplayScore.Size = new Size(116, 110);
            this.textBoxDisplayScore.TabIndex = 0;
            this.textBoxDisplayScore.Text = "\r\n\r\nYOUR SCORE\r\n[0]";
            this.textBoxDisplayScore.TextAlign = HorizontalAlignment.Center;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = SystemColors.Info;
            this.pictureBox2.Location = new Point(1577, 128);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new Size(214, 751);
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = SystemColors.Info;
            this.pictureBox3.Location = new Point(236, 886);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new Size(1334, 42);
            this.pictureBox3.TabIndex = 12;
            this.pictureBox3.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = SystemColors.Info;
            this.textBox1.Font = new Font("Courier New", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.textBox1.Location = new Point(1577, 886);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size(214, 42);
            this.textBox1.TabIndex = 13;
            this.textBox1.Text = "Version\r\n0.0.0.1";
            this.textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // Clicker
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.Black;
            this.ClientSize = new Size(1928, 943);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.textBoxDisplayScore);
            this.Controls.Add(this.drawPanelBoard);
            this.Controls.Add(this.drawPanelTimerIndicator);
            this.Controls.Add(this.textBoxHitMiss);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBoxCoords);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.richTextBoxCountDown);
            this.Controls.Add(this.richTextBoxDisplaySomething);
            this.Controls.Add(this.comboBoxInterval);
            this.Controls.Add(this.comboBoxMaxTime);
            this.Icon = (Icon)resources.GetObject("$this.Icon");
            this.Margin = new Padding(4, 3, 4, 3);
            this.MinimizeBox = false;
            this.Name = "Clicker";
            this.Padding = new Padding(50);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Clicker";
            this.WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.pictureBox3).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ComboBox comboBoxInterval;
        private System.Windows.Forms.ComboBox comboBoxMaxTime;
        private System.Windows.Forms.RichTextBox richTextBoxDisplaySomething;
        private System.Windows.Forms.RichTextBox richTextBoxCountDown;
        private PictureBox pictureBox1;
        private TextBox textBoxCoords;
        private TextBox textBox2;
        private TextBox textBoxHitMiss;
        private TextBox textBoxDisplayScore;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private TextBox textBox1;
    }
}