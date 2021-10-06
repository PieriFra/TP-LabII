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
        private const int cant_fichas = 9;
        //Agregar lista de fichas 
        protected Tablero(int tam_, int cant_fichas_) { tam_ = tam; cant_fichas_ = cant_fichas; }
        ~Tablero() {;}

        public int GetTam() {return tam;} //No existen los metodos constantes en c#
        public Ficha GetFicha() { return Ficha; }//Ver esto, me tiene que devolver una ficha de la lista 
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
    }
}

