namespace NexusMediator
{
    partial class WindowsForms
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
            buttonStart = new Button();
            richTextBox1 = new RichTextBox();
            buttonStop = new Button();
            SuspendLayout();
            // 
            // buttonStart
            // 
            buttonStart.Location = new Point(14, 12);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(75, 23);
            buttonStart.TabIndex = 0;
            buttonStart.Text = "Start";
            buttonStart.UseVisualStyleBackColor = true;
            buttonStart.Click += buttonStart_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(14, 41);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(774, 397);
            richTextBox1.TabIndex = 1;
            richTextBox1.Text = "";
            // 
            // buttonStop
            // 
            buttonStop.BackColor = Color.Red;
            buttonStop.BackgroundImageLayout = ImageLayout.None;
            buttonStop.Location = new Point(95, 12);
            buttonStop.Name = "buttonStop";
            buttonStop.Size = new Size(75, 23);
            buttonStop.TabIndex = 2;
            buttonStop.Text = "Stop";
            buttonStop.UseVisualStyleBackColor = false;
            buttonStop.Click += buttonStop_Click;
            // 
            // WindowsForms
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonStop);
            Controls.Add(richTextBox1);
            Controls.Add(buttonStart);
            Name = "WindowsForms";
            Text = "WindowsForms";
            ResumeLayout(false);
        }

        #endregion
        public void AddText(string v)
        {
            richTextBox1.AppendText(v);
        }
        private Button buttonStart;
        private RichTextBox richTextBox1;
        private Button buttonStop;
    }
}