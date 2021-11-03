using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_Lab_II
{
    public partial class Form3 : Form
    {
        Form llamado;
        public Form3(Form llamado_)
        {
            InitializeComponent();
            llamado = llamado_;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            llamado.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Form2 form2 = new Form2(this);
            form2.Show();
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

            Size _size = new Size(panel_Tablero.Width / 8, panel_Tablero.Height / 8);
            for (int f = 0; f < 8; f++)
            { 
                for (int c = 0; c < 8; c++)
                {
                   var btn = new Button();
                   btn.Size = _size;
                   btn.Location = new Point(c * _size.Width, f * _size.Height);
                   btn.BackColor = (c + f) % 2 == 0 ? Color.BurlyWood : Color.White;
                   if (c == 1 && f == 1)
                   {
                        btn.Text = "R";
                        btn.BackColor = Color.Red;
                   }
                      
                   panel_Tablero.Controls.Add(btn);
                }
            }
        }
    }
}
