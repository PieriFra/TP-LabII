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
    public partial class Form2 : Form
    {
        Form1 llamado;
        List<Tablero> tableros_sol;

        public Form2(Form1 llamado_, List<Tablero> ListaResul)
        {
            InitializeComponent();
            llamado = llamado_;
            tableros_sol = ListaResul;

            for(int i=0; i< 0; i++)
            {
                listBox1.Items.Add(this.Btn_NResultados.Text);
                //this.Btn_NResultados
                //this.textBoxName.Focus();
                //this.textBoxName.Clear();
            }
            listBox1.Items.Add("A");
            listBox1.SelectionMode = SelectionMode.MultiSimple;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(llamado);
            form3.Show();
            this.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}
