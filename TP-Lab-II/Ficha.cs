using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 
namespace TP_Lab_II
{
    public 
    class Ficha
    {
        //Atributos
        public string Nombre;
        public int Codigo;

        //Metodos
        public Ficha() { Nombre = " "; Codigo = 0; } 
        public Ficha(string Nombre_, int Codigo_) { Nombre = Nombre_; Codigo = Codigo_; }

        //Devuelve la posición (i,j) de la ficha 
        public int [] CalcularPosicion(Tablero TableroOriginal) 
        {
            int[] Posicion=new int [2]; //ver que numero va en el [1]
            for (int i=0; i<TableroOriginal.tam;  i++) 
            {
                for (int j = 0; j< TableroOriginal.tam; j++)
                {
                    if (TableroOriginal.TableroOriginal[i,j] == Codigo)
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

        public void CalcularMovimiento(Tablero TableroOriginal)
        {
            int cont = 0;
            int[] pos = new int[2];
            Ficha ficha_aux = new Ficha(" ", 0); //ficha aux para colocar la antigua poscion en 0
            int[] pos_org = CalcularPosicion(TableroOriginal); //poscion actual de la ficha
            var Rand = new Random();

            //caso del rey
            if (this.Codigo == 2) //movemos el rey
            {
                TableroOriginal.TableroOriginal[pos_org[0], pos_org[1]] =ficha_aux.Codigo; //ponemos en 0 la posicion que ocupa
                Rand = new Random();
                do
                {
                    //generamos una pos aleatoria dentro de los limites del tablero
                    int PosI = Rand.Next(2, 6);
                    int PosJ = Rand.Next(2, 6);
                    //preguntamos si la poscion esta libre 
                    if (TableroOriginal.TableroOriginal[PosI, PosJ] == 0)
                    {
                        //si esta libre, ponemos la ficha en la nueva pos
                        TableroOriginal.TableroOriginal[PosI, PosJ] =this.Codigo;
                        cont++; //contamos un cambio
                    }

                } while (cont == 0);
            }

            //caso reina
            if (this.Codigo == 1) 
            {
                cont = 0;
                Rand = new Random();
                TableroOriginal.TableroOriginal[pos_org[0], pos_org[1]] =ficha_aux.Codigo; //ponemos en 0 la posicion que ocupa
                do
                {
                    //generamos una pos aleatoria dentro de los limites del tablero
                    int PosI = Rand.Next(3, 5);
                    int PosJ = Rand.Next(3, 5);
                    //preguntamos si la poscion esta libre 
                    if (TableroOriginal.TableroOriginal[PosI, PosJ] == 0)
                    {
                        //si esta libre, ponemos la ficha en la nueva pos
                        TableroOriginal.TableroOriginal[PosI, PosJ] =this.Codigo;
                        cont++; //contamos un cambio
                    }

                } while (cont == 0);
            }

            // caso del caballo A y caballo B
            if (this.Codigo == 5 || this.Codigo == 6)
            {
               
                cont = 0;
                TableroOriginal.TableroOriginal[pos_org[0], pos_org[1]]= ficha_aux.Codigo; //ponemos en 0 la posicion que ocupa
                Rand = new Random();
                do
                {
                    //generamos una pos aleatoria dentro de los limites establecidos
                    int Pos_I = Rand.Next(1, 7);
                    int Pos_J = Rand.Next(1, 7);

                    //preguntamos si la poscion esta libre 
                    if (TableroOriginal.TableroOriginal[Pos_I, Pos_J] == 0)
                    {
                        //si esta libre, ponemos la ficha en la nueva pos
                        TableroOriginal.TableroOriginal[Pos_I, Pos_J] = this.Codigo;
                        cont++; //contamos un cambio
                    }

                } while (cont == 0);

            }

            //alfil A - casilla blanca
            if (this.Codigo == 3)
            {
                cont = 0;
                TableroOriginal.TableroOriginal[pos_org[0], pos_org[1]]= ficha_aux.Codigo; //ponemos en 0 la posicion que ocupa
                Rand = new Random();
                do
                {
                    //generamos una pos aleatoria dentro de los limites establecidos
                    int Pos_I = Rand.Next(2, 6);
                    int Pos_J = Rand.Next(2, 6);

                    //preguntamos si la poscion esta libre 
                    if (TableroOriginal.TableroOriginal[Pos_I, Pos_J] == 0)
                    {
                        if (Pos_I % 2 == 0 && Pos_J % 2 != 0)
                        {
                            //si esta libre, ponemos la ficha en la nueva pos
                            TableroOriginal.TableroOriginal[Pos_I, Pos_J]= this.Codigo;
                            cont++; //contamos un cambio
                        }
                        if (Pos_I % 2 != 0 && Pos_J % 2 == 0)
                        {  
                            //si esta libre, ponemos la ficha en la nueva pos
                            TableroOriginal.TableroOriginal[Pos_I, Pos_J]= this.Codigo;
                            cont++; //contamos un cambio
                        }
                    }
                } while (cont == 0);
            }

            //alfil B - casilla negra
            if (this.Codigo == 4)
            {
                cont = 0;
                TableroOriginal.TableroOriginal[pos_org[0], pos_org[1]] =ficha_aux.Codigo; //ponemos en 0 la posicion que ocupa
                Rand = new Random();
                do
                {
                    //generamos una pos aleatoria dentro de los limites establecidos
                    int Pos_I = Rand.Next(3, 5);
                    int Pos_J = Rand.Next(3, 5);

                    //preguntamos si la poscion esta libre 
                    if (TableroOriginal.TableroOriginal[Pos_I, Pos_J] == 0)
                    {
                        if (Pos_I % 2 == 0 && Pos_J % 2 == 0)
                        {
                            //si esta libre, ponemos la ficha en la nueva pos
                            TableroOriginal.TableroOriginal[Pos_I, Pos_J] =this.Codigo;
                            cont++; //contamos un cambio
                        }
                        if (Pos_I % 2 != 0 && Pos_J % 2 != 0)
                        {
                            //si esta libre, ponemos la ficha en la nueva pos
                            TableroOriginal.TableroOriginal[Pos_I, Pos_J]= this.Codigo;
                            cont++; //contamos un cambio
                        }
                    }

                } while (cont == 0);

            }

            //caso TorreCaballo
            if (this.Codigo == 9)
            {
                cont = 0;
                TableroOriginal.TableroOriginal[pos_org[0], pos_org[1]] =ficha_aux.Codigo; //ponemos en 0 la posicion que ocupa
                Rand = new Random();
                do
                {
                    //generamos una pos aleatoria dentro de los limites establecidos
                    int Pos_I = Rand.Next(0, 7);
                    int Pos_J = Rand.Next(0, 7);

                    //preguntamos si la poscion esta libre 
                    if (TableroOriginal.TableroOriginal[Pos_I, Pos_J] == 0)
                    {
                        //si esta libre, ponemos la ficha en la nueva pos
                        TableroOriginal.TableroOriginal[Pos_I, Pos_J]= this.Codigo;
                        cont++; //contamos un cambio
                    }

                } while (cont == 0);
            }
        }
        ~Ficha() {;}
    };
  
}

