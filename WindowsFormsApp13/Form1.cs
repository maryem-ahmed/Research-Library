using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp13
{
    public partial class Form1 : Form
    {
        FileStream fs;
        StreamReader sr;
        StreamWriter sw;

        SortedDictionary<int, int> dict = new SortedDictionary<int, int>();
        public Form1()
        {
            InitializeComponent();
            this.BackgroundImage = Image.FromFile("C:\\Users\\user\\OneDrive\\Desktop\\project.jpg");

            // Optionally, adjust the background image layout
            this.BackgroundImageLayout = ImageLayout.Stretch; // or ImageLayout.Tile, ImageLayout.Center, etc.
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Research Library";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }



        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click_1(object sender, EventArgs e)//display
        {
            Form2 displaybutton = new Form2();
            displaybutton.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)// insert
        {
            fs.Seek(0, SeekOrigin.End);
            int loc = (int)(fs.Position);
            sw.WriteLine(textBox1.Text + "|" + textBox2.Text + "|" + textBox3.Text + "|" + textBox4.Text);
            sw.Flush();
            dict.Add(int.Parse(textBox3.Text), loc);
            MessageBox.Show("Inserted");
        }

        private void button3_Click_1(object sender, EventArgs e)//open
        {
            fs = new FileStream("random.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            sr = new StreamReader(fs);
            sw = new StreamWriter(fs);
            MessageBox.Show("Opened");

        }

        private void button8_Click(object sender, EventArgs e)//rewrite
        {
            StreamWriter Isw = new StreamWriter("index.txt");
            foreach (KeyValuePair<int, int> item in dict)
            {
                Isw.WriteLine(item.Key + "|" + item.Value);
            }
            Isw.Close();
            MessageBox.Show("Done Rewrite");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)// load
        {
            dict.Clear();
            string line;
            StreamReader isr;
            if (File.Exists("index.txt"))
            {
                isr = new StreamReader("index.txt");
                while ((line = isr.ReadLine()) != null)
                {
                    string[] arr = line.Split('|');
                    dict.Add(int.Parse(arr[0]), int.Parse(arr[1]));
                }
                isr.Close();
                MessageBox.Show("Index File Loaded in dic.");

            }
        }
        public bool BS(int[] arr, int K)
        {
            int f = 0, L = arr.Length - 1; int mid = (f + L) / 2;

            while (f <= L)
            {
                mid = (f + L) / 2;
                if (K < arr[mid])
                {
                    L = mid - 1;
                }
                else if (K > arr[mid])
                    f = mid + 1;
                else
                    return true;
            }
            return false;
        }
        private void button6_Click(object sender, EventArgs e)//search
        {
            if (BS(dict.Keys.ToArray(), int.Parse(textBox3.Text)))
            {
                fs.Seek(dict[int.Parse(textBox3.Text)], SeekOrigin.Begin);
                string line = sr.ReadLine();
                string[] arr = line.Split('|');
                textBox1.Text = arr[0];
                textBox2.Text = arr[1];
                textBox4.Text = arr[3];
                return;
            }
            else
            {
                textBox1.Text = textBox2.Text = textBox4.Text= "N F";
            }
            
        }

        private void button9_Click(object sender, EventArgs e) //clear
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = null;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            sw.Close(); sr.Close(); fs.Close(); 
        }

        private void button2_Click_1(object sender, EventArgs e)//delete
        {
            if (BS(dict.Keys.ToArray(), int.Parse(textBox3.Text)))
            {
                fs.Seek(dict[int.Parse(textBox3.Text)], SeekOrigin.Begin);
               
                string line;
                string[] field;
                int count = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    field = line.Split('|');
                    if (field[2] == textBox3.Text)
                    {
                        fs.Seek(count, SeekOrigin.Begin);
                        sw.Write("*");
                        sw.Flush();
                    }
                }
                count += line.Length + 2;
                dict.Remove(int.Parse(textBox3.Text));
                MessageBox.Show("done");
                return;
            }
            textBox1.Text = textBox2.Text = textBox4.Text= "N F";
        }

    }
}


