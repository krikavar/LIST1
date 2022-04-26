using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LIST1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<int> radek = new List<int>();
        Random rng = new Random();

        private void button1_Click(object sender, EventArgs e)
        {
            int cislo = int.Parse(textBox1.Text);
            
            //random
            for (int i = 0; i < int.Parse(textBox1.Text); i++)
            {
                int nahoda = rng.Next(19, 31);
                radek.Add(nahoda);
            }

            //prvocislo
            bool Prvocislo(int c2)
            {
                int delitelu = 0;
                for (int i = 1; i <= c2; i++)
                {
                    if (c2 % i == 0)
                    {
                        delitelu++; 
                    }
                }
                if (delitelu <= 2) 
                { 
                    return true;
                }
                else 
                { 
                    return false; 
                }
            }

           
            bool first = true;
            foreach (int c3 in radek)
            {
                listBox1.Items.Add(c3.ToString());
                if (first == true)
                {
                    if (Prvocislo(c3))
                    {
                        first = false;
                        MessageBox.Show("Prvocislo: " + c3);
                    }
                }
            }

            //metoda
            void metoda(List<int> list, ListBox listBox)
            {
                listBox1.Items.Clear();
                foreach (int c in list)
                {
                    listBox.Items.Add(c.ToString());
                }
            }

            MessageBox.Show("Prvni pozice max cisla v listu: " + radek.IndexOf(radek.Max()));
            MessageBox.Show("Posledni pozice max cisla v listu: " + radek.LastIndexOf(radek.Max()));
            MessageBox.Show("Prumer: " + radek.Average().ToString());
            metoda(radek, listBox1);

            List<int> neduplicita = radek.Distinct().ToList();
            metoda(neduplicita, listBox2);
        }
    }
}
