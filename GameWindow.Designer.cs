using static System.Formats.Asn1.AsnWriter;

namespace Clicker_v2
{
    partial class GameWindow
    {
        private System.ComponentModel.IContainer components = null;
        private PanelBoardCircles drawPanelBoard;
        private PanelTimerIndicator drawPanelTimerIndicator;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Opruimen van de timer en andere handmatige resources
                if (indicatorTimer != null)
                {
                    indicatorTimer.Stop();
                    indicatorTimer.Dispose();
                    indicatorTimer = null; // Voorkom verdere toegang tot de opgeruimde timer
                }

                // Opruimen van overige handmatige resources zoals _clickManager en _drawPanelBoard
                //_clickManager?.Dispose(); // Zorg ervoor dat ClickManager IDisposable implementeert als het resources opruimt
                //_drawPanelBoard?.Dispose();
                //_drawPanelTimerIndicator?.Dispose();

                // Opruimen van door de designer gegenereerde componenten
                if (components != null)
                {
                    components.Dispose();
                }
            }

            // Roep de base class Dispose methode aan om ervoor te zorgen dat alle resources worden vrijgegeven
            base.Dispose(disposing);
        }


        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameWindow));
            this.drawPanelBoard = new PanelBoardCircles();
            this.drawPanelTimerIndicator = new PanelTimerIndicator(clickManager);
            this.richTextBoxCountDown = new RichTextBox();
            this.pictureBoxTopLeft = new PictureBox();
            this.textBoxCoords = new TextBox();
            this.textBox2 = new TextBox();
            this.textBoxDisplayScore = new TextBox();
            this.pictureBoxRightSide = new PictureBox();
            this.pictureBoxBottomSide = new PictureBox();
            this.textBox1 = new TextBox();
            this.textBoxQuota = new TextBox();
            this.DrawPanelListCircles = new Panel();
            ((System.ComponentModel.ISupportInitialize)this.pictureBoxTopLeft).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.pictureBoxRightSide).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.pictureBoxBottomSide).BeginInit();
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
            this.drawPanelTimerIndicator.Location = new Point(910, 12);
            this.drawPanelTimerIndicator.Name = "drawPanelTimerIndicator";
            this.drawPanelTimerIndicator.Size = new Size(660, 110);
            this.drawPanelTimerIndicator.TabIndex = 0;
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
            this.richTextBoxCountDown.SelectionAlignment = HorizontalAlignment.Center;
            this.richTextBoxCountDown.Text = "\n\nCOUNTDOWN";
            // 
            // pictureBoxTopLeft
            // 
            this.pictureBoxTopLeft.BackColor = Color.LightGray;
            this.pictureBoxTopLeft.Image = Properties.Resources.dotted_circles;
            this.pictureBoxTopLeft.Location = new Point(15, 12);
            this.pictureBoxTopLeft.Name = "pictureBoxTopLeft";
            this.pictureBoxTopLeft.Size = new Size(214, 110);
            this.pictureBoxTopLeft.TabIndex = 7;
            this.pictureBoxTopLeft.TabStop = false;
            // 
            // textBoxCoords
            // 
            this.textBoxCoords.BackColor = SystemColors.Info;
            this.textBoxCoords.Font = new Font("Courier New", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.textBoxCoords.Location = new Point(14, 128);
            this.textBoxCoords.Multiline = true;
            this.textBoxCoords.Name = "textBoxCoords";
            this.textBoxCoords.Size = new Size(214, 751);
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
            // textBoxDisplayScore
            // 
            this.textBoxDisplayScore.BackColor = SystemColors.Info;
            this.textBoxDisplayScore.Font = new Font("Courier New", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.textBoxDisplayScore.Location = new Point(762, 72);
            this.textBoxDisplayScore.Multiline = true;
            this.textBoxDisplayScore.Name = "textBoxDisplayScore";
            this.textBoxDisplayScore.Size = new Size(142, 50);
            this.textBoxDisplayScore.TabIndex = 0;
            this.textBoxDisplayScore.Text = "YOUR SCORE\r\n[0]";
            this.textBoxDisplayScore.TextAlign = HorizontalAlignment.Center;
            // 
            // pictureBoxRightSide
            // 
            this.pictureBoxRightSide.BackColor = SystemColors.Info;
            this.pictureBoxRightSide.Location = new Point(1577, 128);
            this.pictureBoxRightSide.Name = "pictureBoxRightSide";
            this.pictureBoxRightSide.Size = new Size(214, 751);
            this.pictureBoxRightSide.TabIndex = 11;
            this.pictureBoxRightSide.TabStop = false;
            // 
            // pictureBoxBottomSide
            // 
            this.pictureBoxBottomSide.BackColor = SystemColors.Info;
            this.pictureBoxBottomSide.Location = new Point(236, 886);
            this.pictureBoxBottomSide.Name = "pictureBoxBottomSide";
            this.pictureBoxBottomSide.Size = new Size(1334, 42);
            this.pictureBoxBottomSide.TabIndex = 12;
            this.pictureBoxBottomSide.TabStop = false;
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
            // textBoxQuota
            // 
            this.textBoxQuota.BackColor = SystemColors.Info;
            this.textBoxQuota.Font = new Font("Courier New", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.textBoxQuota.Location = new Point(762, 12);
            this.textBoxQuota.Multiline = true;
            this.textBoxQuota.Name = "textBoxQuota";
            this.textBoxQuota.Size = new Size(142, 50);
            this.textBoxQuota.TabIndex = 1;
            this.textBoxQuota.Text = "QUOTA";
            this.textBoxQuota.TextAlign = HorizontalAlignment.Center;
            // 
            // DrawPanelListCircles
            // 
            this.DrawPanelListCircles.BackColor = SystemColors.Info;
            this.DrawPanelListCircles.BorderStyle = BorderStyle.Fixed3D;
            this.DrawPanelListCircles.Font = new Font("Courier New", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.DrawPanelListCircles.Location = new Point(236, 12);
            this.DrawPanelListCircles.Name = "DrawPanelListCircles";
            this.DrawPanelListCircles.Size = new Size(520, 110);
            this.DrawPanelListCircles.TabIndex = 14;
            // 
            // Clicker
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.Black;
            this.ClientSize = new Size(1928, 943);
            this.Controls.Add(this.DrawPanelListCircles);
            this.Controls.Add(this.textBoxQuota);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBoxBottomSide);
            this.Controls.Add(this.pictureBoxRightSide);
            this.Controls.Add(this.textBoxDisplayScore);
            this.Controls.Add(this.drawPanelBoard);
            this.Controls.Add(this.drawPanelTimerIndicator);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBoxCoords);
            this.Controls.Add(this.pictureBoxTopLeft);
            this.Controls.Add(this.richTextBoxCountDown);
            this.Icon = (Icon)resources.GetObject("$this.Icon");
            this.Margin = new Padding(4, 3, 4, 3);
            this.MinimizeBox = false;
            this.Name = "Clicker";
            this.Padding = new Padding(50);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Clicker";
            this.WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)this.pictureBoxTopLeft).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.pictureBoxRightSide).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.pictureBoxBottomSide).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

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