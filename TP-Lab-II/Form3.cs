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
        Tablero tablero = null;
        List<Tablero> tableros_ = null;
        public Form3(Form llamado_, Tablero _Tablero, List<Tablero>ListaTableros)
        {
            InitializeComponent();
            llamado = llamado_;
            tablero = _Tablero;
            tableros_ = ListaTableros;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Form2 form2 = new Form2(this, tableros_);
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
                    if (tablero.TableroOriginal[f, c] == 1)
                    {
                        btn.Text = "R";
                    }
                    if (tablero.TableroOriginal[f,c] == 2)
                    {
                        btn.Text = "r";
                    }
                    if (tablero.TableroOriginal[f,c] == 3)
                    {
                        btn.Text = "Aa";
                    }
                    if (tablero.TableroOriginal[f,c] == 4)
                    {
                        btn.Text = "Ab";
                    }
                    if (tablero.TableroOriginal[f,c] == 5)
                    {
                        btn.Text = "Ca";
                    }
                    if (tablero.TableroOriginal[f,c] == 6)
                    {
                        btn.Text = "Cb";
                    }
                    if (tablero.TableroOriginal[f,c] == 7)
                    {
                        btn.Text = "Ta";
                    }
                    if (tablero.TableroOriginal[f,c] == 8)
                    {
                        btn.Text = "Tb";
                    }
                    if (tablero.TableroOriginal[f,c] == 9)
                    {
                        btn.Text = "TC";
                    }

                    if (tablero.TableroAux[f, c] == 10)
                        btn.BackColor = Color.Red;
                    else
                        btn.BackColor = Color.LightGreen;
                    panel_Tablero.Controls.Add(btn);

                }
               
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void txtAtaques_TextChanged(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
