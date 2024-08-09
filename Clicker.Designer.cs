namespace Clicker
{
    partial class Clicker
    {
        private System.ComponentModel.IContainer components = null;
        private Draw drawPanel;

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
            drawPanel = new Draw();
            comboBoxMaxTime = new ComboBox();
            comboBoxInterval = new ComboBox();
            richTextBoxCountDown = new RichTextBox();
            richTextBoxDisplaySomething = new RichTextBox();
            richTextBoxDisplaySomethingElse = new RichTextBox();
            richTextBox1 = new RichTextBox();
            richTextBox2 = new RichTextBox();
            pictureBox1 = new PictureBox();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // drawPanel
            // 
            drawPanel.BackColor = Color.Black;
            drawPanel.BorderStyle = BorderStyle.FixedSingle;
            drawPanel.Location = new Point(236, 128);
            drawPanel.Margin = new Padding(4, 3, 4, 3);
            drawPanel.Name = "drawPanel";
            drawPanel.Size = new Size(1459, 800);
            drawPanel.TabIndex = 0;
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
            comboBoxMaxTime.SelectedIndexChanged += comboBoxMaxTime_SelectedIndexChanged;
            // 
            // comboBoxInterval
            // 
            comboBoxInterval.FormattingEnabled = true;
            comboBoxInterval.Items.AddRange(new object[] { "50", "75", "100", "250", "500", "750", "1000", "1200", "1500", "1750", "2000" });
            comboBoxInterval.Location = new Point(14, 128);
            comboBoxInterval.Margin = new Padding(4, 3, 4, 3);
            comboBoxInterval.Name = "comboBoxInterval";
            comboBoxInterval.Size = new Size(214, 23);
            comboBoxInterval.TabIndex = 0;
            comboBoxInterval.SelectedIndexChanged += comboBoxInterval_SelectedIndexChanged;
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
            // richTextBoxDisplaySomethingElse
            // 
            richTextBoxDisplaySomethingElse.BackColor = SystemColors.Info;
            richTextBoxDisplaySomethingElse.Font = new Font("Courier New", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            richTextBoxDisplaySomethingElse.Location = new Point(359, 12);
            richTextBoxDisplaySomethingElse.Margin = new Padding(4, 3, 4, 3);
            richTextBoxDisplaySomethingElse.Name = "richTextBoxDisplaySomethingElse";
            richTextBoxDisplaySomethingElse.Size = new Size(545, 110);
            richTextBoxDisplaySomethingElse.TabIndex = 4;
            richTextBoxDisplaySomethingElse.Text = "\n\nDISPLAY SOMETHING ELSE";
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = SystemColors.Info;
            richTextBox1.Font = new Font("Courier New", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            richTextBox1.Location = new Point(1036, 11);
            richTextBox1.Margin = new Padding(4, 3, 4, 3);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(535, 110);
            richTextBox1.TabIndex = 5;
            richTextBox1.Text = "\n\nDISPLAY SOMETHING ELSE";
            // 
            // richTextBox2
            // 
            richTextBox2.BackColor = SystemColors.Info;
            richTextBox2.Font = new Font("Courier New", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            richTextBox2.Location = new Point(912, 12);
            richTextBox2.Margin = new Padding(4, 3, 4, 3);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(116, 110);
            richTextBox2.TabIndex = 6;
            richTextBox2.Text = "\nDISPLAY SOMETHING";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.LightGray;
            pictureBox1.Image = Clicker_v2.Properties.Resources.dotted_circles;
            pictureBox1.Location = new Point(15, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(214, 110);
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.Info;
            textBox1.Location = new Point(14, 199);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(214, 680);
            textBox1.TabIndex = 8;
            textBox1.Font = new Font("Courier New", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox1.Text = "SomeThingsHere";
            // 
            // textBox2
            // 
            textBox2.BackColor = SystemColors.Info;
            textBox2.Location = new Point(14, 886);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(214, 42);
            textBox2.TabIndex = 9;
            textBox2.Font = new Font("Courier New", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox2.Text = "BottomMessageStuff";
            // 
            // Clicker
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1484, 811);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(pictureBox1);
            Controls.Add(richTextBox2);
            Controls.Add(richTextBox1);
            Controls.Add(richTextBoxCountDown);
            Controls.Add(richTextBoxDisplaySomethingElse);
            Controls.Add(drawPanel);
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
        private System.Windows.Forms.RichTextBox richTextBoxDisplaySomethingElse;
        private System.Windows.Forms.RichTextBox richTextBoxDisplaySomething;
        private System.Windows.Forms.RichTextBox richTextBoxCountDown;
        private RichTextBox richTextBox1;
        private RichTextBox richTextBox2;
        private PictureBox pictureBox1;
        private TextBox textBox1;
        private TextBox textBox2;
    }
}
