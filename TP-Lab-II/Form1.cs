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
    public partial class Form1 : Form
    {

        List<Tablero> ListaResultados;
        
        public Form1()
        {
           InitializeComponent();
           ListaResultados = new List<Tablero> ();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        public void CorrerBtn_Click(object sender, EventArgs e)
        {
            Ficha reina = new Ficha("Reina", 1);
            Ficha rey = new Ficha("Rey", 2);
            Ficha Alfil_A = new Ficha("Alfil_A", 3);
            Ficha Alfil_B = new Ficha("Alfil_B", 4);
            Ficha Caballo_A = new Ficha("Caballo_A", 5);
            Ficha Caballo_B = new Ficha("Caballo_B", 6);
            Ficha Torre_A = new Ficha("Torre_A", 7);
            Ficha Torre_B = new Ficha("Torre_B", 8);
            Ficha TorreCaballo = new Ficha("TorreCaballo", 9);

            List<Ficha> ListaFichas = new List<Ficha>(8);
            ListaFichas.Add(reina);
            ListaFichas.Add(rey);
            ListaFichas.Add(Alfil_A);
            ListaFichas.Add(Alfil_B);
            ListaFichas.Add(Caballo_A);
            ListaFichas.Add(Caballo_B);
            ListaFichas.Add(Torre_A);
            ListaFichas.Add(Torre_B);
            ListaFichas.Add(TorreCaballo);

            int n_tableros= (UInt16)Btn_NSoluciones.Value;
            ListaResultados = new List<Tablero>(n_tableros);


            int cant_tableros = 0;

            do
            {
                Tablero TableroOrg = new Tablero(ListaFichas);
                ListaFichas[5].SetCodigo(6);
                ListaFichas[5].SetNombre("Caballo B");
                ListaFichas[6].SetCodigo(7);
                ListaFichas[6].SetNombre("Torre A");
                TableroOrg.CargarTablero();
                Tablero Aux = new Tablero(ListaFichas);
                Aux = TableroOrg.CalculoSolucion(ListaResultados);
                if (Aux != null)
                {
                    if (ListaResultados.Count == 0)
                    {
                        ListaResultados.Add(Aux);
                        cant_tableros++;
                    }
                    else
                    {
                        //verificamos que la solucion no se repita
                        cant_tableros = 1;
                        for (int i = 0; i < ListaResultados.Count; i++)
                        {
                            if (ListaResultados[i].CompararTableros(Aux) == true)
                                cant_tableros++;
                        }
                        if (cant_tableros == ListaResultados.Count + 1)
                            ListaResultados.Add(Aux);
                    }
                }
            } while (cant_tableros != n_tableros);


            Form2 form2 = new Form2(this, ListaResultados);
            form2.Show();
            this.Hide();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_MCosto_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("El costo del algoritmo es: ", "COSTO ALGORITMO", MessageBoxButtons.OK);

        }
    }
}
