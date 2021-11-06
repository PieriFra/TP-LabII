
namespace TP_Lab_II
{
    partial class Form3
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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel_Tablero = new System.Windows.Forms.Panel();
            this.lable_Ataques = new System.Windows.Forms.Label();
            this.label_AtqLeve = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(140, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tablero Solucion:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(361, 298);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Ver otra solucion.";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(361, 327);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(154, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Calcular nuevas soluciones.";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel_Tablero
            // 
            this.panel_Tablero.Location = new System.Drawing.Point(58, 49);
            this.panel_Tablero.Name = "panel_Tablero";
            this.panel_Tablero.Size = new System.Drawing.Size(274, 254);
            this.panel_Tablero.TabIndex = 3;
            this.panel_Tablero.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint_1);
            // 
            // lable_Ataques
            // 
            this.lable_Ataques.AutoSize = true;
            this.lable_Ataques.ForeColor = System.Drawing.Color.Red;
            this.lable_Ataques.Location = new System.Drawing.Point(373, 79);
            this.lable_Ataques.Name = "lable_Ataques";
            this.lable_Ataques.Size = new System.Drawing.Size(83, 13);
            this.lable_Ataques.TabIndex = 5;
            this.lable_Ataques.Text = "Ataques Fatales";
            this.lable_Ataques.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_AtqLeve
            // 
            this.label_AtqLeve.AutoSize = true;
            this.label_AtqLeve.ForeColor = System.Drawing.Color.LimeGreen;
            this.label_AtqLeve.Location = new System.Drawing.Point(373, 104);
            this.label_AtqLeve.Name = "label_AtqLeve";
            this.label_AtqLeve.Size = new System.Drawing.Size(78, 13);
            this.label_AtqLeve.TabIndex = 6;
            this.label_AtqLeve.Text = "Ataques Leves";
            this.label_AtqLeve.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(373, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 117);
            this.label2.TabIndex = 7;
            this.label2.Text = "R: Reina.\r\nr: Rey.\r\nAa: Alfil \"A\".\r\nAb: Alfil \"B\".\r\nCa: Caballo \"A\".\r\nCb: Caballo" +
    " \"B\".\r\nTa: Torre \"A\".\r\nTb: Torre \"B\".\r\nTC: Torre-Caballo \r\n";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 409);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label_AtqLeve);
            this.Controls.Add(this.lable_Ataques);
            this.Controls.Add(this.panel_Tablero);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "Form3";
            this.Text = "Form3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel_Tablero;
        private System.Windows.Forms.Label lable_Ataques;
        private System.Windows.Forms.Label label_AtqLeve;
        private System.Windows.Forms.Label label2;
    }
}