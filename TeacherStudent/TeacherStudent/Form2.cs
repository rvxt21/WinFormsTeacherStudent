using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeacherStudent
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public string getText { get { return this.textBox1.Text; } set { this.textBox1.Text = value; } }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string street = this.textBox1.Text;
            string city = this.textBox2.Text;
            int house = Convert.ToInt32(this.textBox3.Text);
            Adress adresnew = new Adress(city, street, house);
            StaticAdress.Adress = adresnew;
        }
    }
}
