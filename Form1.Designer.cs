using System.Drawing;

namespace WindowsFormsDraft
{
    partial class Form1
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
            this.mcQueen2 = new WindowsFormsDraft.McQueen();
            this.mcQueen1 = new WindowsFormsDraft.McQueen();
            this.SuspendLayout();
            // 
            // mcQueen2
            // 
            this.mcQueen2.BackColor = System.Drawing.Color.Transparent;
            this.mcQueen2.Location = new System.Drawing.Point(37, 232);
            this.mcQueen2.Name = "mcQueen2";
            this.mcQueen2.Size = new System.Drawing.Size(149, 105);
            this.mcQueen2.TabIndex = 1;
            this.mcQueen2.Click += new System.EventHandler(this.onCarClicked);
            // 
            // mcQueen1
            // 
            this.mcQueen1.BackColor = System.Drawing.Color.Transparent;
            this.mcQueen1.Location = new System.Drawing.Point(37, 31);
            this.mcQueen1.Name = "mcQueen1";
            this.mcQueen1.Size = new System.Drawing.Size(149, 105);
            this.mcQueen1.TabIndex = 0;
            this.mcQueen1.Click += new System.EventHandler(this.onCarClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1184, 961);
            this.Controls.Add(this.mcQueen2);
            this.Controls.Add(this.mcQueen1);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private McQueen mcQueen1;
        private McQueen mcQueen2;
    }
}

