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
            this.drawPanel = new Draw();
            this.comboBoxMaxTime = new ComboBox();
            this.comboBoxInterval = new ComboBox();
            this.richTextBoxCountDown = new RichTextBox();
            this.richTextBoxDisplaySomething = new RichTextBox();
            this.richTextBoxDisplaySomethingElse = new RichTextBox();
            this.SuspendLayout();
            // 
            // drawPanel
            // 
            this.drawPanel.BackColor = Color.Black;
            this.drawPanel.Location = new Point(4, 128);
            this.drawPanel.Margin = new Padding(4, 3, 4, 3);
            this.drawPanel.Name = "drawPanel";
            this.drawPanel.Size = new Size(1873, 800);
            this.drawPanel.TabIndex = 0;
            // 
            // comboBoxMaxTime
            // 
            this.comboBoxMaxTime.FormattingEnabled = true;
            this.comboBoxMaxTime.Items.AddRange(new object[] { "1000", "2500", "5000", "7500", "10000", "12500", "15000", "17500", "20000" });
            this.comboBoxMaxTime.Location = new Point(14, 98);
            this.comboBoxMaxTime.Margin = new Padding(4, 3, 4, 3);
            this.comboBoxMaxTime.Name = "comboBoxMaxTime";
            this.comboBoxMaxTime.Size = new Size(214, 23);
            this.comboBoxMaxTime.TabIndex = 1;
            this.comboBoxMaxTime.SelectedIndexChanged += this.comboBoxMaxTime_SelectedIndexChanged;
            // 
            // comboBoxInterval
            // 
            this.comboBoxInterval.FormattingEnabled = true;
            this.comboBoxInterval.Items.AddRange(new object[] { "50", "75", "100", "250", "500", "750", "1000", "1200", "1500", "1750", "2000" });
            this.comboBoxInterval.Location = new Point(14, 14);
            this.comboBoxInterval.Margin = new Padding(4, 3, 4, 3);
            this.comboBoxInterval.Name = "comboBoxInterval";
            this.comboBoxInterval.Size = new Size(214, 23);
            this.comboBoxInterval.TabIndex = 0;
            this.comboBoxInterval.SelectedIndexChanged += this.comboBoxInterval_SelectedIndexChanged;
            // 
            // richTextBoxCountDown
            // 
            this.richTextBoxCountDown.BackColor = SystemColors.Info;
            this.richTextBoxCountDown.Font = new Font("Courier New", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.richTextBoxCountDown.Location = new Point(1761, 11);
            this.richTextBoxCountDown.Margin = new Padding(4, 3, 4, 3);
            this.richTextBoxCountDown.Name = "richTextBoxCountDown";
            this.richTextBoxCountDown.Size = new Size(116, 110);
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
            // richTextBoxDisplaySomethingElse
            // 
            this.richTextBoxDisplaySomethingElse.BackColor = SystemColors.Info;
            this.richTextBoxDisplaySomethingElse.Font = new Font("Courier New", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.richTextBoxDisplaySomethingElse.Location = new Point(359, 12);
            this.richTextBoxDisplaySomethingElse.Margin = new Padding(4, 3, 4, 3);
            this.richTextBoxDisplaySomethingElse.Name = "richTextBoxDisplaySomethingElse";
            this.richTextBoxDisplaySomethingElse.Size = new Size(1394, 110);
            this.richTextBoxDisplaySomethingElse.TabIndex = 4;
            this.richTextBoxDisplaySomethingElse.Text = "\n\nDISPLAY SOMETHING ELSE";
            // 
            // Clicker
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.Black;
            this.ClientSize = new Size(1904, 1041);
            this.Controls.Add(this.richTextBoxCountDown);
            this.Controls.Add(this.richTextBoxDisplaySomethingElse);
            this.Controls.Add(this.drawPanel);
            this.Controls.Add(this.richTextBoxDisplaySomething);
            this.Controls.Add(this.comboBoxInterval);
            this.Controls.Add(this.comboBoxMaxTime);
            this.Margin = new Padding(4, 3, 4, 3);
            this.MinimizeBox = false;
            this.Name = "Clicker";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Clicker";
            this.WindowState = FormWindowState.Maximized;
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.ComboBox comboBoxInterval;
        private System.Windows.Forms.ComboBox comboBoxMaxTime;
        private System.Windows.Forms.RichTextBox richTextBoxDisplaySomethingElse;
        private System.Windows.Forms.RichTextBox richTextBoxDisplaySomething;
        private System.Windows.Forms.RichTextBox richTextBoxCountDown;
    }
}
