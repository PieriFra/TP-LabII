﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_Lab_II
{
    public partial class Form2 : Form
    {
       
       Form1 llamado;
       Form3 Llamado;
       //List<Tablero> Tableros;
        

        public Form2(Form3 llamado_)
        {
            InitializeComponent();
            Llamado = llamado_;
        }
        public Form2(Form1 llamado_ ) 
        {
            InitializeComponent();
            llamado = llamado_;
            //Tableros = ListaResul;
            /*int N = (UInt16)Btn_NResultados.Value;
            for (int i=0; i<N; i++)
            {
                
                listBox1.Items.Add("Solucion "to_string.Btn_NResultados) ;
             
            }
            
            listBox1.SelectionMode = SelectionMode.MultiSimple;*/
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(llamado);
            form3.Show();
            this.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListViewGroup Resultados = new ListViewGroup("Resultados con 8 fichas: ", HorizontalAlignment.Center);
            
            /*for (int i = 0; i < Tableros.Count; i++)
            {
                listView1.Items.Add(new ListViewItem("i", Resultados));
            }*/

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
