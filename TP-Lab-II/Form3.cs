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
    }
}
