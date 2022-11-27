using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public abstract class Device<T>
        {
            public double price;
            public int releaseYear;
            public T article;
            public delegate void InfoHandler(string message);
            public event InfoHandler Notify;

            public Device(double price, int releaseYear, T article)
            {
                this.price = price;
                this.releaseYear = releaseYear;
                this.article = article;
            }

            public abstract void Display();
        }

        public class HardDisk : Device<string>
        {
            protected int turns;
            protected string interfaceType;
            protected int size;

            new public event InfoHandler Notify;

            public int Turns { get { return turns; } set { turns = value; } }
            public string InterfaceType { get { return interfaceType; } set { interfaceType = value; } }

            public int Size { get { return size; } set { size = value; } }

            public HardDisk(double price, int year, string article, int turns, string interfaceType, int size) : base(price, year, article)
            {
                this.Turns = turns;
                this.InterfaceType = interfaceType;
                this.Size = size;
            }

            public override void Display()
            {
                string info = $"Ифнормация о жестком диске с артикулом: {this.article} - Количество вращений: {this.turns}, Интерфейс: {this.interfaceType}, Объем: {this.size}, Цена: {this.price}, Год выпуска: {this.releaseYear}.";
                Notify?.Invoke(info);
            }
        }


        public class VideoCard : Device<int>
        {
            protected double frequency;
            protected string brand;
            protected int size;

            new public event InfoHandler Notify;

            public double Frequency { get { return frequency; } set { frequency = value; } }
            public string Brand { get { return brand; } set { brand = value; } }

            public int Size { get { return size; } set { size = value; } }

            public VideoCard(double price, int year, int article, double freq, string brand, int size) : base(price, year, article)
            {
                this.Frequency = freq;
                this.Brand = brand;
                this.Size = size;
            }

            public override void Display()
            {
                string info = $"Информация о видеокарте с артикулом: {this.article} - Частота: {this.frequency}, Производитель: {this.brand}, Видеопамять: {this.size}, Цена: {this.price}, Год выпуска: {this.releaseYear}.";
                Notify?.Invoke(info);
            }
        }

        VideoCard videocard;
        HardDisk hdd;

        public bool CheckHddTextBoxes()
        {
            if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0 && textBox3.Text.Length > 0 && textBox4.Text.Length > 0 && textBox5.Text.Length > 0 && textBox6.Text.Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckVideocardTextBoxes()
        {
            if (textBox7.Text.Length > 0 && textBox8.Text.Length > 0 && textBox9.Text.Length > 0 && textBox10.Text.Length > 0 && textBox11.Text.Length > 0 && textBox12.Text.Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ClearHddTextBoxes()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }

        public void ClearVideocardTextBoxes()
        {
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
        }

        public void ViewingInformationBeforeCreating()
        {
            MessageBox.Show("Нельзя вызвать метод у экземпляра класса если он еще не создан!");
        }

        public void ShowInfo(string m)
        {

            listBox1.Items.Add(m);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CheckHddTextBoxes())
            {

                try
                {
                    double price = Convert.ToDouble(textBox1.Text);
                    int year = Convert.ToInt32(textBox2.Text);
                    string article = textBox3.Text;
                    int turns = Convert.ToInt32(textBox4.Text);
                    string interfaceType = textBox5.Text;
                    int size = Convert.ToInt32(textBox6.Text);
                    hdd = new HardDisk(price, year, article, turns, interfaceType, size);
                    hdd.Notify += ShowInfo;
                    ClearHddTextBoxes();
                }
                catch
                {
                    MessageBox.Show("Произошла ошибка при создании экземпляра класса!");
                    ClearHddTextBoxes();
                }


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (hdd != null)
            {
                hdd.Display();
            }
            else
            {
                ViewingInformationBeforeCreating();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (CheckVideocardTextBoxes())
            {

                try
                {

                    double price = Convert.ToDouble(textBox12.Text);
                    int year = Convert.ToInt32(textBox11.Text);
                    int article = Convert.ToInt32(textBox10.Text);
                    double freq = Convert.ToDouble(textBox9.Text);
                    string brand = textBox8.Text;
                    int size = Convert.ToInt32(textBox7.Text);

                    videocard = new VideoCard(price, year, article, freq, brand, size);
                    videocard.Notify += ShowInfo;
                    ClearVideocardTextBoxes();

                }
                catch
                {
                    MessageBox.Show("Произошла ошибка при создании экземпляра класса!");
                    ClearVideocardTextBoxes();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (videocard != null)
            {
                videocard.Display();
            }
            else
            {
                ViewingInformationBeforeCreating();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }
    }
}
