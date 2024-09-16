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
            drawPanelBoard = new DrawPanelBoard();
            drawPanelTimerIndicator = new DrawPanelTimerIndicator();
            comboBoxMaxTime = new ComboBox();
            comboBoxInterval = new ComboBox();
            richTextBoxCountDown = new RichTextBox();
            richTextBoxDisplaySomething = new RichTextBox();
            pictureBoxTopLeft = new PictureBox();
            textBoxCoords = new TextBox();
            textBox2 = new TextBox();
            textBoxDisplayScore = new TextBox();
            pictureBoxRightSide = new PictureBox();
            pictureBoxBottomSide = new PictureBox();
            textBox1 = new TextBox();
            textBoxQuota = new TextBox();
            DrawPanelListCircles = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBoxTopLeft).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRightSide).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxBottomSide).BeginInit();
            SuspendLayout();
            // 
            // drawPanelBoard
            // 
            drawPanelBoard.BackColor = Color.Black;
            drawPanelBoard.BorderStyle = BorderStyle.FixedSingle;
            drawPanelBoard.Location = new Point(236, 128);
            drawPanelBoard.Margin = new Padding(4, 3, 4, 3);
            drawPanelBoard.Name = "drawPanelBoard";
            drawPanelBoard.Size = new Size(1334, 751);
            drawPanelBoard.TabIndex = 0;
            // 
            // drawPanelTimerIndicator
            // 
            drawPanelTimerIndicator.BackColor = Color.Green;
            drawPanelTimerIndicator.BorderStyle = BorderStyle.Fixed3D;
            drawPanelTimerIndicator.Location = new Point(1035, 12);
            drawPanelTimerIndicator.Name = "drawPanelTimerIndicator";
            drawPanelTimerIndicator.Size = new Size(535, 110);
            drawPanelTimerIndicator.TabIndex = 0;
            // 
            // comboBoxMaxTime
            // 
            comboBoxMaxTime.FormattingEnabled = true;
            comboBoxMaxTime.Items.AddRange(new object[] { "1000", "2500", "5000", "7500", "10000", "12500", "15000", "17500", "20000" });
            comboBoxMaxTime.Location = new Point(14, 167);
            comboBoxMaxTime.Margin = new Padding(4, 3, 4, 3);
            comboBoxMaxTime.Name = "comboBoxMaxTime";
            comboBoxMaxTime.Size = new Size(214, 23);
            comboBoxMaxTime.TabIndex = 1;
            comboBoxMaxTime.SelectedIndexChanged += ComboBoxMaxTime_SelectedIndexChanged;
            // 
            // comboBoxInterval
            // 
            comboBoxInterval.FormattingEnabled = true;
            comboBoxInterval.Items.AddRange(new object[] { "25", "50", "75", "100", "250", "500", "750", "1000", "1200", "1500", "1750", "2000" });
            comboBoxInterval.Location = new Point(14, 128);
            comboBoxInterval.Margin = new Padding(4, 3, 4, 3);
            comboBoxInterval.Name = "comboBoxInterval";
            comboBoxInterval.Size = new Size(214, 23);
            comboBoxInterval.TabIndex = 0;
            comboBoxInterval.SelectedIndexChanged += ComboBoxInterval_SelectedIndexChanged;
            // 
            // richTextBoxCountDown
            // 
            richTextBoxCountDown.BackColor = SystemColors.Info;
            richTextBoxCountDown.Font = new Font("Courier New", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            richTextBoxCountDown.Location = new Point(1579, 11);
            richTextBoxCountDown.Margin = new Padding(4, 3, 4, 3);
            richTextBoxCountDown.Name = "richTextBoxCountDown";
            richTextBoxCountDown.Size = new Size(214, 110);
            richTextBoxCountDown.TabIndex = 2;
            richTextBoxCountDown.Text = "\n\nCOUNTDOWN";
            // 
            // richTextBoxDisplaySomething
            // 
            richTextBoxDisplaySomething.BackColor = SystemColors.Info;
            richTextBoxDisplaySomething.Font = new Font("Courier New", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            richTextBoxDisplaySomething.Location = new Point(236, 12);
            richTextBoxDisplaySomething.Margin = new Padding(4, 3, 4, 3);
            richTextBoxDisplaySomething.Name = "richTextBoxDisplaySomething";
            richTextBoxDisplaySomething.Size = new Size(116, 110);
            richTextBoxDisplaySomething.TabIndex = 3;
            richTextBoxDisplaySomething.Text = "\nDISPLAY SOMETHING";
            // 
            // pictureBoxTopLeft
            // 
            pictureBoxTopLeft.BackColor = Color.LightGray;
            pictureBoxTopLeft.Image = Properties.Resources.dotted_circles;
            pictureBoxTopLeft.Location = new Point(15, 12);
            pictureBoxTopLeft.Name = "pictureBoxTopLeft";
            pictureBoxTopLeft.Size = new Size(214, 110);
            pictureBoxTopLeft.TabIndex = 7;
            pictureBoxTopLeft.TabStop = false;
            // 
            // textBoxCoords
            // 
            textBoxCoords.BackColor = SystemColors.Info;
            textBoxCoords.Font = new Font("Courier New", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBoxCoords.Location = new Point(14, 199);
            textBoxCoords.Multiline = true;
            textBoxCoords.Name = "textBoxCoords";
            textBoxCoords.Size = new Size(214, 680);
            textBoxCoords.TabIndex = 8;
            textBoxCoords.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            textBox2.BackColor = SystemColors.Info;
            textBox2.Font = new Font("Courier New", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox2.Location = new Point(14, 886);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(214, 42);
            textBox2.TabIndex = 9;
            textBox2.Text = "BottomMessageStuff";
            // 
            // textBoxDisplayScore
            // 
            textBoxDisplayScore.BackColor = SystemColors.Info;
            textBoxDisplayScore.Font = new Font("Courier New", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBoxDisplayScore.Location = new Point(885, 71);
            textBoxDisplayScore.Multiline = true;
            textBoxDisplayScore.Name = "textBoxDisplayScore";
            textBoxDisplayScore.Size = new Size(142, 50);
            textBoxDisplayScore.TabIndex = 0;
            textBoxDisplayScore.Text = "YOUR SCORE\r\n[0]";
            textBoxDisplayScore.TextAlign = HorizontalAlignment.Center;
            // 
            // pictureBoxRightSide
            // 
            pictureBoxRightSide.BackColor = SystemColors.Info;
            pictureBoxRightSide.Location = new Point(1577, 128);
            pictureBoxRightSide.Name = "pictureBoxRightSide";
            pictureBoxRightSide.Size = new Size(214, 751);
            pictureBoxRightSide.TabIndex = 11;
            pictureBoxRightSide.TabStop = false;
            // 
            // pictureBoxBottomSide
            // 
            pictureBoxBottomSide.BackColor = SystemColors.Info;
            pictureBoxBottomSide.Location = new Point(236, 886);
            pictureBoxBottomSide.Name = "pictureBoxBottomSide";
            pictureBoxBottomSide.Size = new Size(1334, 42);
            pictureBoxBottomSide.TabIndex = 12;
            pictureBoxBottomSide.TabStop = false;
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.Info;
            textBox1.Font = new Font("Courier New", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(1577, 886);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(214, 42);
            textBox1.TabIndex = 13;
            textBox1.Text = "Version\r\n0.0.0.1";
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // textBoxQuota
            // 
            textBoxQuota.BackColor = SystemColors.Info;
            textBoxQuota.Font = new Font("Courier New", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBoxQuota.Location = new Point(885, 12);
            textBoxQuota.Multiline = true;
            textBoxQuota.Name = "textBoxQuota";
            textBoxQuota.Size = new Size(142, 50);
            textBoxQuota.TabIndex = 1;
            textBoxQuota.Text = "QUOTA";
            textBoxQuota.TextAlign = HorizontalAlignment.Center;
            // 
            // DrawPanelListCircles
            // 
            DrawPanelListCircles.BackColor = SystemColors.Info;
            DrawPanelListCircles.BorderStyle = BorderStyle.Fixed3D;
            DrawPanelListCircles.Font = new Font("Courier New", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DrawPanelListCircles.Location = new Point(359, 12);
            DrawPanelListCircles.Name = "DrawPanelListCircles";
            DrawPanelListCircles.Size = new Size(520, 110);
            DrawPanelListCircles.TabIndex = 14;
            // 
            // Clicker
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1928, 943);
            Controls.Add(DrawPanelListCircles);
            Controls.Add(textBoxQuota);
            Controls.Add(textBox1);
            Controls.Add(pictureBoxBottomSide);
            Controls.Add(pictureBoxRightSide);
            Controls.Add(textBoxDisplayScore);
            Controls.Add(drawPanelBoard);
            Controls.Add(drawPanelTimerIndicator);
            Controls.Add(textBox2);
            Controls.Add(textBoxCoords);
            Controls.Add(pictureBoxTopLeft);
            Controls.Add(richTextBoxCountDown);
            Controls.Add(richTextBoxDisplaySomething);
            Controls.Add(comboBoxInterval);
            Controls.Add(comboBoxMaxTime);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MinimizeBox = false;
            Name = "Clicker";
            Padding = new Padding(50);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Clicker";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)pictureBoxTopLeft).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRightSide).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxBottomSide).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.ComboBox comboBoxInterval;
        private System.Windows.Forms.ComboBox comboBoxMaxTime;
        private System.Windows.Forms.RichTextBox richTextBoxDisplaySomething;
        private System.Windows.Forms.RichTextBox richTextBoxCountDown;
        private PictureBox pictureBoxTopLeft;
        private TextBox textBoxCoords;
        private TextBox textBox2;
        private TextBox textBoxDisplayScore;
        private PictureBox pictureBoxRightSide;
        private PictureBox pictureBoxBottomSide;
        private TextBox textBox1;
        private TextBox textBoxQuota;
        private Panel DrawPanelListCircles;
    }
}