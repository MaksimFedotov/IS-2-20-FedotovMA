using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Task2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class DBconnection
        {
            protected string _connectString;
           

            public DBconnection(string connectString)
            {
                this._connectString = connectString;

            }

            public string GetConnectionString()
            {
                return this._connectString;
            }
        }

        DBconnection db = new DBconnection("server=chuc.caseum.ru;port=33333;user=uchebka;" +
                "database=uchebka;password=uchebka;");

        MySqlConnection conn;

        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new MySqlConnection(db.GetConnectionString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                MessageBox.Show("Соединение работает отлично!");

            }
            catch
            {
                MessageBox.Show("Ошибка при открытии соединения!");

            }
            finally
            {
                MessageBox.Show("Хорошего дня в любом случае!");
                conn.Close();
            }
        }

       
    }
}
