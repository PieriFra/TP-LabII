using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Lab_II
{
    public class Tablero
    {
        //Atributos
        public int tam;
        public List<Ficha> ListaFichas;
        public int[,] TableroOriginal;
        public int[,] TableroAux;


        //Metodos
        public Tablero(List<Ficha> ListaFichas_)
        {
            tam = 8;
            ListaFichas = ListaFichas_;
            TableroAux = new int[tam, tam];
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
        public int Get_CodigoFichaOrg(int k, int l) //devuelve el codigo de la ficha
        {
            for (int i = 0; i < tam; i++)
            {
                for (int j = 0; j < tam; j++)
                {
                    if (k == i && l == j)
                        return TableroOriginal[k, l];
                }
            }
            return 0;
        }
        public int GetTam() { return tam; } //devuelve el tamanio 
        public Ficha Get_FichaPosicion(int i, int j) //devuelve una ficha de la lista de la posicion que le paso
        {
            int codigo = TableroOriginal[i, j];
            return ListaFichas[codigo - 1];
        }
        public Ficha Get_FichaCodigo(int codigo) //Devuelve la ficha por el codigo que le paso
        {
            for (int i = 0; i < 9; i++)
            {
                if (ListaFichas[i].Get_Codigo() == codigo)
                {
                    return ListaFichas[i];
                }
            }
            return null;
        }

        public bool VerificarTablero(int[,] tableroAux) //verifica que todas las posciones del tablero esten siendo atacadas
        {
            for (int i = 0; i < tam; i++)
            {
                for (int j = 0; j < tam; j++)
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

        public Tablero CalculoSolucion(List<Tablero> ListaResultados) //devuelve el tablero resultado
        {
            int mov = 0;
            int contador = 0;
            bool auxT = false;
            bool auxT2 = false;
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
                        //nos guardamos la posicion de la torre a eliminar
                        Ficha torre = Get_FichaCodigo(7);
                        int[] posTorre = torre.CalcularPosicion(this);
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
                                        //Set_CodigoFichaOrg(i, j, FichaMagica); 
                                        Set_CodigoFichaOrg(posTorre[0], posTorre[1], FichaMagica);
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
        public bool GeneraSolucion(Ficha ficha_mover)
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
            int[] pos = ficha.CalcularPosicion(this); //buscamos la posicion de la ficha
           
            int[] aux1 = new int[2];
            int[] aux2 = new int[2];
            int[] aux3 = new int[2];
            int[] aux4 = new int[2];
            aux1[0] = -1;
            aux1[1] = -1;
            aux2[0] = -1;
            aux2[1] = -1;
            aux3[0] = -1;
            aux3[1] = -1;
            aux4[0] = -1;
            aux4[1] = -1;
           // vertical des
            for (int i = pos[0]; i < tam; i++)
            {
                if (TableroOriginal[i, pos[1]] != 0 && TableroOriginal[i, pos[1]] != ficha.Get_Codigo())
                {
                    aux1[0] = i;
                    aux1[1] = pos[1];
                    i = tam;
                }
            }
            for (int i = pos[0]; i < tam; i++)
            {
                if (aux1[0] == -1)
                    TableroAux[i, pos[1]] = 10;
                else
                {
                    if (i <= aux1[0])
                        TableroAux[i, pos[1]] = 10;
                    else
                    {
                        if (TableroAux[i, pos[1]] != 10)
                            TableroAux[i, pos[1]] = ficha.Get_Codigo();
                    }
                }
            }

            // vertical superior
            for (int i = pos[0]; i >= 0; i--)
            {
                if (TableroOriginal[i, pos[1]] != 0 && TableroOriginal[i, pos[1]] != ficha.Get_Codigo())
                {
                    aux2[0] = i;
                    aux2[1] = pos[1];
                    i = 0;
                }
            }
            for (int i = pos[0]; i >= 0; i--)
            {
                if (aux2[0] == -1)
                {
                    TableroAux[i, pos[1]] = 10;
                }
                else
                {
                    if (i >= aux2[0])
                    {
                        TableroAux[i, pos[1]] = 10;
                    }
                    else
                    {
                        if (TableroAux[i, pos[1]] != 10)
                            TableroAux[i, pos[1]] = ficha.Get_Codigo(); }
                }
            }

            // horizontal derecha
            for (int i = pos[1]; i < tam; i++)
            {
                if (TableroOriginal[pos[0], i] != 0 && TableroOriginal[pos[0], i] != ficha.Get_Codigo())
                {
                    aux3[0] = pos[0];
                    aux3[1] = i;
                    i = tam;
                }
            }
            for (int i = pos[1]; i < tam; i++)
            {
                if (aux3[1] == -1)
                {
                    TableroAux[pos[0], i] = 10;
                }
                else
                {
                    if (i <= aux3[1])
                        TableroAux[pos[0], i] = 10;
                    else
                    { 
                        if(TableroAux[pos[0], i] !=10)
                            TableroAux[pos[0], i] = ficha.Get_Codigo();
                    }
                       
                }
            }

            // horizontal izq
            for (int i = pos[1]; i >= 0; i--)
            {
                if (TableroOriginal[pos[0], i] != 0 && TableroOriginal[pos[0], i] != ficha.Get_Codigo())
                {
                    aux4[0] = pos[0];
                    aux4[1] = i;
                    i = 0;
                }
            }
            for (int i = pos[1]; i >= 0; i--)
            {
                if (aux4[1] == -1)
                {
                    TableroAux[pos[0], i] = 10;
                }
                else
                {
                    if (i >= aux4[1])
                        TableroAux[pos[0], i] = 10;
                    else
                    {
                        if (TableroAux[pos[0], i] != 10)
                            TableroAux[pos[0], i] = ficha.Get_Codigo();
                    }
                        
                }
            }

        }
        public void MovimientoDiagonal(Ficha ficha)
        {
            int[] pos = ficha.CalcularPosicion(this); //buscamos la posicion de la ficha
            int[] aux1 = new int[2];
            int[] aux2 = new int[2];
            int[] aux3 = new int[2];
            int[] aux4 = new int[2];
            aux1[0] = -1;
            aux1[1] = -1;
            aux2[0] = -1;
            aux2[1] = -1;
            aux3[0] = -1;
            aux3[1] = -1;
            aux4[0] = -1;
            aux4[1] = -1;

            for (int k = 0; k < tam; k++)
            {
                if (pos[0] + k < tam && pos[1] + k < tam)
                {
                    if (TableroOriginal[pos[0] + k, pos[1] + k] != 0 && TableroOriginal[pos[0] + k, pos[1] + k] != ficha.Get_Codigo())
                    {
                        aux1[0] = pos[0] + k;
                        aux1[1] = pos[1] + k;
                        k = tam;
                    }
                }
            }

            for (int k = 0; k < tam; k++)
            {
                if (pos[0] - k >= 0 && pos[1] - k >= 0)
                {
                    if (TableroOriginal[pos[0] - k, pos[1] - k] != 0 && TableroOriginal[pos[0] - k, pos[1] - k] != ficha.Get_Codigo())
                    {
                        aux2[0] = pos[0] - k;
                        aux2[1] = pos[1] - k;
                        k = tam;
                    }
                }
            }

            for (int k = 0; k < tam; k++)
            {
                if (pos[0] - k >= 0 && pos[1] + k < tam)
                {
                    if (TableroOriginal[pos[0] - k, pos[1] + k] != 0 && TableroOriginal[pos[0] - k, pos[1] + k] != ficha.Get_Codigo())
                    {
                        aux3[0] = pos[0] - k;
                        aux3[1] = pos[1] + k;
                        k = tam;
                    }
                }
            }

            for (int k = 0; k < tam; k++)
            {
                if (pos[0] + k < tam && pos[1] - k >= 0)
                {
                    if (TableroOriginal[pos[0] + k, pos[1] - k] != 0 && TableroOriginal[pos[0] + k, pos[1] - k] != ficha.Get_Codigo())
                    {
                        aux4[0] = pos[0] + k;
                        aux4[1] = pos[1] - k;
                        k = tam;
                    }
                }
            }
            for (int k = 0; k < tam; k++)
            {

                //diagonal derch decendente
                if (aux1[0] == -1)
                {
                    if (pos[0] + k < tam && pos[1] + k < tam)
                        TableroAux[pos[0] + k, pos[1] + k] = 10;
                }
                else
                {
                    if (pos[0] + k <= aux1[0] && pos[1] + k <= aux1[1] && pos[0] + k < tam && pos[1] + k < tam)
                        TableroAux[pos[0] + k, pos[1] + k] = 10;
                    if (pos[0] + k >= aux1[0] && pos[1] + k >= aux1[1] && aux1[0] + k < tam && aux1[1] + k < tam
                        && TableroAux[aux1[0]+k, aux1[1]+k] !=10)
                        TableroAux[aux1[0] + k, aux1[1] + k] = ficha.Get_Codigo();
                }
                //diagonal izq acendente 
                if (aux2[0] == -1)
                {
                    if (pos[0] - k >= 0 && pos[1] - k >= 0)
                        TableroAux[pos[0] - k, pos[1] - k] = 10;
                }
                else
                {
                    if (pos[0] - k >= aux2[0] && pos[1] - k >= aux2[1] && pos[0] - k >= 0 && pos[1] - k >= 0)
                        TableroAux[pos[0] - k, pos[1] - k] = 10;
                    if (pos[0] - k <= aux2[0] && pos[1] - k <= aux2[1] && aux2[0] - k >= 0 && aux2[1] - k >= 0
                        && TableroAux[aux2[0] - k, aux2[1] - k] != 10)
                        TableroAux[aux2[0] - k, aux2[1] - k] = ficha.Get_Codigo();
                }
                //diagonal izq decendente
                if (aux4[0] == -1)
                {
                    if (pos[0] + k < tam && pos[1] - k >= 0)
                        TableroAux[pos[0] + k, pos[1] - k] = 10;
                }
                else
                {
                    if (pos[0] + k <= aux4[0] && pos[1] - k >= aux4[1] && pos[0] + k < tam && pos[1] - k >= 0)
                        TableroAux[pos[0] + k, pos[1] - k] = 10;
                    if (pos[0] + k >= aux4[0] && pos[1] - k <= aux4[1] && aux4[0] + k < tam && aux4[1] - k >= 0
                        && TableroAux[aux4[0] + k, aux4[1] - k] != 10)
                        TableroAux[aux4[0] + k, aux4[1] - k] = ficha.Get_Codigo();
                }
                //diagonal derecha acendente
                if (aux3[0] == -1)
                {
                    if (pos[0] - k >= 0 && pos[1] + k < tam)
                        TableroAux[pos[0] - k, pos[1] + k] = 10;
                }
                else
                {
                    if (pos[0] - k <= aux3[0] && pos[1] + k >= aux3[1] && pos[1] + k < tam && pos[0] - k >= 0)
                        TableroAux[pos[0] - k, pos[1] + k] = 10;
                    if (pos[0] - k > aux3[0] && pos[1] + k < aux3[1] && aux3[1] + k < tam && aux3[0] - k >= 0
                        && TableroAux[aux3[0] - k, aux3[1] + k] != 10)
                        TableroAux[aux3[0] - k, aux3[1] + k] = ficha.Get_Codigo();
                }
            }
        }

        public void MovimientoCaballo(Ficha ficha)
        {
            int[] pos = ficha.CalcularPosicion(this); //buscamos la posicion de la fich
            int[] aux1 = new int[2];
            aux1[0] = -1; aux1[1] = -1;
            int[] aux2 = new int[2];
            aux2[0] = -1; aux2[1] = -1;
            int[] aux3 = new int[2];
            aux3[0] = -1; aux3[1] = -1;
            int[] aux4 = new int[2];
            aux4[0] = -1; aux4[1] = -1;

            for (int i = 0; i < 3; i++)
            {
                if (pos[1] + i < tam && aux1[1] + i < tam && TableroOriginal[pos[0], pos[1] + i] != 0 &&
                    TableroOriginal[pos[0], pos[1] + i] != ficha.Get_Codigo())
                {
                    //horizontal derecha
                    aux1[0] = pos[0];
                    aux1[1] = pos[1] + i;
                }

                if (pos[0] + i < tam && aux2[0] + i < tam && TableroOriginal[pos[0] + i, pos[1]] != 0
                    && TableroOriginal[pos[0] + i, pos[1]] != ficha.Get_Codigo())
                {
                    //vertical inf
                    aux2[0] = pos[0] + i;
                    aux2[1] = pos[1];
                }

                if (pos[0] - i >= 0 && aux3[0] - i >= 0 && TableroOriginal[pos[0] - i, pos[1]] != 0 
                    && TableroOriginal[pos[0] - i, pos[1]] != ficha.Get_Codigo())
                {
                    //vertical sup
                    aux3[0] = pos[0] - i;
                    aux3[1] = pos[1];
                }

                if (pos[1] - i >= 0 && aux4[1] - i >= 0 && TableroOriginal[pos[0], pos[1] - i] != 0 
                    && TableroOriginal[pos[0], pos[1] - i] != ficha.Get_Codigo())
                {
                    //horizontal izq
                    aux4[0] = pos[0];
                    aux4[1] = pos[1] - i;
                }
            }        

            for (int i = 0; i < 3; i++)
            {
                //horizontal derecha
                if (aux1[0] == -1)
                {
                    if (pos[1] + i < tam)
                        TableroAux[pos[0], pos[1] + i] = 10;
                }
                else
                {
                    if(pos[1]+i<=aux1[1] && pos[1] + i < tam)
                        TableroAux[pos[0], pos[1] + i] = 10;
                    if(pos[1] + i > aux1[1] && pos[1] + i < tam && TableroAux[pos[0], pos[1] + i] != 10)
                        TableroAux[pos[0], pos[1] + i] = ficha.Get_Codigo();
                }

                //vertical inf
                if (aux2[0] == -1)
                {
                    if (pos[0] + i < tam)
                        TableroAux[pos[0] + i, pos[1]] = 10;
                }
                else
                {
                    if(pos[0]+i<=aux2[0] && pos[0]+i<tam)
                        TableroAux[pos[0] + i, pos[1]] = 10;
                    if(pos[0]+i>aux2[0] && pos[0]+i<tam && TableroAux[pos[0] + i, pos[1]] !=10)
                        TableroAux[pos[0] + i, pos[1]] = ficha.Get_Codigo();
                }

                //vertical sup
                if (aux3[0] == -1)
                {
                    if (pos[0] - i >=0)
                        TableroAux[pos[0] - i, pos[1]] = 10;
                }
                else
                {
                    if(pos[0]-i >= aux3[0] && pos[0]-i>=0)
                        TableroAux[pos[0] - i, pos[1]] = 10;
                    if(pos[0] - i < aux3[0] && pos[0] - i >= 0 && TableroAux[pos[0] - i, pos[1]] != 10)
                        TableroAux[pos[0] - i, pos[1]] = ficha.Get_Codigo();
                }

                //horizontal izq
                if (aux4[0] == -1)
                {
                    if (pos[1] - i >= 0)
                        TableroAux[pos[0], pos[1] - i] = 10;
                }
                else
                { 
                    if(pos[1]-i>=aux4[1] && pos[1]-i>=0)
                        TableroAux[pos[0], pos[1] - i] = 10;
                    if (pos[1] - i < aux4[1] && pos[1] - i >= 0 && TableroAux[pos[0], pos[1] - i] != 10)
                        TableroAux[pos[0], pos[1] - i] = ficha.Get_Codigo();
                }

            }

            if (pos[0] + 2 < tam && pos[1] + 1 < tam)
            {
                if (TableroOriginal[pos[0] + 2, pos[1] + 1] != 0)
                {
                    TableroAux[pos[0] + 2, pos[1] + 1] = 10;
                    if (pos[1] + 2 < tam && TableroAux[pos[0] + 2, pos[1] + 2] != 10)
                        TableroAux[pos[0] + 2, pos[1] + 2] = ficha.Get_Codigo();
                }
                else
                    TableroAux[pos[0] + 2, pos[1] + 1] = 10;
            }
            if (pos[0] + 2 < tam && pos[1] - 1 >= 0)
            {   
                if(TableroOriginal[pos[0] + 2, pos[1] - 1] !=0 )
                {
                    TableroAux[pos[0] + 2, pos[1] - 1] = 10;
                    if (pos[1] - 2 >= 0 && TableroAux[pos[0] + 2, pos[1] - 2] != 10)
                        TableroAux[pos[0] + 2, pos[1] - 2] = ficha.Get_Codigo();
                }
                else 
                    TableroAux[pos[0] + 2, pos[1] - 1] = 10;
            }
            if (pos[0] - 2 >= 0 && pos[1] - 1 >= 0)
            {
                if (TableroOriginal[pos[0] - 2, pos[1] - 1] != 0)
                {
                    TableroAux[pos[0] - 2, pos[1] - 1] = 10;
                    if (pos[1] - 2 >= 0 && TableroAux[pos[0] - 2, pos[1] - 2] != 10)
                        TableroAux[pos[0] - 2, pos[1] - 2] = ficha.Get_Codigo();
                }
                else
                    TableroAux[pos[0] - 2, pos[1] - 1] = 10;
            }
            if (pos[0] - 2 >= 0 && pos[1] + 1 < tam)
            {
                if (TableroOriginal[pos[0] - 2, pos[1] + 1] != 0)
                {
                    TableroAux[pos[0] - 2, pos[1] + 1] = 10;
                    if (pos[1] + 2 < tam && TableroAux[pos[0] - 2, pos[1] + 2] != 10)
                        TableroAux[pos[0] - 2, pos[1] + 2] = ficha.Get_Codigo();
                }
                else
                    TableroAux[pos[0] - 2, pos[1] + 1] = 10;
            }
            if (pos[0] + 1 < tam && pos[1] + 2 < tam)
            {
                if (TableroOriginal[pos[0] + 1, pos[1] + 2] != 0)
                {
                    TableroAux[pos[0] + 1, pos[1] + 2] = 10;
                    if (pos[0] + 2 < tam && TableroAux[pos[0] + 2, pos[1] + 2] != 10)
                        TableroAux[pos[0] + 2, pos[1] + 2] = ficha.Get_Codigo();
                }
                else
                    TableroAux[pos[0] + 1, pos[1] + 2] = 10;
            }
            if (pos[0] + 1 < tam && pos[1] - 2 >= 0)
            {
                if (TableroOriginal[pos[0] + 1, pos[1] - 2] != 0)
                {
                    TableroAux[pos[0] + 1, pos[1] - 2] = 10;
                    if (pos[0] + 2 < tam && TableroAux[pos[0] + 2, pos[1] - 2] != 10)
                        TableroAux[pos[0] + 2, pos[1] - 2] = ficha.Get_Codigo();
                }
                else
                    TableroAux[pos[0] + 1, pos[1] - 2] = 10;
            }
            if (pos[0] - 1 >= 0 && pos[1] - 2 >= 0)
            {
                if (TableroOriginal[pos[0] - 1, pos[1] - 2] != 0)
                {
                    TableroAux[pos[0] - 1, pos[1] - 2] = 10;
                    if (pos[0] - 2 >= 0 && TableroAux[pos[0] - 2, pos[1] - 2] != 10)
                        TableroAux[pos[0] - 2, pos[1] - 2] = ficha.Get_Codigo();
                }
                else
                    TableroAux[pos[0] - 1, pos[1] - 2] = 10;
            }
            if (pos[0] - 1 >= 0 && pos[1] + 2 < tam)
            {
                if (TableroOriginal[pos[0] - 1, pos[1] + 2] != 0)
                {
                    TableroAux[pos[0] - 1, pos[1] + 2] = 10;
                    if (pos[0] - 2 >= 0 && TableroAux[pos[0] - 2, pos[1] + 2] != 10)
                        TableroAux[pos[0] - 2, pos[1] + 2] = ficha.Get_Codigo();
                }
                else
                    TableroAux[pos[0] - 1, pos[1] + 2] = 10;
            }
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

            TableroAux[pos[0], pos[1]] = 10;
            if (pos[0] + 1 < tam)
            {
                if (TableroOriginal[pos[0] + 1, pos[1]] != 0)
                {
                    TableroAux[pos[0] + 1, pos[1]] = 10;
                    if (pos[0] + 2 < tam && TableroAux[pos[0] + 2, pos[1]] != 10)
                        TableroAux[pos[0] + 2, pos[1]] = 2;
                }
                else
                    TableroAux[pos[0] + 1, pos[1]] = 10;
            }
            if (pos[0] - 1 >=0 )
            {
                if (TableroOriginal[pos[0] - 1, pos[1]] != 0)
                {
                    TableroAux[pos[0] - 1, pos[1]] = 10;
                    if (pos[0] - 2 >= 0 && TableroAux[pos[0] - 2, pos[1]] != 10)
                        TableroAux[pos[0] - 2, pos[1]] = 2;
                }
                else
                    TableroAux[pos[0] - 1, pos[1]] = 10;
            }
            if (pos[1] + 1 < tam)
            {
                if (TableroOriginal[pos[0], pos[1]+1] != 0)
                {
                    TableroAux[pos[0], pos[1]+1] = 10;
                    if (pos[1] + 2 < tam && TableroAux[pos[0], pos[1]+2] != 10)
                        TableroAux[pos[0], pos[1]+2] = 2;
                }
                else
                    TableroAux[pos[0], pos[1]+1] = 10;
            }
            if (pos[1] - 1 >=0)
            {
                if (TableroOriginal[pos[0], pos[1] - 1] != 0)
                {
                    TableroAux[pos[0], pos[1] - 1] = 10;
                    if (pos[1] - 2 >= 0 && TableroAux[pos[0], pos[1] - 2] != 10)
                        TableroAux[pos[0], pos[1] - 2] = 2;
                }
                else
                    TableroAux[pos[0], pos[1] -1] = 10;
            }
            if (pos[1] + 1 < tam && pos[0]+1<tam)
            {
                if (TableroOriginal[pos[0]+1, pos[1] + 1] != 0)
                {
                    TableroAux[pos[0]+1, pos[1] + 1] = 10;
                    if (pos[0] + 2 < tam && pos[1] + 2 < tam && TableroAux[pos[0]+2, pos[1] + 2] != 10 )
                        TableroAux[pos[0]+2, pos[1] + 2] = 2;
                }
                else
                    TableroAux[pos[0]+1, pos[1] + 1] = 10;
            }
            if (pos[1] - 1 >=0 && pos[0] - 1 >=0)
            {
                if (TableroOriginal[pos[0] - 1, pos[1] - 1] != 0)
                {
                    TableroAux[pos[0] - 1, pos[1] - 1] = 10;
                    if (pos[1] - 2 >= 0 && pos[0] - 2 >= 0 && TableroAux[pos[0] - 2, pos[1] - 2] != 10 )
                        TableroAux[pos[0] -2, pos[1] - 2] = 2;
                }
                else
                    TableroAux[pos[0] - 1, pos[1] - 1] = 10;
            }
            if (pos[1] - 1 >= 0 && pos[0] + 1 <tam)
            {
                if (TableroOriginal[pos[0] + 1, pos[1] - 1] != 0)
                {
                    TableroAux[pos[0] + 1, pos[1] - 1] = 10;
                    if (pos[1] - 2 >= 0 && pos[0] + 2 < tam && TableroAux[pos[0] + 2, pos[1] - 2] != 10 )
                        TableroAux[pos[0] + 2, pos[1] - 2] = 2;
                }
                else
                    TableroAux[pos[0] + 1, pos[1] - 1] = 10;
            }
            if (pos[1] + 1 <tam && pos[0] - 1 >= 0)
            {
                if (TableroOriginal[pos[0] - 1, pos[1] + 1] != 0)
                {
                    TableroAux[pos[0] - 1, pos[1] + 1] = 10;
                    if (pos[1] + 2 < tam && pos[0] - 2 >= 0 && TableroAux[pos[0] - 2, pos[1] + 2] != 10)
                        TableroAux[pos[0] - 2, pos[1] + 2] = 2;
                }
                else
                    TableroAux[pos[0] - 1, pos[1] + 1] = 10;
            }

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

            imprimir(TableroOriginal);
            imprimir(TableroAux);
        }

        public void CargarTablero()
        {

            //dejamos los alfiles fijos y las torre fija
            TableroOriginal[3, 3] = 3; //alfil A
            TableroOriginal[4, 3] = 4; //alfil B 
            TableroOriginal[7, 7] = 8; //torre B
            TableroOriginal[0, 0] = 7; //torre A -> esta torre la comenzamos a mover con la ficha comibinada

            TableroOriginal[4, 5] = 1; //ubicamos la reina en una poscion centrica

            
            var rand = new Random();
            int cont = 0;
            int pos_i = 0;
            int pos_j = 0;
            do {
                pos_i = rand.Next(2, 5);
                pos_j = rand.Next(2, 5);
                if (TableroOriginal[pos_i, pos_j] == 0)
                {
                    TableroOriginal[pos_i, pos_j] = 5;//caballo A
                    cont++;
                }
            } while (cont != 1);

            cont = 0;
            do
            {
                pos_i = rand.Next(2, 5);
                pos_j = rand.Next(2, 5);
                if (TableroOriginal[pos_i, pos_j] == 0)
                {
                    TableroOriginal[pos_i, pos_j] = 6;//caballo B
                    cont++;
                }
            } while (cont != 1);

            cont = 0;
            do
            {
                pos_i = rand.Next(2, 5);
                pos_j = rand.Next(2, 5);
                if (TableroOriginal[pos_i, pos_j] == 0)
                {
                    TableroOriginal[pos_i, pos_j] = 2; //rey
                    cont++;
                }
            } while (cont != 1);

        }


        public void imprimir(int[,] tablero)
        {
            string text = "\n";

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    text += tablero[i, j].ToString("00") + "|";
                }
                text += "\n";
            }
            Console.Write(text);
        }

        public bool CompararTableros(Tablero tablero)
        {
            //recorremos el tablero original
            for (int i = 0; i < tam; i++)
            {  
                for (int j = 0; j < tam; j++)
                {
                    if (tablero.Get_CodigoFichaOrg(i, j) != this.Get_CodigoFichaOrg(i, j))
                        return true; //si encontramos una posicion donde haya dos fichas distintas, retornamos true
                }
            
            }

            //en caso de que no se encuentre, retornamos false, las soluciones son iguales 
            return false; 
        }

        ~Tablero() {;}
    }
}

