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
       List<Tablero> Tableros= null;
        

     
        public Form2(Form3 llamado_)
        {
            InitializeComponent();
            Llamado = llamado_;
        }
        public Form2(Form1 llamado_, List<Tablero> ListaResul) 
        {
            InitializeComponent();
            llamado = llamado_;
            Tableros = ListaResul;
            
            for (int i = 1; i < Tableros.Count + 1; i++)
            {
                listBox1.Items.Add("Solucion: " + Convert.ToString(i));
            }
         
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
          
        }

        private void label1_Click(object sender, EventArgs e)
        {


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Btn_NResultados_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
