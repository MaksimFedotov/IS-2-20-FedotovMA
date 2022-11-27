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
using MyClassLibrary;


namespace Task5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DBconnection db = new DBconnection("server=chuc.caseum.ru;port=33333;user=st_2_20_25;" +
               "database=is_2_20_st25_KURS;password=56496034;");


        MySqlConnection conn;

        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new MySqlConnection(db.GetConnectionString());

            ShowData();
        }

        public void ShowData()
        {
            dataGridView1.Rows.Clear();

            try
            {
                conn.Open();

                string sql = $"SELECT * FROM t_Uchebka_Fedotov;";
                MySqlCommand command = new MySqlCommand(sql, conn);

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int row = dataGridView1.Rows.Add();
                    dataGridView1.Rows[row].Cells[0].Value = reader[0].ToString();
                    dataGridView1.Rows[row].Cells[1].Value = reader[1].ToString();
                    dataGridView1.Rows[row].Cells[2].Value = DateParser.Parse(reader[2].ToString());
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
                textBox1.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 5)
            {
                try
                {
                    conn.Open();

                    string name = textBox1.Text;

                    string query = $"INSERT INTO t_Uchebka_Fedotov (fioStud) VALUES (\"{name}\");";
                    MySqlCommand command = new MySqlCommand(query, conn);

                    command.ExecuteNonQuery();

                   
                    

                } catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);

                } finally
                {
                    conn.Close();
                    ShowData();

                }
            }
        }
    }
}
