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
            /*int N = (UInt16)Btn_NResultados.Value;
            for (int i=0; i<N; i++)
            {
                
                listBox1.Items.Add("Solucion "to_string.Btn_NResultados) ;
             
            }
            
            listBox1.SelectionMode = SelectionMode.MultiSimple;*/
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

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListViewGroup Resultados = new ListViewGroup("Resultados con 8 fichas: ", HorizontalAlignment.Center);
            for (int i = 0; i < lista.Count(); i++)
            {
                listView1.Items.Add(new ListViewItem("i", Resultados));
            }

        }

    }
}
