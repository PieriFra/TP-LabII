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
        public int [] CalcularPosicion(Ficha ficha, Tablero TableroOriginal) 
        {
            int[] Posicion= new int [0]; //ver que numero va en el [1]
            for (int i=0; i<TableroOriginal.GetTam();  i++) 
            {
                for (int j = 0; j< TableroOriginal.GetTam(); j++)
                {
                    if (TableroOriginal.Get_CodigoFichaOrg(i,j) == ficha.Codigo)
                    {
                        Posicion[0] = i;
                        Posicion[1] = j;
                    }
                    return  Posicion;
                }
            }
            return Posicion;
        }

        //Mueve una ficha
        public void CalcularMovimiento(Ficha ficha, Tablero TableroOriginal)
        {
            int cont = 0;
            //Para todas las fichas (menos el alfil) no me importa donde la pongo
            if (ficha.Get_Codigo() != 3 && ficha.Get_Codigo() != 4)
            {
                for (int i = 0; i < TableroOriginal.GetTam(); i++)
                {
                    for (int j = 0; j < TableroOriginal.GetTam(); j++)
                    {
                        if (TableroOriginal.Get_CodigoFichaOrg(i, j) == 0)
                        {
                            TableroOriginal.Set_CodigoFichaOrg(i, j, ficha);
                            cont++;
                        }
                    }
                }
            }
            else
            {//VER SI ESTA BIEN PENSADO
                for (int i = 0; i < TableroOriginal.GetTam(); i++)
                {
                    for (int j = 0; j < TableroOriginal.GetTam(); j++)
                    {
                        if (i < TableroOriginal.GetTam() && j < TableroOriginal.GetTam() && TableroOriginal.Get_CodigoFichaOrg(i + 2, j + 2) == 0)
                        {
                            Ficha aux = new Ficha("Alfil", 3);
                            TableroOriginal.Set_CodigoFichaOrg(i + 2, j + 2, aux);
                            cont++;
                        }
                        if (i > 0 && j > 0 && TableroOriginal.Get_CodigoFichaOrg(i - 1, j - 1) == 0)
                        {
                            Ficha aux = new Ficha("Alfil", 4);
                            TableroOriginal.Set_CodigoFichaOrg(i - 1, j - 1, aux);
                            cont++;
                        }
                    }

                }
            }
            //MUEVO SOLO LA FICHA COMBINADA 
            cont = 0;
            for (int i = 0; i < TableroOriginal.GetTam(); i++)
            {
                for (int j = 0; j < TableroOriginal.GetTam(); j++)
                {
                    if (TableroOriginal.Get_CodigoFichaOrg(i, j) == 6 || TableroOriginal.Get_CodigoFichaOrg(i, j) == 7)
                    {
                        //TENGO QUE ELIMINAR LAS FICHAS 6 Y 7 DEL TABLERO ORIGINAL, PONGO EN 0 TODO
                        TableroOriginal.Get_FichaPosicion(i, j).SetNombre(" ");
                        TableroOriginal.Get_FichaPosicion(i, j).SetCodigo(0);
                        cont++;
                    }
                    if (TableroOriginal.Get_CodigoFichaOrg(i, j) == 0 && cont != 0)
                    {
                        Ficha aux = new Ficha("TorreCaballo", 9);
                        TableroOriginal.Set_CodigoFichaOrg(i, j, aux);
                    }
                }
            }
           
        } 

        ~Ficha() {;}
    };
  
}

