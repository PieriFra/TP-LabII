using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Lab_II
{
    class Tablero
    {
        private int tam = 8; //ver como poner const
        private List<Ficha> ListaFichas;
        private int [,]TableroOriginal;
        private int [,]TableroAux; //debemos inicializar aca??
        protected Tablero(int tam_, List<Ficha> ListaFichas_, int[,] TableroAux_, int [,]TableroOriginal_) {
            tam= tam_;
            ListaFichas = ListaFichas_;
            TableroAux = TableroAux_; //inicializar!
            TableroOriginal = TableroOriginal_; //incializar!
        }
        ~Tablero() { }

        public int[,] GetTableroOrig() { return TableroOriginal; }
        public int GetPosFichaOrg(int k , int l)
        {
            //k=i, l=j
            for (int i = 0; i < tam; i++) 
            {
                for (int j = 0; j < tam; j++)
                {
                    return TableroOriginal[i,j];
                }
            }
            return 0; //no se encontro la ficha
        }
        public int GetTam() {return tam;} //No existen los metodos constantes en c#
        public Ficha GetFicha(int pos) { return ListaFichas[pos]; } //Ver esto, me tiene que devolver una ficha de la lista 
        public bool VerificarTablero(int [,]tableroAux)
        {
           //verifica que todas las posciones del tablero esten siendo atacadas
            for (int i=0; i< tam; i++)
            {
                for(int j=0; j<tam;j++)
                {
                    //en caso de encontar una posicion que no esta siendo atacada retorna false
                    if (tableroAux[i, j] == 0) 
                        return false;
                }
            }

            //si recorre todo el tablero y no encuentra ninguna posicion libre, efectivamente todas las posciones
           //estan siendo atacadas y retorna true
            return true; 
        }

        public Tablero CalculoSolucion(Tablero tableroOriginal, int[,] tableroAux, List<Tablero> ListaResultados, int n_tableros)
        {
            var rand = new Random(); //verrrrr
            int mov = 0; //contador de movimientos.
            do
            {
                if (mov > 8)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        int Ficha_mover = rand.Next(0, 8);
                        CalcularMovimiento(Ficha_mover, tableroOriginal);
                        AnalizarTableroAux(tableroOriginal, tableroAux);
                        mov++;
                    }
                }

                //si en 5 movimientos no encontramos una solución juntamos un caballo y una torre y movemos siempre esa ficha
                CalcularMovimientos(9, tableroOriginal); //realizamos un movimiento
                AnalizarTableroAux(tableroOriginal, tableroAux);

            } while (VerificarTablero(tableroAux) == false);

            //verificamos que la solucion no se repita
            for(int i=0; i < n_tableros; i++)
            {
                if (ListaResultados[i] != tableroOriginal)
                    return tableroOriginal; //si no existía retornamos la nueva solución 
            }

            //en caso de que ya exista la solucion retornamos null, o que mas podriamos retornar???
            return null;
        }

    }
}

