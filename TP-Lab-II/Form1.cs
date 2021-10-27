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
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void CorrerBtn_Click(object sender, EventArgs e)
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

            int n_tableros = 1; //como podriamos declarala como varibale global???
            List<Tablero> ListaResultados = new List<Tablero>(n_tableros);

           
            int cant_tableros = 0;
            do
            {

                Tablero TableroOrg = new Tablero(ListaFichas);
                
                TableroOrg.CargarTablero();

                Tablero Aux = new Tablero(ListaFichas);
                Aux = TableroOrg.CalculoSolucion(ListaResultados, n_tableros);
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
                            if (ListaResultados[i] != Aux)
                                cant_tableros++;
                        }
                        if(cant_tableros==ListaResultados.Count +1 )
                            ListaResultados.Add(Aux);
                    }
                }
            } while (cant_tableros != n_tableros);

            if(ListaResultados.Count==n_tableros)
                textBox1.Text = Convert.ToString("Tengo 10 soluciones");

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
    }
}
