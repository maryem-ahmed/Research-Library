using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp13
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.BackgroundImage = Image.FromFile("C:\\Users\\user\\OneDrive\\Desktop\\project.jpg");

            // Optionally, adjust the background image layout
            this.BackgroundImageLayout = ImageLayout.Stretch; // or ImageLayout.Tile, ImageLayout.Center, etc.
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          
            if (File.Exists("random.txt"))
            {
                FileStream myFile = new FileStream("random.txt", FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(myFile);
                textBox1.Text = "\r\n Library Content: \r\n" + "----------------\r\n" + sr.ReadToEnd();
                sr.Close(); myFile.Close();
            }
        }
    }
}
