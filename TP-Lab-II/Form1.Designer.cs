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
            this.label1 = new System.Windows.Forms.Label();
            this.Btn_NSoluciones = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.Btn_MCosto = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_NSoluciones)).BeginInit();
            this.SuspendLayout();
            // 
            // CorrerBtn
            // 
            this.CorrerBtn.BackColor = System.Drawing.Color.Pink;
            this.CorrerBtn.Location = new System.Drawing.Point(194, 143);
            this.CorrerBtn.Name = "CorrerBtn";
            this.CorrerBtn.Size = new System.Drawing.Size(121, 23);
            this.CorrerBtn.TabIndex = 0;
            this.CorrerBtn.Text = "Calcular Soluciones";
            this.CorrerBtn.UseVisualStyleBackColor = false;
            this.CorrerBtn.Click += new System.EventHandler(this.CorrerBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(59, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Cantidad de Soluciones";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Btn_NSoluciones
            // 
            this.Btn_NSoluciones.BackColor = System.Drawing.Color.White;
            this.Btn_NSoluciones.Location = new System.Drawing.Point(194, 81);
            this.Btn_NSoluciones.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.Btn_NSoluciones.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Btn_NSoluciones.Name = "Btn_NSoluciones";
            this.Btn_NSoluciones.Size = new System.Drawing.Size(120, 20);
            this.Btn_NSoluciones.TabIndex = 3;
            this.Btn_NSoluciones.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Pink;
            this.button1.Location = new System.Drawing.Point(194, 199);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 19);
            this.button1.TabIndex = 4;
            this.button1.Text = "Finalizar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Btn_MCosto
            // 
            this.Btn_MCosto.BackColor = System.Drawing.Color.Pink;
            this.Btn_MCosto.Location = new System.Drawing.Point(194, 172);
            this.Btn_MCosto.Name = "Btn_MCosto";
            this.Btn_MCosto.Size = new System.Drawing.Size(121, 22);
            this.Btn_MCosto.TabIndex = 5;
            this.Btn_MCosto.Text = "Costo Algoritmo";
            this.Btn_MCosto.UseVisualStyleBackColor = false;
            this.Btn_MCosto.Click += new System.EventHandler(this.Btn_MCosto_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSeaGreen;
            this.ClientSize = new System.Drawing.Size(399, 311);
            this.ControlBox = false;
            this.Controls.Add(this.Btn_MCosto);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Btn_NSoluciones);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CorrerBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Btn_NSoluciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CorrerBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown Btn_NSoluciones;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Btn_MCosto;
    }
}

