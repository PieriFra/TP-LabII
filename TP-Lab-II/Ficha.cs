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
        protected Ficha() { Nombre = " "; Codigo = 0; } //Verificar que tenga fichas distintas a estos numeros
        protected Ficha(string Nombre_, int Codigo_) { Nombre = Nombre_; Codigo = Codigo_; }
        protected string Get_Nombre() { return Nombre; }
        protected int Get_Codigo() { return Codigo; }
        protected int [] CalcularPosicion(Ficha ficha, Tablero TableroOriginal) 
        {
            int[] Posicion= new int [0]; //Ver si lo dejamos como vector o matriz
            for (int i=0; i<TableroOriginal.GetTam();  i++) //Ver que en la clase Tablero este el metodo TableroOriginal.GetTam()
            {
                for (int j = 0; j< TableroOriginal.GetTam(); j++)
                {
                    if (TableroOriginal[i, j] = ficha)
                    {
                        Posicion[0] = i;
                        Posicion[1] = j;
                    }
                        return  Posicion;
                }
            }
        ; }

        protected int CalcularMovimiento(Ficha ficha, Tablero TableroOriginal)
        {
            int cont = 0;
            int movimiento;
            int[] Posicion;
            switch (ficha.Get_Codigo())
            {
                case 1:
                    Posicion = CalcularPosicion(ficha, TableroOriginal);
                    do
                    {
                        movimiento = Random; //ver como se hace


 
                    } while (cont != 0);
                    break;

                case 2:
                    Posicion = CalcularPosicion(ficha, TableroOriginal);
                    do
                    {
                        movimiento = Random; //ver como se hace



                    } while (cont != 0);
                    break;

                case 3:
                    Posicion = CalcularPosicion(ficha, TableroOriginal);
                    do
                    {
                        movimiento = Random; //ver como se hace



                    } while (cont != 0);
                    break;

                case 4:
                    Posicion = CalcularPosicion(ficha, TableroOriginal);
                    do
                    {
                        movimiento = Random; //ver como se hace



                    } while (cont != 0);
                    break;

                case 5:
                    Posicion = CalcularPosicion(ficha, TableroOriginal);
                    do
                    {
                        movimiento = Random; //ver como se hace



                    } while (cont != 0);
                    break;

                case 6:
                    Posicion = CalcularPosicion(ficha, TableroOriginal);
                    do
                    {
                        movimiento = Random; //ver como se hace



                    } while (cont != 0);
                    break;

                case 7:
                    Posicion = CalcularPosicion(ficha, TableroOriginal);
                    do
                    {
                        movimiento = Random; //ver como se hace



                    } while (cont != 0);
                    break;

                case 8:
                    Posicion = CalcularPosicion(ficha, TableroOriginal);
                    do
                    {
                        movimiento = Random; //ver como se hace



                    } while (cont != 0);
                    break;

                case 9:
                    Posicion = CalcularPosicion(ficha, TableroOriginal);
                    do
                    {
                        movimiento = Random; //ver como se hace



                    } while (cont != 0);
                    break;
            }
            return 0;
        } //ver que cambiamos 

        ~Ficha() {; }
    };
  
}

