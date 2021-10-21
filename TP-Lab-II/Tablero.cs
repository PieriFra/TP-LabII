﻿using System;
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

        public Tablero CalculoSolucion(Tablero tableroOriginal, List<Tablero> ListaResultados, int n_tableros) //devuelve el tablero resultado
        {
            var rand = new Random(); 
            int mov = 0;
            do
            {
                if (mov < 8)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        int codigo = rand.Next(8);
                        Ficha ficha_mover = tableroOriginal.Get_FichaCodigo(codigo);
                        if(ficha_mover != null)
                            ficha_mover.CalcularMovimiento(ficha_mover, tableroOriginal);
                        AnalizarTableroAux(tableroOriginal);
                        mov++;
                    }
                }

                int cont = 0;
                Ficha FichaMagica = Get_FichaCodigo(9);

                //si en 8 movimientos no encontramos una solución juntamos un caballo y una torre y movemos siempre esa ficha
                for (int i = 0; i < tam; i++)
                {   for(int j=0; j<tam;j++)
                    {
                        if (tableroOriginal.Get_CodigoFichaOrg(i, j) == 6 || tableroOriginal.Get_CodigoFichaOrg(i, j) == 7)
                        {
                            //TENGO QUE ELIMINAR LAS FICHAS 6 Y 7 DEL TABLERO ORIGINAL, PONGO EN 0 TODO
                            tableroOriginal.Get_FichaPosicion(i, j).SetNombre(" ");
                            tableroOriginal.Get_FichaPosicion(i, j).SetCodigo(0);
                            tableroOriginal.Set_CodigoFichaOrg(i, j, tableroOriginal.Get_FichaPosicion(i, j));
                            cont++;
                            if (cont == 2)
                            {
                                tableroOriginal.Set_CodigoFichaOrg(i, j, FichaMagica);
                            }
                        } 
                    }
                
                }

                FichaMagica.CalcularMovimiento(FichaMagica, tableroOriginal); //realizamos un movimiento
                AnalizarTableroAux(tableroOriginal);

            } while (VerificarTablero(tableroOriginal.TableroAux) == false); 

            
            return tableroOriginal;
        }

        public void AnalizarTableroAux(Tablero tableroOriginal) //LLena los casilleros que pueden ser atacados
        {
            int[] pos1 = new int[2];
            int[] pos2 = new int[2];
            int[] pos3 = new int[2];
            int[] pos4 = new int[2];
            int[] pos5 = new int[2];
            int[] pos6 = new int[2];
            int[] pos7 = new int[2];
            int[] pos8 = new int[2];
            int[] pos9 = new int[2];

            Ficha ficha = new Ficha();
            //reina 
            ficha = tableroOriginal.Get_FichaCodigo(1); //obtenemos la ficha que queremos 
            pos1 = ficha.CalcularPosicion(ficha, tableroOriginal); //buscamos la posicion de la ficha
            for (int k = 0; k < tam; k++)
            {
                //diagonal derch acendente
                if (pos1[0] + k < tam  && pos1[1] + k < tam)
                    tableroOriginal.TableroAux[pos1[0] + k, pos1[1] + k] = 1;
                //diagonal izq decendente 
                if (pos1[0] - k >= 0 && pos1[1] - k >= 0 )
                    tableroOriginal.TableroAux[pos1[0] - k, pos1[1]-  k] = 1;
                //diagonal izq acendente
                if (pos1[0] - k >= 0 && pos1[1] + k < tam)
                    tableroOriginal.TableroAux[pos1[0] - k, pos1[1] + k] = 1;
                //diagonal derch decendente
                if (pos1[0] + k <tam && pos1[1] - k >= 0)
                    tableroOriginal.TableroAux[pos1[0] + k, pos1[1] - k] = 1;
            }
            for (int i = pos1[0]; i < tam; i++) {     //i++  horizontal izq
                tableroOriginal.TableroAux[i, pos1[1] ]= 1; 
            }
            for (int i = 0; i < pos1[0]; i++) {     //i--   horizontal derch
                tableroOriginal.TableroAux[i, pos1[1]] = 1;
            }

            for (int j = tam-1; j > pos1[0]; j--)
            {     //j-- vertical superior
                tableroOriginal.TableroAux[pos1[0], j] = 1;
            }
            for (int j = 0; j < pos1[1]; j++)
            {     //j++ vertical inferior
                tableroOriginal.TableroAux[pos1[0], j] = 1;
            }

            //rey 
            ficha = tableroOriginal.Get_FichaCodigo(2); //obtenemos la ficha que queremos 
            pos2 = ficha.CalcularPosicion(ficha, tableroOriginal); //buscamos la posicion de la ficha

            if (pos2[0] + 1 < tam) { tableroOriginal.TableroAux[pos2[0] + 1, pos2[1]] = 2; }
            if (pos2[0] - 1 >0) { tableroOriginal.TableroAux[pos2[0] - 1, pos2[1]] = 2; }
            if (pos2[1] + 1 < tam) { tableroOriginal.TableroAux[pos2[0], pos2[1]+1] = 2; }
            if (pos2[1] - 1 > 0) { tableroOriginal.TableroAux[pos2[0], pos2[1] - 1] = 2; }
            if (pos2[1] + 1 < tam && pos2[0] + 1 < tam) { tableroOriginal.TableroAux[pos2[0]+1, pos2[1] + 1] = 2; }
            if (pos2[1] + 1 < tam && pos2[0] - 1 > 0) { tableroOriginal.TableroAux[pos2[0] - 1, pos2[1] + 1] = 2; }
            if (pos2[1] -1 > 0 && pos2[0] + 1 < tam) { tableroOriginal.TableroAux[pos2[0] + 1, pos2[1] - 1] = 2; }
            if (pos2[1] - 1 > 0 && pos2[0] - 1 > 0) { tableroOriginal.TableroAux[pos2[0] - 1, pos2[1] - 1] = 2; }

            //Alfil A
            ficha = tableroOriginal.Get_FichaCodigo(3); //obtenemos la ficha que queremos 
            pos3 = ficha.CalcularPosicion(ficha, tableroOriginal);
            for (int k = 0; k < tam; k++)
            {
                //diagonal derch acendente
                if (pos3[0] + k < tam && pos3[1] + k < tam)
                    tableroOriginal.TableroAux[pos3[0] + k, pos3[1] + k] = 3;
                //diagonal izq decendente 
                if (pos3[0] - k >= 0 && pos3[1] - k >= 0)
                    tableroOriginal.TableroAux[pos3[0] - k, pos3[1] - k] = 3;
                //diagonal izq acendente
                if (pos3[0] - k >= 0 && pos3[1] + k < tam)
                    tableroOriginal.TableroAux[pos3[0] - k, pos3[1] + k] = 3;
                //diagonal derch decendente
                if (pos3[0] + k < tam && pos3[1] - k >= 0)
                    tableroOriginal.TableroAux[pos1[0] + k, pos1[1] - k] = 3;
            }

            //Alfil B
            ficha = tableroOriginal.Get_FichaCodigo(4); //obtenemos la ficha que queremos 
            pos4 = ficha.CalcularPosicion(ficha, tableroOriginal); //buscamos la posicion de la fich
            for (int k = 0; k < tam; k++)
            {
                //diagonal derch acendente
                if (pos4[0] + k < tam && pos4[1] + k < tam)
                    tableroOriginal.TableroAux[pos4[0] + k, pos4[1] + k] = 4;
                //diagonal izq decendente 
                if (pos4[0] - k >= 0 && pos4[1] - k >= 0)
                    tableroOriginal.TableroAux[pos4[0] - k, pos4[1] - k] = 4;
                //diagonal izq acendente
                if (pos4[0] - k >= 0 && pos4[1] + k < tam)
                    tableroOriginal.TableroAux[pos4[0] - k, pos4[1] + k] = 4;
                //diagonal derch decendente
                if (pos4[0] + k < tam && pos4[1] - k >= 0)
                    tableroOriginal.TableroAux[pos4[0] + k, pos4[1] - k] = 4;
            }

            //Caballo A
            ficha = tableroOriginal.Get_FichaCodigo(5); //obtenemos la ficha que queremos 
            pos5 = ficha.CalcularPosicion(ficha, tableroOriginal); //buscamos la posicion de la fich
            if (pos5[0] + 2 < tam && pos5[1] + 1 < tam) { tableroOriginal.TableroAux[pos5[0] + 2, pos5[1] + 1] = 5; }
            if (pos5[0] + 2 < tam && pos5[1] - 1 >= 0) { tableroOriginal.TableroAux[pos5[0] + 2, pos5[1] - 1] = 5; }
            if (pos5[0] - 2 > 0 && pos5[1] - 1 > 0) { tableroOriginal.TableroAux[pos5[0] - 2, pos5[1] - 1] = 5; }
            if (pos5[0] - 2 > 0 && pos5[1] + 1 < tam) { tableroOriginal.TableroAux[pos5[0] - 2, pos5[1] + 1] = 5; }
            if (pos5[0] + 1 < tam && pos5[1] + 2 < tam) { tableroOriginal.TableroAux[pos5[0] + 1, pos5[1] + 2] = 5; }
            if (pos5[0] + 1 < tam && pos5[1] - 2 > 0) { tableroOriginal.TableroAux[pos5[0] + 1, pos5[1] - 2] = 5; }
            if (pos5[0] - 1 > 0 && pos5[1] - 2 > 0) { tableroOriginal.TableroAux[pos5[0] - 1, pos5[1] - 2] = 5; }
            if (pos5[0] - 1 > 0 && pos5[1] + 2 < tam) { tableroOriginal.TableroAux[pos5[0] - 1, pos5[1] + 2] = 5; }

            //Caballo B
            ficha = tableroOriginal.Get_FichaCodigo(6); //obtenemos la ficha que queremos 
            if (ficha != null)
            {
                pos6 = ficha.CalcularPosicion(ficha, tableroOriginal); //buscamos la posicion de la fich
                if (pos6[0] + 2 < tam && pos6[1] + 1 < tam) { tableroOriginal.TableroAux[pos6[0] + 2, pos6[1] + 1] = 6; }
                if (pos6[0] + 2 < tam && pos6[1] - 1 > 0) { tableroOriginal.TableroAux[pos6[0] + 2, pos6[1] - 1] = 6; }
                if (pos6[0] - 2 > 0 && pos6[1] - 1 > 0) { tableroOriginal.TableroAux[pos6[0] - 2, pos6[1] - 1] = 6; }
                if (pos6[0] - 2 > 0 && pos6[1] + 1 < tam) { tableroOriginal.TableroAux[pos6[0] - 2, pos6[1] + 1] = 6; }
                if (pos6[0] + 1 < tam && pos6[1] + 2 < tam) { tableroOriginal.TableroAux[pos6[0] + 1, pos6[1] + 2] = 6; }
                if (pos6[0] + 1 < tam && pos6[1] - 2 > 0) { tableroOriginal.TableroAux[pos6[0] + 1, pos6[1] - 2] = 6; }
                if (pos6[0] - 1 > 0 && pos6[1] - 2 > 0) { tableroOriginal.TableroAux[pos6[0] - 1, pos6[1] - 2] = 6; }
                if (pos6[0] - 1 > 0 && pos6[1] + 2 < tam) { tableroOriginal.TableroAux[pos6[0] - 1, pos6[1] + 2] = 6; }
            }
            

            //Torre A
            ficha = tableroOriginal.Get_FichaCodigo(7); //obtenemos la ficha que queremos 
            if (ficha != null)
            {
                pos7 = ficha.CalcularPosicion(ficha, tableroOriginal); //buscamos la posicion de la fich
                for (int i = pos7[0]; i < tam; i++)
                {     //i++
                    tableroOriginal.TableroAux[i, pos7[1]] = 7;
                }
                for (int i = tam - 1; i > pos7[0]; i--)
                {     //i--
                    tableroOriginal.TableroAux[i, pos7[1]] = 7;
                }
                for (int j = tam - 1; j > pos7[0]; j--)
                {     //j--
                    tableroOriginal.TableroAux[pos7[0], j] = 7;
                }
                for (int j = pos7[1]; j < tam; j++)
                {     //j++
                    tableroOriginal.TableroAux[pos7[0], j] = 7;
                }
            }
           
            //Torre B
            ficha = tableroOriginal.Get_FichaCodigo(8); //obtenemos la ficha que queremos 
            pos8 = ficha.CalcularPosicion(ficha, tableroOriginal); //buscamos la posicion de la fich
            for (int i = pos8[0]; i < tam; i++)
            {     //i++
                tableroOriginal.TableroAux[i, pos8[1]] = 8;
            }
            for (int i = tam-1; i > pos8[0]; i--)
            {     //i--
                tableroOriginal.TableroAux[i, pos8[1]] = 8;
            }
            for (int j = tam-1; j > pos8[0]; j--)
            {     //j--
                tableroOriginal.TableroAux[pos8[0], j] = 8;
            }
            for (int j = pos8[1]; j < tam; j++)
            {     //j++
                tableroOriginal.TableroAux[pos8[0], j] = 8;
            }

            //TorreCaballo
            ficha = tableroOriginal.Get_FichaCodigo(9); //obtenemos la ficha que queremos 
            pos9 = ficha.CalcularPosicion(ficha, tableroOriginal); //buscamos la posicion de la fich
            for (int i = pos9[0]; i < tam; i++)
            {     //i++
                tableroOriginal.TableroAux[i, pos9[1]] = 9;
            }
            for (int i = tam - 1; i > pos9[0]; i--)
            {     //i--
                tableroOriginal.TableroAux[i, pos9[1]] = 9;
            }
            for (int j = tam - 1; j > pos9[0]; j--)
            {     //j--
                tableroOriginal.TableroAux[pos9[0], j] = 9;
            }
            for (int j = pos9[1]; j < tam; j++)
            {     //j++
                tableroOriginal.TableroAux[pos9[0], j] = 9;
            }
            if (pos9[0] + 2 < tam && pos9[1] + 1 < tam) { tableroOriginal.TableroAux[pos9[0] + 2, pos9[1] + 1] = 9; }
            if (pos9[0] + 2 < tam && pos9[1] - 1 > 0) { tableroOriginal.TableroAux[pos9[0] + 2, pos9[1] - 1] = 9; }
            if (pos9[0] - 2 > 0 && pos9[1] - 1 > 0) { tableroOriginal.TableroAux[pos9[0] - 2, pos9[1] - 1] = 9; }
            if (pos9[0] - 2 > 0 && pos9[1] + 1 < tam)
            {
                tableroOriginal.TableroAux[pos9[0] - 2, pos9[1] + 1] = 9;
                if (pos9[0] + 1 < tam && pos9[1] + 2 < tam) { tableroOriginal.TableroAux[pos9[0] + 1, pos9[1] + 2] = 9; }
                if (pos9[0] + 1 < tam && pos9[1] - 2 > 0) { tableroOriginal.TableroAux[pos9[0] + 1, pos9[1] - 2] = 9; }
                if (pos9[0] - 1 > 0 && pos9[1] - 2 > 0) { tableroOriginal.TableroAux[pos9[0] - 1, pos9[1] - 2] = 9; }
                if (pos9[0] - 1 > 0 && pos9[1] + 2 < tam) { tableroOriginal.TableroAux[pos9[0] - 1, pos9[1] + 2] = 9; }


            }
        }


        public void CargarTablero(Tablero TableroOrg)
        {
            var rand = new Random();
            int opcion = rand.Next(3);

            switch(opcion)
            {
                case 0:
                    TableroOrg.TableroOriginal[0, 0] = 7;
                    TableroOrg.TableroOriginal[0, 1] = 5;
                    TableroOrg.TableroOriginal[0, 2] = 3;
                    TableroOrg.TableroOriginal[0, 3] = 1;
                    TableroOrg.TableroOriginal[0, 4] = 2;
                    TableroOrg.TableroOriginal[0, 5] = 4;
                    TableroOrg.TableroOriginal[0, 6] = 6;
                    TableroOrg.TableroOriginal[0, 7] = 8;

                    break;
                case 1:
                    TableroOrg.TableroOriginal[3, 0] = 7;
                    TableroOrg.TableroOriginal[3, 1] = 5;
                    TableroOrg.TableroOriginal[3, 2] = 3;
                    TableroOrg.TableroOriginal[3, 3] = 1;
                    TableroOrg.TableroOriginal[3, 4] = 2;
                    TableroOrg.TableroOriginal[3, 5] = 4;
                    TableroOrg.TableroOriginal[3, 6] = 6;
                    TableroOrg.TableroOriginal[3, 7] = 8;
                    break;
                case 2:
                    TableroOrg.TableroOriginal[7, 0] = 7;
                    TableroOrg.TableroOriginal[7, 1] = 5;
                    TableroOrg.TableroOriginal[7, 2] = 3;
                    TableroOrg.TableroOriginal[7, 3] = 1;
                    TableroOrg.TableroOriginal[7, 4] = 2;
                    TableroOrg.TableroOriginal[7, 5] = 4;
                    TableroOrg.TableroOriginal[7, 6] = 6;
                    TableroOrg.TableroOriginal[7, 7] = 8;
                    break;
            }

        }


        ~Tablero() {;}
    }
}

