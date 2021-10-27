using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Lab_II
{
    class Tablero
    {
        //Atributos
        private int tam;
        public List<Ficha> ListaFichas;
        private int [,]TableroOriginal;
        private int [,]TableroAux;

        //Metodos
        public Tablero(List<Ficha> ListaFichas_)
        {
            tam = 8;
            ListaFichas = ListaFichas_;
            TableroAux = new int [tam, tam];
            TableroOriginal = new int[tam, tam];
            for (int i = 0; i < tam; i++)
            {
                for (int j = 0; j < tam; j++)
                {
                    TableroAux[i, j] = 0;
                    TableroOriginal[i, j] = 0;
                }
            }
        }
        public void Set_CodigoFichaOrg(int I, int J, Ficha ficha)//Cambia el codigo en la posicion que le paso
        {
            TableroOriginal[I, J] = ficha.Get_Codigo(); 
        }
        public int[,] GetTableroOrig() { return TableroOriginal; } //devuelve el tableroOriginal completo
        public int Get_CodigoFichaOrg(int k , int l) //devuelve el codigo de la ficha
        {
            for (int i = 0; i < tam; i++) 
            {
                for (int j = 0; j < tam; j++)
                {
                    if(k==i && l==j)
                        return TableroOriginal[k,l]; 
                }
            }
            return 0; 
        }
        public int GetTam() {return tam;} //devuelve el tamanio 
        public Ficha Get_FichaPosicion(int i, int j) //devuelve una ficha de la lista de la posicion que le paso
        {
            int codigo=TableroOriginal[i, j];
            return ListaFichas[codigo-1]; 
        } 
        public Ficha Get_FichaCodigo(int codigo) //Devuelve la ficha por el codigo que le paso
        {
            for (int i=0; i < 9; i++)
            {
                if (ListaFichas[i].Get_Codigo() == codigo)
                {
                    return ListaFichas[i];
                }
            }
            return null; 
        } 

        public bool VerificarTablero(int [,]tableroAux) //verifica que todas las posciones del tablero esten siendo atacadas
        {
            for (int i=0; i< tam; i++)
            {
                for(int j=0; j<tam;j++)
                {
                    //en caso de encontar una posicion que no esta siendo atacada retorna false
                    if (tableroAux[i, j] == 0) 
                        return false;
                }
            }
            /*si recorre todo el tablero y no encuentra ninguna posicion libre, efectivamente todas las posciones
           estan siendo atacadas y retorna true*/
            return true; 
        }

        public Tablero CalculoSolucion(List<Tablero> ListaResultados, int n_tableros) //devuelve el tablero resultado
        { 
            int mov = 0;
            int contador = 0;
            bool auxT=false;
            bool auxT2=false;
            do
            {
                if (mov < 8)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        Ficha ficha_mover = Get_FichaCodigo(1);
                        if (GeneraSolucion(ficha_mover) == true)
                        {
                            mov = 8;
                            break;
                        }
                        ficha_mover = Get_FichaCodigo(2);
                        if (GeneraSolucion(ficha_mover) == true)
                        {
                            mov = 8;
                            break;
                        }
                        ficha_mover = Get_FichaCodigo(3);
                        if (GeneraSolucion(ficha_mover) == true)
                        {
                            mov = 8;
                            break;
                        }
                        ficha_mover = Get_FichaCodigo(4);
                        if (GeneraSolucion(ficha_mover) == true)
                        {
                            mov = 8;
                            break;
                        }
                        ficha_mover = Get_FichaCodigo(5);
                        if (GeneraSolucion(ficha_mover) == true)
                        {
                            mov = 8;
                            break;
                        }
                        ficha_mover = Get_FichaCodigo(6);
                        if (GeneraSolucion(ficha_mover) == true)
                        {
                            mov = 8;
                            break;
                        }
                        ficha_mover = Get_FichaCodigo(7);
                        if (GeneraSolucion(ficha_mover) == true)
                        {
                            mov = 8;
                            break;
                        }
                        ficha_mover = Get_FichaCodigo(8);
                        if (GeneraSolucion(ficha_mover) == true)
                        {
                            mov = 8;
                            break;
                        }
                        mov++;
                    }
                }
                auxT = VerificarTablero(TableroAux);
                if (auxT == false)
                {
                    mov = 0;
                    int cont = 0;
                    Ficha FichaMagica = Get_FichaCodigo(9);

                    //si en 8 movimientos no encontramos una solución juntamos un caballo y una torre y movemos siempre esa ficha
                    if (contador != 1) //solo eliminamos las fichas una sola vez 
                    {
                        //recorremos el tablero 
                        for (int i = 0; i < tam; i++)
                        {
                            for (int j = 0; j < tam; j++)
                            {
                                //buscamos las fichas que queremos eliminar 
                                if (Get_CodigoFichaOrg(i, j) == 6 || Get_CodigoFichaOrg(i, j) == 7)
                                {
                                    //TENGO QUE ELIMINAR LAS FICHAS 6 Y 7 DEL TABLERO ORIGINAL, PONGO EN 0 TODO
                                    Get_FichaPosicion(i, j).SetNombre(" ");
                                    Get_FichaPosicion(i, j).SetCodigo(0);
                                    Set_CodigoFichaOrg(i, j, Get_FichaPosicion(i, j));
                                    cont++; //para que pase dos veces y elimine las fichas

                                    if (cont == 2) //ya eliminamos las dos fichas 
                                    {
                                        //en la pos de la ultima ficha que eliminamos agregamos la ficha combinada
                                        Set_CodigoFichaOrg(i, j, FichaMagica); 
                                    }

                                    contador = 1;
                                }
                            }
                        }
                    }
                    FichaMagica.CalcularMovimiento(this); //realizamos un movimiento
                    AnalizarTableroAux();
                    auxT2 = VerificarTablero(TableroAux);
                }

            } while (auxT == false && auxT2 == false);
            return this;
        }
        public bool GeneraSolucion (Ficha ficha_mover)
        {
            if (ficha_mover != null)
                ficha_mover.CalcularMovimiento(this);
            AnalizarTableroAux();
            if (VerificarTablero(TableroAux) == true)
                return true;
            return false;
        }
        public void MovimientoVH(Ficha ficha)
        {
            int [] pos = ficha.CalcularPosicion( this); //buscamos la posicion de la ficha
            for (int i = pos[0]; i < tam; i++)
            {     //i++  horizontal izq
                TableroAux[i, pos[1]] = ficha.Get_Codigo();
            }
            for (int i = 0; i < pos[0]; i++)
            {     //i--   horizontal derch
                TableroAux[i, pos[1]] = ficha.Get_Codigo();
            }
            for (int j = tam - 1; j > pos[0]; j--)
            {     //j-- vertical superior
                TableroAux[pos[0], j] = ficha.Get_Codigo();
            }
            for (int j = 0; j < pos[1]; j++)
            {     //j++ vertical inferior
                TableroAux[pos[0], j] = ficha.Get_Codigo();
            }
        }
        public void MovimientoDiagonal(Ficha ficha)
        {
            int[] pos = ficha.CalcularPosicion( this); //buscamos la posicion de la ficha
            for (int k = 0; k < tam; k++)
            {
                //diagonal derch decendente
                if (pos[0] + k < tam && pos[1] + k < tam)
                    TableroAux[pos[0] + k, pos[1] + k] = ficha.Get_Codigo();
                //diagonal izq acendente 
                if (pos[0] - k >= 0 && pos[1] - k >= 0)
                    TableroAux[pos[0] - k, pos[1] - k] = ficha.Get_Codigo();
                //diagonal izq decendente
                if (pos[0] - k >= 0 && pos[1] + k < tam)
                   TableroAux[pos[0] - k, pos[1] + k] = ficha.Get_Codigo();
                //diagonal derch acendente
                if (pos[0] + k < tam && pos[1] - k >= 0)
                    TableroAux[pos[0] + k, pos[1] - k] = ficha.Get_Codigo();
            }
        }
        public void MovimientoCaballo(Ficha ficha)
        {
           int [] pos = ficha.CalcularPosicion( this); //buscamos la posicion de la fich
            if (pos[0] + 2 < tam && pos[1] + 1 < tam) { TableroAux[pos[0] + 2, pos[1] + 1] = 5; }
            if (pos[0] + 2 < tam && pos[1] - 1 >= 0) { TableroAux[pos[0] + 2, pos[1] - 1] = 5; }
            if (pos[0] - 2 > 0 && pos[1] - 1 > 0) { TableroAux[pos[0] - 2, pos[1] - 1] = 5; }
            if (pos[0] - 2 > 0 && pos[1] + 1 < tam) { TableroAux[pos[0] - 2, pos[1] + 1] = 5; }
            if (pos[0] + 1 < tam && pos[1] + 2 < tam) { TableroAux[pos[0] + 1, pos[1] + 2] = 5; }
            if (pos[0] + 1 < tam && pos[1] - 2 > 0) { TableroAux[pos[0] + 1, pos[1] - 2] = 5; }
            if (pos[0] - 1 > 0 && pos[1] - 2 > 0) { TableroAux[pos[0] - 1, pos[1] - 2] = 5; }
            if (pos[0] - 1 > 0 && pos[1] + 2 < tam) { TableroAux[pos[0] - 1, pos[1] + 2] = 5; }
        }
        public void AnalizarTableroAux() //LLena los casilleros que pueden ser atacados
        {
            //ponemos el tablero auxiliar en 0
            for (int i = 0; i < tam; i++)
            {
                for (int j = 0; j < tam; j++)
                {
                    TableroAux[i, j] = 0;
                }
            }
            Ficha ficha = new Ficha();

            //reina 
            ficha = Get_FichaCodigo(1); //obtenemos la ficha que queremos 
            MovimientoVH(ficha);
            MovimientoDiagonal(ficha);

            //rey 
            ficha = Get_FichaCodigo(2); //obtenemos la ficha que queremos 
            int [] pos = ficha.CalcularPosicion( this); //buscamos la posicion de la ficha

            if (pos[0] + 1 < tam) { TableroAux[pos[0] + 1, pos[1]] = 2; }
            if (pos[0] - 1 >0) { TableroAux[pos[0] - 1, pos[1]] = 2; }
            if (pos[1] + 1 < tam) { TableroAux[pos[0], pos[1]+1] = 2; }
            if (pos[1] - 1 > 0) { TableroAux[pos[0], pos[1] - 1] = 2; }
            if (pos[1] + 1 < tam && pos[0] + 1 < tam) { TableroAux[pos[0]+1, pos[1] + 1] = 2; }
            if (pos[1] + 1 < tam && pos[0] - 1 > 0) { TableroAux[pos[0] - 1, pos[1] + 1] = 2; }
            if (pos[1] -1 > 0 && pos[0] + 1 < tam) { TableroAux[pos[0] + 1, pos[1] - 1] = 2; }
            if (pos[1] - 1 > 0 && pos[0] - 1 > 0) { TableroAux[pos[0] - 1, pos[1] - 1] = 2; }

            //Alfil A
            ficha = Get_FichaCodigo(3); //obtenemos la ficha que queremos 
            MovimientoDiagonal(ficha);

            //Alfil B
            ficha = Get_FichaCodigo(4); //obtenemos la ficha que queremos 
            MovimientoDiagonal(ficha);

            //Caballo A
            ficha = Get_FichaCodigo(5); //obtenemos la ficha que queremos 
            MovimientoCaballo(ficha);

            //Caballo B
            ficha = Get_FichaCodigo(6); //obtenemos la ficha que queremos 
            if (ficha != null)
            {
                MovimientoCaballo(ficha);
            }
            
            //Torre A
            ficha = Get_FichaCodigo(7); //obtenemos la ficha que queremos 
            if (ficha != null)
            {
                MovimientoVH(ficha);
            }
           
            //Torre B
            ficha = Get_FichaCodigo(8); //obtenemos la ficha que queremos 
            MovimientoVH(ficha);

            //TorreCaballo
            ficha = Get_FichaCodigo(9); //obtenemos la ficha que queremos 
            int[] aux = ficha.CalcularPosicion(this);
            if (aux[0] != -1)
            {
                MovimientoVH(ficha);
                MovimientoCaballo(ficha);
            }
        }


        public void CargarTablero()
        {
            /*var rand = new Random();
            int opcion = rand.Next(3);

            switch(opcion)
            {
                case 0:
                    TableroOriginal[0, 0] = 7;
                    TableroOriginal[0, 1] = 5;
                    TableroOriginal[0, 2] = 3;
                    TableroOriginal[0, 3] = 1;
                    TableroOriginal[0, 4] = 2;
                    TableroOriginal[0, 5] = 4;
                    TableroOriginal[0, 6] = 6;
                    TableroOriginal[0, 7] = 8;

                    break;
                case 1:
                    TableroOriginal[3, 0] = 7;
                    TableroOriginal[3, 1] = 5;
                    TableroOriginal[3, 2] = 3;
                    TableroOriginal[3, 3] = 1;
                    TableroOriginal[3, 4] = 2;
                    TableroOriginal[3, 5] = 4;
                    TableroOriginal[3, 6] = 6;
                    TableroOriginal[3, 7] = 8;
                    break;
                case 2:
                    TableroOriginal[7, 0] = 7;
                    TableroOriginal[7, 1] = 5;
                    TableroOriginal[7, 2] = 3;
                    TableroOriginal[7, 3] = 1;
                    TableroOriginal[7, 4] = 2;
                    TableroOriginal[7, 5] = 4;
                    TableroOriginal[7, 6] = 6;
                    TableroOriginal[7, 7] = 8;
                    break;
            }*/
            /*
            TableroOriginal[3, 6] = 6; //caballo
            TableroOriginal[2, 2] = 7; //torre
            TableroOriginal[3, 4] = 1; //reina
            TableroOriginal[3, 2] = 3; //alfil
            TableroOriginal[3, 3] = 4; //alfil
            TableroOriginal[4, 4] = 2; //rey
            TableroOriginal[4, 3] = 8; //torre
            TableroOriginal[6, 3] = 5; //caballo*/

            //nos generamos dos posiciones aleatorias 
            var rand = new Random();
            int i = 0;
            do
            {
                int PosI = rand.Next(0, 7);
                int PosJ = rand.Next(0, 7);

                if (Get_CodigoFichaOrg(PosI, PosJ) == 0)
                {
                    TableroOriginal[PosI, PosJ] = i + 1;
                    i++;
                }

            } while (i < 8);
 
        }

        ~Tablero() {;}
    }
}

