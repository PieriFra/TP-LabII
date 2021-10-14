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

        public Tablero CalculoSolucion(Tablero tableroOriginal, List<Tablero> ListaResultados, int n_tableros)
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
                        Ficha ficha_mover = tableroOriginal.GetFichaCod(codigo);
                        ficha_mover.CalcularMovimiento(ficha_mover, tableroOriginal);
                        AnalizarTableroAux(tableroOriginal);
                        mov++;
                    }
                }

                //si en 5 movimientos no encontramos una solución juntamos un caballo y una torre y movemos siempre esa ficha
                Ficha FichaMagica = tableroOriginal.GetFicha(9);
                FichaMagica.CalcularMovimiento(FichaMagica, tableroOriginal); //realizamos un movimiento
                AnalizarTableroAux(tableroOriginal);

            } while (VerificarTablero(tableroOriginal.TableroAux) == false);

            //verificamos que la solucion no se repita
            for(int i=0; i < n_tableros; i++)
            {
                if (ListaResultados[i] != tableroOriginal)
                    return tableroOriginal; //si no existía retornamos la nueva solución 
            }

            //en caso de que ya exista la solucion retornamos null, o que mas podriamos retornar???
            return null;
        }

        public int[,] AnalizarTableroAux(Tablero tableroOriginal)
        {
            int[] pos1 = new int[0];
            int[] pos2 = new int[0];
            int[] pos3 = new int[0];
            int[] pos4 = new int[0];
            int[] pos5 = new int[0];
            int[] pos6 = new int[0];
            int[] pos7 = new int[0];
            int[] pos8 = new int[0];
            int[] pos9 = new int[0];

            Ficha ficha = new Ficha();
            //reina 
            ficha = tableroOriginal.GetFichaCod(1); //obtenemos la ficha que queremos 
            pos1 = ficha.CalcularPosicion(ficha, tableroOriginal); //buscamos la posicion de la ficha
            for (int i = pos1[0]; i < tam; i++) //i++ j++
            {
                for (int j = pos1[1]; j < tam; j++)
                {
                    tableroOriginal.TableroAux[i, j] = 1; 
                }
            }
            for (int i = tam; i > pos1[0]; i++) //i-- j--
            {
                for (int j = tam; j > pos1[1]; j++)
                {
                    tableroOriginal.TableroAux[i, j] = 1;
                }
            }
            for (int i = pos1[0]; i < tam; i++) //i++, j--
            {
                for (int j = tam; j > pos1[1]; j++)
                {
                    tableroOriginal.TableroAux[i, j] = 1;
                }
            }
            for (int i = tam; i > pos1[0]; i++) //i-- j++
            {
                for (int j = pos1[1]; j < tam; j++)
                {
                    tableroOriginal.TableroAux[i, j] = 1;
                }
            }
            for (int i = pos1[0]; i < tam; i++) {     //i++
                tableroOriginal.TableroAux[i, pos1[1] ]= 1; 
            }
            for (int i = tam; i > pos1[0]; i++) {     //i--
                tableroOriginal.TableroAux[i, pos1[1]] = 1;
            }
            for (int j = tam; j > pos1[0]; j++)
            {     //j--
                tableroOriginal.TableroAux[pos1[0], j] = 1;
            }
            for (int j = pos1[1]; j < tam; j++)
            {     //j++
                tableroOriginal.TableroAux[pos1[0], j] = 1;
            }

            //rey 
            ficha = tableroOriginal.GetFichaCod(2); //obtenemos la ficha que queremos 
            pos2 = ficha.CalcularPosicion(ficha, tableroOriginal); //buscamos la posicion de la ficha

            if (pos2[0] + 1 < tam) { tableroOriginal.TableroAux[pos2[0] + 1, pos2[1]] = 2; }
            if (pos2[0] - 1 < tam) { tableroOriginal.TableroAux[pos2[0] - 1, pos2[1]] = 2; }
            if (pos2[1] + 1 < tam) { tableroOriginal.TableroAux[pos2[0], pos2[1]+1] = 2; }
            if (pos2[1] - 1 < tam) { tableroOriginal.TableroAux[pos2[0], pos2[1] - 1] = 2; }
            if (pos2[1] + 1 < tam && pos2[0] + 1 < tam) { tableroOriginal.TableroAux[pos2[0]+1, pos2[1] + 1] = 2; }
            if (pos2[1] + 1 < tam && pos2[0] - 1 < tam) { tableroOriginal.TableroAux[pos2[0] - 1, pos2[1] + 1] = 2; }
            if (pos2[1] -1 < tam && pos2[0] + 1 < tam) { tableroOriginal.TableroAux[pos2[0] + 1, pos2[1] - 1] = 2; }
            if (pos2[1] - 1 < tam && pos2[0] - 1 < tam) { tableroOriginal.TableroAux[pos2[0] - 1, pos2[1] - 1] = 2; }

            //Alfil A
            ficha = tableroOriginal.GetFichaCod(3); //obtenemos la ficha que queremos 
            pos3 = ficha.CalcularPosicion(ficha, tableroOriginal); //buscamos la posicion de la fich
            for (int i = pos3[0]; i < tam; i++) //i++ j++
            {
                for (int j = pos3[1]; j < tam; j++)
                {
                    tableroOriginal.TableroAux[i, j] = 3;
                }
            }
            for (int i = tam; i > pos3[0]; i++) //i-- j--
            {
                for (int j = tam; j > pos3[1]; j++)
                {
                    tableroOriginal.TableroAux[i, j] =3;
                }
            }
            for (int i = pos3[0]; i < tam; i++) //i++, j--
            {
                for (int j = tam; j > pos3[1]; j++)
                {
                    tableroOriginal.TableroAux[i, j] = 3;
                }
            }
            for (int i = tam; i > pos3[0]; i++) //i-- j++
            {
                for (int j = pos3[1]; j < tam; j++)
                {
                    tableroOriginal.TableroAux[i, j] = 3;
                }
            }

            //Alfil B
            ficha = tableroOriginal.GetFichaCod(4); //obtenemos la ficha que queremos 
            pos4 = ficha.CalcularPosicion(ficha, tableroOriginal); //buscamos la posicion de la fich
            for (int i = pos4[0]; i < tam; i++) //i++ j++
            {
                for (int j = pos4[1]; j < tam; j++)
                {
                    tableroOriginal.TableroAux[i, j] = 4;
                }
            }
            for (int i = tam; i > pos4[0]; i++) //i-- j--
            {
                for (int j = tam; j > pos4[1]; j++)
                {
                    tableroOriginal.TableroAux[i, j] =4;
                }
            }
            for (int i = pos4[0]; i < tam; i++) //i++, j--
            {
                for (int j = tam; j > pos4[1]; j++)
                {
                    tableroOriginal.TableroAux[i, j] = 4;
                }
            }
            for (int i = tam; i > pos4[0]; i++) //i-- j++
            {
                for (int j = pos4[1]; j < tam; j++)
                {
                    tableroOriginal.TableroAux[i, j] = 4;
                }
            }

            //Caballo A
            ficha = tableroOriginal.GetFichaCod(5); //obtenemos la ficha que queremos 
            pos5 = ficha.CalcularPosicion(ficha, tableroOriginal); //buscamos la posicion de la fich
            if (pos5[0] + 2 < tam && pos5[1] + 1 < tam) { tableroOriginal.TableroAux[pos5[0] + 2, pos5[1] + 1] = 5; }
            if (pos5[0] + 2 < tam && pos5[1] - 1 < tam) { tableroOriginal.TableroAux[pos5[0] + 2, pos5[1] - 1] = 5; }
            if (pos5[0] - 2 < tam && pos5[1] - 1 < tam) { tableroOriginal.TableroAux[pos5[0] - 2, pos5[1] - 1] = 5; }
            if (pos5[0] - 2 < tam && pos5[1] + 1 < tam) { tableroOriginal.TableroAux[pos5[0] - 2, pos5[1] + 1] = 5; }
            if (pos5[0] + 1 < tam && pos5[1] + 2 < tam) { tableroOriginal.TableroAux[pos5[0] + 1, pos5[1] + 2] = 5; }
            if (pos5[0] + 1 < tam && pos5[1] - 2 < tam) { tableroOriginal.TableroAux[pos5[0] + 1, pos5[1] - 2] = 5; }
            if (pos5[0] - 1 < tam && pos5[1] - 2 < tam) { tableroOriginal.TableroAux[pos5[0] - 1, pos5[1] - 2] = 5; }
            if (pos5[0] - 1 < tam && pos5[1] + 2 < tam) { tableroOriginal.TableroAux[pos5[0] - 1, pos5[1] + 2] = 5; }

            //Caballo B
            ficha = tableroOriginal.GetFichaCod(6); //obtenemos la ficha que queremos 
            pos6 = ficha.CalcularPosicion(ficha, tableroOriginal); //buscamos la posicion de la fich
            if (pos6[0] + 2 < tam && pos6[1] + 1 < tam) { tableroOriginal.TableroAux[pos6[0] + 2, pos6[1] + 1] = 6; }
            if (pos6[0] + 2 < tam && pos6[1] - 1 < tam) { tableroOriginal.TableroAux[pos6[0] + 2, pos6[1] - 1] = 6; }
            if (pos6[0] - 2 < tam && pos6[1] - 1 < tam) { tableroOriginal.TableroAux[pos6[0] - 2, pos6[1] - 1] = 6; }
            if (pos6[0] - 2 < tam && pos6[1] + 1 < tam) { tableroOriginal.TableroAux[pos6[0] - 2, pos6[1] + 1] = 6; }
            if (pos6[0] + 1 < tam && pos6[1] + 2 < tam) { tableroOriginal.TableroAux[pos6[0] + 1, pos6[1] + 2] = 6; }
            if (pos6[0] + 1 < tam && pos6[1] - 2 < tam) { tableroOriginal.TableroAux[pos6[0] + 1, pos6[1] - 2] = 6; }
            if (pos6[0] - 1 < tam && pos6[1] - 2 < tam) { tableroOriginal.TableroAux[pos6[0] - 1, pos6[1] - 2] = 6; }
            if (pos6[0] - 1 < tam && pos6[1] + 2 < tam) { tableroOriginal.TableroAux[pos6[0] - 1, pos6[1] + 2] = 6; }

            //Torre A
            ficha = tableroOriginal.GetFichaCod(7); //obtenemos la ficha que queremos 
            pos7 = ficha.CalcularPosicion(ficha, tableroOriginal); //buscamos la posicion de la fich
            for (int i = pos7[0]; i < tam; i++)
            {     //i++
                tableroOriginal.TableroAux[i, pos7[1]] = 7;
            }
            for (int i = tam; i > pos7[0]; i++)
            {     //i--
                tableroOriginal.TableroAux[i, pos7[1]] = 7;
            }
            for (int j = tam; j > pos7[0]; j++)
            {     //j--
                tableroOriginal.TableroAux[pos7[0], j] = 7;
            }
            for (int j = pos7[1]; j < tam; j++)
            {     //j++
                tableroOriginal.TableroAux[pos7[0], j] = 7;
            }

            //Torre B
            ficha = tableroOriginal.GetFichaCod(8); //obtenemos la ficha que queremos 
            pos8 = ficha.CalcularPosicion(ficha, tableroOriginal); //buscamos la posicion de la fich
            for (int i = pos8[0]; i < tam; i++)
            {     //i++
                tableroOriginal.TableroAux[i, pos8[1]] = 8;
            }
            for (int i = tam; i > pos8[0]; i++)
            {     //i--
                tableroOriginal.TableroAux[i, pos8[1]] = 8;
            }
            for (int j = tam; j > pos8[0]; j++)
            {     //j--
                tableroOriginal.TableroAux[pos8[0], j] = 8;
            }
            for (int j = pos8[1]; j < tam; j++)
            {     //j++
                tableroOriginal.TableroAux[pos8[0], j] = 8;
            }

            //TorreCaballo
            ficha = tableroOriginal.GetFichaCod(9); //obtenemos la ficha que queremos 
            pos9 = ficha.CalcularPosicion(ficha, tableroOriginal); //buscamos la posicion de la fich
            for (int i = pos9[0]; i < tam; i++)
            {     //i++
                tableroOriginal.TableroAux[i, pos9[1]] = 9;
            }
            for (int i = tam; i > pos9[0]; i++)
            {     //i--
                tableroOriginal.TableroAux[i, pos9[1]] = 9;
                for (int j = tam; j > pos9[0]; j++)
                {     //j--
                    tableroOriginal.TableroAux[pos9[0], j] = 9;
                }
                for (int j = pos9[1]; j < tam; j++)
                {     //j++
                    tableroOriginal.TableroAux[pos9[0], j] = 9;
                }
                if (pos9[0] + 2 < tam && pos9[1] + 1 < tam) { tableroOriginal.TableroAux[pos9[0] + 2, pos9[1] + 1] = 9; }
                if (pos9[0] + 2 < tam && pos9[1] - 1 < tam) { tableroOriginal.TableroAux[pos9[0] + 2, pos9[1] - 1] = 9; }
                if (pos9[0] - 2 < tam && pos9[1] - 1 < tam) { tableroOriginal.TableroAux[pos9[0] - 2, pos9[1] - 1] = 9; }
                if (pos9[0] - 2 < tam && pos9[1] + 1 < tam) { tableroOriginal.TableroAux[pos9[0] - 2, pos9[1] + 1] = 9; }
                if (pos9[0] + 1 < tam && pos9[1] + 2 < tam) { tableroOriginal.TableroAux[pos9[0] + 1, pos9[1] + 2] = 9; }
                if (pos9[0] + 1 < tam && pos9[1] - 2 < tam) { tableroOriginal.TableroAux[pos9[0] + 1, pos9[1] - 2] = 9; }
                if (pos9[0] - 1 < tam && pos9[1] - 2 < tam) { tableroOriginal.TableroAux[pos9[0] - 1, pos9[1] - 2] = 9; }
                if (pos9[0] - 1 < tam && pos9[1] + 2 < tam) { tableroOriginal.TableroAux[pos9[0] - 1, pos9[1] + 2] = 9; }

                return tableroOriginal.TableroAux;
            }
        }
    }
}

