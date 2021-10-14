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
        public Ficha() { Nombre = " "; Codigo = 0; } //por las dudas
        public Ficha(string Nombre_, int Codigo_) { Nombre = Nombre_; Codigo = Codigo_; }
        public string Get_Nombre() { return Nombre; }
        public int Get_Codigo() { return Codigo; }
        public void SetCodigo(int codigo) { Codigo=codigo; }
        public int [] CalcularPosicion(Ficha ficha, Tablero TableroOriginal) 
        {
            int[] Posicion= new int [0]; //Ver si lo dejamos como vector o matriz
            for (int i=0; i<TableroOriginal.GetTam();  i++) 
            {
                for (int j = 0; j< TableroOriginal.GetTam(); j++)
                {
                    if (TableroOriginal.GetPosFichaOrg(i,j) == ficha.Codigo)
                    {
                        Posicion[0] = i;
                        Posicion[1] = j;
                    }
                    return  Posicion;
                }
            }
            return Posicion;
            }


        //Realiza el movimiento que le indicamos
        public void CalcularMovimiento(Ficha ficha, Tablero TableroOriginal)
        
        {
            int cont = 0;
            do
            {
                //Para todas las fichas (menos el alfil) no me importa donde la pongo
                if (ficha.Get_Codigo() != 3 && ficha.Get_Codigo() != 4)
                {
                    for (int i = 0; i < TableroOriginal.GetTam(); i++)
                    {
                        for (int j = 0; j < TableroOriginal.GetTam(); j++)
                        {
                            if (TableroOriginal.GetPosFichaOrg(i, j) != 0)
                            {
                                TableroOriginal.SetPosFichaOrg(ficha);
                                cont++;
                            }
                        }
                    }
                }
                else
                {
                    var rand = new Random();
                    int movimiento = rand.Next(4);
                        /*Si Movimiento=1
Si i<n && j<n && tableroOriginal[i+2,j+2]=0 
                  tableroOriginal[i+2, j+2]=3
Cont_movimiento++
                  tableroOriginal[i, j]=0
                  Fin si
           	Fin si*/
                    for (int i = 0; i < TableroOriginal.GetTam(); i++)
                    {
                        for (int j = 0; j < TableroOriginal.GetTam(); j++)
                        {
                            if (movimiento == 0)
                            {
                                if (i < TableroOriginal.GetTam() && j < TableroOriginal.GetTam() && TableroOriginal.GetPosFichaOrg(i + 2, j + 2) == 0)
                                {
                                    Ficha aux=new Ficha();
                                    TableroOriginal.SetPosFichaOrg(i + 2, j + 2);
                            }
                        }
                        
                    }
                }
            } while (cont > 10);

        } 

        ~Ficha() {;}
    };
  
}

