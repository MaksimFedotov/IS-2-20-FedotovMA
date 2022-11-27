using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;

namespace Task3
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                string sql = $"SELECT product.id, product.name, user.email, rating.rate FROM rating INNER JOIN user ON rating.user_id = user.id INNER JOIN product ON rating.product_id = product.id;";
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

            } catch 
            {
                MessageBox.Show("Ошибка при получении данных из сводной таблицы!");
            } finally
            {
                conn.Close();
            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIdx = e.RowIndex;
            string productId = dataGridView1.Rows[rowIdx].Cells[0].Value.ToString();
            
            try
            {

                conn.Open();
                string sql = $"SELECT product.name as product_name,  user.email as user_email, category.name as category_name, brand.name as brand_name, rating.rate as product_user_rate, product.price as product_price, product.in_stock as product_quantity from rating INNER JOIN product ON rating.product_id = product.id INNER JOIN user ON rating.user_id = user.id INNER JOIN category ON product.category_id = category.id INNER JOIN brand ON product.brand_id = brand.id WHERE product.id = {productId};";

                MySqlCommand command = new MySqlCommand(sql, conn);

                MySqlDataReader reader = command.ExecuteReader();

                string info = "";

                while (reader.Read())
                {
                    info += $"Название продукта: {reader[0].ToString()}\n";
                    info += $"Емайл пользователя, оценившего продукт: {reader[1].ToString()}\n";
                    info += $"Категория продукта: {reader[2].ToString()}\n";
                    info += $"Производитель: {reader[3].ToString()}\n";
                    info += $"Оцена пользователя: {reader[4].ToString()}\n";
                    info += $"Цена продукта: {reader[5].ToString()}\n";
                    info += $"Количество на складе: {reader[6].ToString()}\n";
                }
                reader.Close();
                MessageBox.Show(info);
            }
            catch
            {
                MessageBox.Show("Ошибка при получении данных о продукте!");
                
            }
            finally
            {
                conn.Close();
            }


        }
    }
}
