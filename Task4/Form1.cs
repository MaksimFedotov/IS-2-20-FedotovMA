using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MyClassLibrary;

namespace Task4
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                string sql = $"SELECT * FROM t_datatime;";
                MySqlCommand command = new MySqlCommand(sql, conn);

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int row = dataGridView1.Rows.Add();
                    dataGridView1.Rows[row].Cells[0].Value = reader[0].ToString();
                    dataGridView1.Rows[row].Cells[1].Value = reader[1].ToString();
                    dataGridView1.Rows[row].Cells[2].Value = reader[2].ToString();
                    dataGridView1.Rows[row].Cells[3].Value = reader[3].ToString();
                }
                reader.Close();

            }
            catch
            {
                MessageBox.Show("Ошибка при получении данных из таблицы!");
            }
            finally
            {
                conn.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIdx = e.RowIndex;
            string id = dataGridView1.Rows[rowIdx].Cells[0].Value.ToString();

            try
            {

                conn.Open();
                string sql = $"SELECT photo_url FROM t_datatime WHERE id = {id}";

                MySqlCommand command = new MySqlCommand(sql, conn);

                string url = command.ExecuteScalar().ToString();

                pictureBox1.ImageLocation = url;
                
            }
            catch
            {
                MessageBox.Show("Ошибка при получении данных!");

            }
            finally
            {
                conn.Close();
            }
        }
    }
}
