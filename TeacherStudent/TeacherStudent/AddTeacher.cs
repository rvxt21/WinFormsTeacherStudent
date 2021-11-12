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
    public partial class AddTeacher : Form
    {
        Form2 f2 = new Form2();
        public AddTeacher()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = this.textBox1.Text;
            string surname = this.textBox2.Text;
            string subject = this.textBox4.Text;
            int age = Convert.ToInt32(this.textBox3.Text);
            int maxnum = Convert.ToInt32(this.textBox5.Text);
            StaticTeacher.adresTeacher = StaticAdress.Adress;
            Teacher teacher1 = new Teacher(maxnum, subject, name, surname, age, StaticTeacher.adresTeacher);
            StaticTeacher.Teacher = teacher1;
        }

        private void button2_Click(object sender, EventArgs e)
        { 
            f2.Show();
        }
    }
}
