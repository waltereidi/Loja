using System.Reflection.Metadata.Ecma335;
using static System.Net.Mime.MediaTypeNames;

namespace NexusMediator
{
    partial class NexusMediator
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            
            SuspendLayout();
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(12, 37);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(776, 358);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            // 
            // NexusMediator
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 407);
            ControlBox = false;
            Controls.Add(richTextBox1);
            Name = "NexusMediator";
            Tag = "";
            Text = "MicroServices Console";
            Load += NexusMediator_Load;
            ResumeLayout(false);
        }

        #endregion

        private static RichTextBox richTextBox1 = new RichTextBox();
        public void AddText(string text)
        {
            richTextBox1.AppendText(text);
        }
    }
}
