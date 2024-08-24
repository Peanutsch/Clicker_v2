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
            pictureBox1 = new PictureBox();
            textBoxCoords = new TextBox();
            textBox2 = new TextBox();
            textBoxHitMiss = new TextBox();
            textBoxDisplayScore = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // drawPanelBoard
            // 
            drawPanelBoard.BackColor = Color.Black;
            drawPanelBoard.BorderStyle = BorderStyle.FixedSingle;
            drawPanelBoard.Location = new Point(236, 128);
            drawPanelBoard.Margin = new Padding(4, 3, 4, 3);
            drawPanelBoard.Name = "drawPanelBoard";
            drawPanelBoard.Size = new Size(1459, 800);
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
            richTextBoxCountDown.Size = new Size(116, 110);
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
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.LightGray;
            pictureBox1.Image = Properties.Resources.dotted_circles;
            pictureBox1.Location = new Point(15, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(214, 110);
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
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
            // textBoxHitMiss
            // 
            textBoxHitMiss.BackColor = SystemColors.Info;
            textBoxHitMiss.Font = new Font("Courier New", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBoxHitMiss.Location = new Point(359, 12);
            textBoxHitMiss.Multiline = true;
            textBoxHitMiss.Name = "textBoxHitMiss";
            textBoxHitMiss.Size = new Size(546, 110);
            textBoxHitMiss.TabIndex = 10;
            textBoxHitMiss.Text = "Display Something TextBox";
            textBoxHitMiss.TextAlign = HorizontalAlignment.Center;
            // 
            // textBoxDisplayScore
            // 
            textBoxDisplayScore.BackColor = SystemColors.Info;
            textBoxDisplayScore.Font = new Font("Courier New", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBoxDisplayScore.Location = new Point(913, 12);
            textBoxDisplayScore.Multiline = true;
            textBoxDisplayScore.Name = "textBoxDisplayScore";
            textBoxDisplayScore.Size = new Size(116, 110);
            textBoxDisplayScore.TabIndex = 0;
            textBoxDisplayScore.Text = "\r\n\r\nS C O R E ";
            textBoxDisplayScore.TextAlign = HorizontalAlignment.Center;
            // 
            // Clicker
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1484, 811);
            Controls.Add(textBoxDisplayScore);
            Controls.Add(drawPanelBoard);
            Controls.Add(drawPanelTimerIndicator);
            Controls.Add(textBoxHitMiss);
            Controls.Add(textBox2);
            Controls.Add(textBoxCoords);
            Controls.Add(pictureBox1);
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
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
    }
}