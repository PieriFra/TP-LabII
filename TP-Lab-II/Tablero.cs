using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Lab_II
{
    class Tablero
    {
        private const int tam = 8;
        private List<Ficha> ListaFichas;
        private int [,]TableroAux; //debemos inicializar aca??
        protected Tablero(int tam_, List<Ficha> ListaFichas_) { tam_ = tam; ListaFichas_ = ListaFichas; }
        ~Tablero() { }


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
                        AnalizarTablero(tableroOriginal, tableroAux);
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

