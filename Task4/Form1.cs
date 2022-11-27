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
using static System.Net.Mime.MediaTypeNames;

namespace Task4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string GetMonth(string month)
        {
            
            switch(month)
            {
                case "01":
                    return "Января";
                case "02":
                    return "Февраля";
                case "03":
                    return "Марта";
                case "04":
                    return "Апреля";
                case "05":
                    return "Мая";
                case "06":
                    return "Июня";
                case "07":
                    return "Июля";
                case "08":
                    return "Августа";
                case "09":
                    return "Сентября";
                case "10":
                    return "Октября";
                case "11":
                    return "Ноября";
                case "12":
                    return "Декабря";
                default: throw new Exception("Неверный формат месяца!");

            }
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


                    string str = reader[2].ToString().Substring(0, 10);
                    string[] dateParts = str.Split('.');


                    string day = dateParts[0];
                    string month = GetMonth(dateParts[1]);
                    string year = dateParts[2];


                    dataGridView1.Rows[row].Cells[2].Value = $"{day} {month} {year} г.";
                    dataGridView1.Rows[row].Cells[3].Value = reader[3].ToString();
                }
                reader.Close();

            }
            catch(Exception ex)
            {
                throw ex;
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
