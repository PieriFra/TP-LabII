﻿
namespace TP_Lab_II
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
            this.CorrerBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CorrerBtn
            // 
            this.CorrerBtn.Location = new System.Drawing.Point(113, 42);
            this.CorrerBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CorrerBtn.Name = "CorrerBtn";
            this.CorrerBtn.Size = new System.Drawing.Size(100, 28);
            this.CorrerBtn.TabIndex = 0;
            this.CorrerBtn.Text = "Correr";
            this.CorrerBtn.UseVisualStyleBackColor = true;
            this.CorrerBtn.Click += new System.EventHandler(this.CorrerBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 398);
            this.Controls.Add(this.CorrerBtn);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CorrerBtn;
    }
}

