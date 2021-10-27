﻿using System;
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
            Ficha ficha_aux = new Ficha(" ", 0);
            int[] pos_org = CalcularPosicion(TableroOriginal);


            //MUEVO SOLO LA FICHA COMBINADA 
            if (Get_Codigo() == 9)
            {
                var Rand = new Random();
                int PosI = Rand.Next(7);
                int PosJ = Rand.Next(7);
                if (TableroOriginal.Get_CodigoFichaOrg(PosI, PosJ) == 0 && cont == 0)
                {
                    TableroOriginal.Set_CodigoFichaOrg(PosI, PosJ, this);
                    TableroOriginal.Set_CodigoFichaOrg(pos_org[0], pos_org[1], ficha_aux);
                    cont++;
                }
            }
            else
            {
                //Para todas las fichas (menos el alfil) no me importa donde la pongo
                if (Get_Codigo() != 3 && Get_Codigo() != 4)
                {
                    for (int i = 0; i < TableroOriginal.GetTam(); i++)
                    {
                        for (int j = 0; j < TableroOriginal.GetTam(); j++)
                        {
                            if (TableroOriginal.Get_CodigoFichaOrg(i, j) == 0 && cont == 0)
                            {
                                TableroOriginal.Set_CodigoFichaOrg(i, j, this);
                                TableroOriginal.Set_CodigoFichaOrg(pos_org[0], pos_org[1], ficha_aux);
                                cont++;
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < TableroOriginal.GetTam(); i++)
                    {
                        for (int j = 0; j < TableroOriginal.GetTam(); j++)
                        {
                            if (i < TableroOriginal.GetTam() && j < TableroOriginal.GetTam() && TableroOriginal.Get_CodigoFichaOrg(i + 2, j + 2) == 0 && cont == 0)
                            {
                                TableroOriginal.Set_CodigoFichaOrg(i + 2, j + 2, this);
                                TableroOriginal.Set_CodigoFichaOrg(pos_org[0], pos_org[1], ficha_aux);
                                cont++;
                            }
                            if (i > 0 && j > 0 && TableroOriginal.Get_CodigoFichaOrg(i - 1, j - 1) == 0 && cont == 0)
                            {
                                TableroOriginal.Set_CodigoFichaOrg(i - 1, j - 1, this);
                                TableroOriginal.Set_CodigoFichaOrg(pos_org[0], pos_org[1], ficha_aux);
                                cont++;
                            }
                        }
                    }
                }
            }
            
        }

        ~Ficha() {;}
    };
  
}

