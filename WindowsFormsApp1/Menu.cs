using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        Task1.Form1 task1;
        Task2.Form1 task2;
        Task3.Form1 task3;
        Task4.Form1 task4;
        Task5.Form1 task5;

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            task1 = new Task1.Form1();
            task1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            task2 = new Task2.Form1();
            task2.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            task3 = new Task3.Form1();
            task3.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            task4 = new Task4.Form1();
            task4.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            task5 = new Task5.Form1();
            task5.ShowDialog();
        }
    }
}
