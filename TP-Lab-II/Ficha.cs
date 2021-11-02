using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 
namespace TP_Lab_II
{
    class Ficha
    {
        //Atributos
        public string Nombre;
        public int Codigo;

        //Metodos
        public Ficha() { Nombre = " "; Codigo = 0; } 
        public Ficha(string Nombre_, int Codigo_) { Nombre = Nombre_; Codigo = Codigo_; }
        public string Get_Nombre() { return Nombre; }
        public int Get_Codigo() { return Codigo; }
        public void SetCodigo(int codigo) { Codigo=codigo; }
        public void SetNombre(string nombre) { Nombre=nombre; }

        //Devuelve la posición (i,j) de la ficha 
        public int [] CalcularPosicion(Tablero TableroOriginal) 
        {
            int[] Posicion=new int [2]; //ver que numero va en el [1]
            for (int i=0; i<TableroOriginal.GetTam();  i++) 
            {
                for (int j = 0; j< TableroOriginal.GetTam(); j++)
                {
                    if (TableroOriginal.Get_CodigoFichaOrg(i,j) == Codigo)
                    {
                        Posicion[0] = i;
                        Posicion[1] = j;

                        return Posicion;
                    }                   
                }
            }
            Posicion[0] = -1;
            Posicion[1] = -1;
            return Posicion;
        }

        //Mueve una ficha
        public void CalcularMovimiento(Tablero TableroOriginal)
        {
            int cont = 0;
            int[] pos= {};
            Ficha ficha_aux = new Ficha(" ", 0); //ficha aux para colocar la antigua poscion en 0
            int[] pos_org = CalcularPosicion(TableroOriginal); //poscion actual de la ficha
            var Rand = new Random();

            for (int i = 0; i < TableroOriginal.GetTam(); i++)
            {
                for (int j = 0; j < TableroOriginal.GetTam(); j++)
                {
                    if (TableroOriginal.TableroAux[i, j] == 0)
                    {
                        pos[0] = i;
                        pos[1] = j;
                    }
                }
            }

            //caso del rey
            if (Get_Codigo() == 2) //movemos el rey
            {
                if (TableroOriginal.Get_CodigoFichaOrg(pos[0], pos[1]) == 0)
                {
                    //si esta libre, ponemos la ficha en la nueva pos
                    TableroOriginal.Set_CodigoFichaOrg(pos[0],pos[1], this);
                    TableroOriginal.Set_CodigoFichaOrg(pos_org[0], pos_org[1], ficha_aux); //ponemos en 0 la posicion que ocupaba antes
                }
                else
                {
                    do
                    {
                        //generamos una pos aleatoria dentro de los limites del tablero
                        int PosI = Rand.Next(1, 5);
                        int PosJ = Rand.Next(1, 5);
                        //preguntamos si la poscion esta libre 
                        if (TableroOriginal.Get_CodigoFichaOrg(PosI, PosJ) == 0)
                        {
                            //si esta libre, ponemos la ficha en la nueva pos
                            TableroOriginal.Set_CodigoFichaOrg(PosI, PosJ, this);
                            TableroOriginal.Set_CodigoFichaOrg(pos_org[0], pos_org[1], ficha_aux); //ponemos en 0 la posicion que ocupaba antes
                            cont++; //contamos un cambio
                        }

                    } while (cont == 0);

                } 

            }

            //caso de la reina->limitamos sus movimientos entre 2<x<4 & 2<y<4
            if (Get_Codigo() == 1)
            {

                cont = 0;
                do
                {
                    //generamos una pos aleatoria dentro de los limites establecidos
                    int Pos_I = Rand.Next(2, 5);
                    int Pos_J = Rand.Next(2, 5);

                    //preguntamos si la poscion esta libre 
                    if (TableroOriginal.Get_CodigoFichaOrg(Pos_I, Pos_J) == 0)
                    {
                        //si esta libre, ponemos la ficha en la nueva pos
                        TableroOriginal.Set_CodigoFichaOrg(Pos_I, Pos_J, this);
                        TableroOriginal.Set_CodigoFichaOrg(pos_org[0], pos_org[1], ficha_aux); //ponemos en 0 la posicion que ocupaba antes
                        cont++; //contamos un cambio
                    }

                } while (cont == 0);
            }

            // caso del caballo A
            if (Get_Codigo() == 5 || Get_Codigo() == 6)
            {
                cont = 0;
                do
                {
                    //generamos una pos aleatoria dentro de los limites establecidos
                    int Pos_I = Rand.Next(2, 5);
                    int Pos_J = Rand.Next(2, 5);

                    //preguntamos si la poscion esta libre 
                    if (TableroOriginal.Get_CodigoFichaOrg(Pos_I, Pos_J) == 0)
                    {
                        //si esta libre, ponemos la ficha en la nueva pos
                        TableroOriginal.Set_CodigoFichaOrg(Pos_I, Pos_J, this);
                        TableroOriginal.Set_CodigoFichaOrg(pos_org[0], pos_org[1], ficha_aux); //ponemos en 0 la posicion que ocupaba antes
                        cont++; //contamos un cambio
                    }

                } while (cont == 0);

            }

            //caso TorreCaballo
            if (Get_Codigo() == 9)
            {
                cont = 0;
                do
                {
                    //generamos una pos aleatoria dentro de los limites establecidos
                    int Pos_I = Rand.Next(0, 6);
                    int Pos_J = Rand.Next(0, 6);

                    //preguntamos si la poscion esta libre 
                    if (TableroOriginal.Get_CodigoFichaOrg(Pos_I, Pos_J) == 0)
                    {
                        //si esta libre, ponemos la ficha en la nueva pos
                        TableroOriginal.Set_CodigoFichaOrg(Pos_I, Pos_J, this);
                        TableroOriginal.Set_CodigoFichaOrg(pos_org[0], pos_org[1], ficha_aux); //ponemos en 0 la posicion que ocupaba antes
                        cont++; //contamos un cambio
                    }

                } while (cont == 0);
            }
        }

        /*public void CalcularMovimiento(Tablero TableroOriginal)
        {
            int cont = 0;
            Ficha ficha_aux = new Ficha(" ", 0); //ficha aux para colocar la antigua poscion en 0
            int[] pos_org = CalcularPosicion(TableroOriginal); //poscion actual de la ficha
            var Rand = new Random();

            //si la ficha esta en el tablero y ademas no es un alfil ni una torre ni la reina:
            //if (Get_Codigo() != 3 && Get_Codigo() != 4 && pos_org[0] != -1 && Get_Codigo() !=7 && Get_Codigo() != 8 && Get_Codigo() != 1)

            //caso del rey
            if (Get_Codigo() == 2) //movemos el rey
            {
                do
                {
                    //generamos una pos aleatoria dentro de los limites del tablero
                    int PosI = Rand.Next(1, 6);
                    int PosJ = Rand.Next(1, 6);

                    //preguntamos si la poscion esta libre 
                    if (TableroOriginal.Get_CodigoFichaOrg(PosI, PosJ) == 0)
                    {
                        //si esta libre, ponemos la ficha en la nueva pos
                        TableroOriginal.Set_CodigoFichaOrg(PosI, PosJ, this);
                        TableroOriginal.Set_CodigoFichaOrg(pos_org[0], pos_org[1], ficha_aux); //ponemos en 0 la posicion que ocupaba antes
                        cont++; //contamos un cambio
                    }

                } while (cont == 0);

            }

            //caso de un alfil->tiene que respetar sus diagonales
            if (Get_Codigo() == 3 || Get_Codigo() == 4)
            {
                //diagonal derch decendente
                //preguntamos si el movimiento esta dentro de los limites de la matriz y si no se hizo otro movimiento
                if (pos_org[0] + 3 < TableroOriginal.GetTam() && pos_org[1] + 3 < TableroOriginal.GetTam() && cont == 0)
                {
                    //preguntamos si la poscion esta libre
                    if (TableroOriginal.Get_CodigoFichaOrg(pos_org[0] + 3, pos_org[1] + 3) == 0)
                    {
                        TableroOriginal.Set_CodigoFichaOrg(pos_org[0] + 3, pos_org[1] + 3, this);
                        TableroOriginal.Set_CodigoFichaOrg(pos_org[0], pos_org[1], ficha_aux); //ponemos en 0 la posicion que ocupaba antes
                        cont++; //contamos un cambio
                    }

                }

                //diagonal izq acendente 
                //preguntamos si el movimiento esta dentro de los limites de la matriz y si no se hizo otro movimiento
                if (pos_org[0] - 3 >= 0 && pos_org[1] - 3 >= 0 && cont == 0)
                {
                    //preguntamos si la poscion esta libre
                    if (TableroOriginal.Get_CodigoFichaOrg(pos_org[0] - 3, pos_org[1] - 3) == 0)
                    {
                        TableroOriginal.Set_CodigoFichaOrg(pos_org[0] - 3, pos_org[1] - 3, this);
                        TableroOriginal.Set_CodigoFichaOrg(pos_org[0], pos_org[1], ficha_aux); //ponemos en 0 la posicion que ocupaba antes
                        cont++; //contamos un cambio
                    }

                }


            }

            //caso de la reina->limitamos sus movimientos entre 2<x<4 & 2<y<4
            if (Get_Codigo() == 1)
            {

                cont = 0;
                do
                {
                    //generamos una pos aleatoria dentro de los limites establecidos
                    int Pos_I = Rand.Next(2, 4);
                    int Pos_J = Rand.Next(2, 4);

                    //preguntamos si la poscion esta libre 
                    if (TableroOriginal.Get_CodigoFichaOrg(Pos_I, Pos_J) == 0)
                    {
                        //si esta libre, ponemos la ficha en la nueva pos
                        TableroOriginal.Set_CodigoFichaOrg(Pos_I, Pos_J, this);
                        TableroOriginal.Set_CodigoFichaOrg(pos_org[0], pos_org[1], ficha_aux); //ponemos en 0 la posicion que ocupaba antes
                        cont++; //contamos un cambio
                    }

                } while (cont == 0);


            }

            //caso del caballo A
            if (Get_Codigo() == 5 || Get_Codigo() == 6)
            {
                cont = 0;
                do
                {
                    //generamos una pos aleatoria dentro de los limites establecidos
                    int Pos_I = Rand.Next(2, 5);
                    int Pos_J = Rand.Next(2, 5);

                    //preguntamos si la poscion esta libre 
                    if (TableroOriginal.Get_CodigoFichaOrg(Pos_I, Pos_J) == 0)
                    {
                        //si esta libre, ponemos la ficha en la nueva pos
                        TableroOriginal.Set_CodigoFichaOrg(Pos_I, Pos_J, this);
                        TableroOriginal.Set_CodigoFichaOrg(pos_org[0], pos_org[1], ficha_aux); //ponemos en 0 la posicion que ocupaba antes
                        cont++; //contamos un cambio
                    }

                } while (cont == 0);

            }
        }*/

        ~Ficha() {;}
    };
  
}

