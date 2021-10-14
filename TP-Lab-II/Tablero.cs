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
        private List<Ficha> ListaFichas = new List<Ficha>(9);
        private int [,]TableroOriginal;
        private int [,]TableroAux; //debemos inicializar aca??
        
        protected Tablero(int tam_, List<Ficha> ListaFichas_, int [,]TableroOriginal_) 
        {
            tam= tam_;
            ListaFichas = ListaFichas_;
            for (int i = 0; i < tam; i++)
            {
                for (int j = 0; j < tam; j++)
                {
                    TableroAux[i,j] = 0;
                    TableroOriginal[i, j] = TableroOriginal_[i, j];//pasa los valores desde el main 
                }
            }
        
        }
        ~Tablero() { delete ListaFichas; }
        public void SetPosFichaOrg(Ficha ficha)//verrr
        {  
            for (int i = 0; i < tam; i++)
            {
                for (int j = 0; j < tam; j++)
                {
                   TableroOriginal[i, j]= ficha.Get_Codigo();
                }
            }
        }
        public int[,] GetTableroOrig() { return TableroOriginal; }
        public int GetPosFichaOrg(int k , int l) //devuelve el codigo de la ficha
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
        public int GetTam() {return tam;} 
        public Ficha GetFicha(int pos) { return ListaFichas[pos]; } //Ver esto, me tiene que devolver una ficha de la lista 
        public Ficha GetFichaCod(int codigo)
        {
            for (int i = 0; i < 9; i++)
            {
                if (ListaFichas[i].Codigo == codigo)
                    return ListaFichas[i];
            }

            return null; //si no se encuentra retornamos null
            
        }

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
                        //Ficha_mover.SetCodigo(rand.Next(9));
                        //Ficha_mover.CalcularMovimiento(Ficha_mover.Get_Codigo(), tableroOriginal);

                        int codigo = rand.Next(9);
                        Ficha ficha_mover=new Ficha();
                        ficha_mover.SetCodigo(codigo);
                        Ficha ficha_mover2 = ListaFichas.Find(ficha_mover);
                        ficha_mover.CalcularMovimiento(ListaFichas.Find(ficha_mover), tableroOriginal);
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

