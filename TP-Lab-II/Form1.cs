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

            int n_tableros = 10; //como podriamos declarala como varibale global???
            List<Tablero> ListaResultados = new List<Tablero>(n_tableros);

           
            int cant_tableros = 0;
            do
            {

                Tablero TableroOrg = new Tablero(ListaFichas);
                
                TableroOrg.CargarTablero(TableroOrg);

                Tablero Aux = new Tablero(ListaFichas);
                Aux = TableroOrg.CalculoSolucion(TableroOrg, ListaResultados, n_tableros);
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
                        for (int i = 0; i < n_tableros; i++)
                        {
                            if (ListaResultados[i] != Aux)
                            {
                                ListaResultados.Add(Aux); //si no existía agg la nueva solución 
                                cant_tableros++;
                            }
                                
                        }
                    }
                }
                

            } while (cant_tableros == n_tableros);

            for(int i=0; i<n_tableros; i++)
            {
                Console.WriteLine(ListaResultados[i]);
            }
        }

       
    }
}
